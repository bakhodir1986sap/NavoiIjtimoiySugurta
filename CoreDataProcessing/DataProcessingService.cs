using NavoiKasabaUyushmasi.Model;
using NavoiKasabaUyushmasi.Tool;
using System.Reflection;

namespace CoreDataProcessing
{
    public class DataProcessingService : IDataProcessing
    {
        public DataProcessingService(IPrevExperienceProvider prevExperienceProvider,
            IDatabaseDataCheckProvider databaseDataCheckProvider)
        {
            this.prevExperienceProvider = prevExperienceProvider;
            this.databaseDataCheckProvider = databaseDataCheckProvider;
        }

        public List<MigrantImportModel> ProcessData(List<MigrantImportModel> migrantImportModels)
        {
            if (migrantImportModels ==  null)
            {
                return new List<MigrantImportModel>();
            }

            var resultList = new List<MigrantImportModel>();

            foreach (var model in migrantImportModels)
            {
                var resultModel = GetProcessedRow(model);

                if (resultModel.RowStatus == RowStatus.Processed)
                {
                    resultList.Add(resultModel);
                }
            }

            return resultList;
        }

        public MigrantImportModel GetProcessedRow(MigrantImportModel migrantImportModel)
        {
            if (migrantImportModel == null)
            {
                return new MigrantImportModel() { RowStatus = RowStatus.Error }; 
            }

            ProcessProperties(migrantImportModel);

            return migrantImportModel;
        }

        private void ProcessProperties(MigrantImportModel model)
        {
            Type type = model.GetType();
            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                //Console.WriteLine($"Property name: {property.Name}");

                var value = property.GetValue(model, null);
                if (value != null && value.GetType() == typeof(string))
                {
                    property.SetValue(model, HelperFunctions.RemovePunctuations(value.ToString()), null);
                    value = property.GetValue(model, null);
                }
                //ToDo Delete Punktuations and for PassportNumber padding leading zeros

                //Console.Write($" Property value: {value}");

                var attr = (FieldAttribute)Attribute.GetCustomAttribute(property, typeof(FieldAttribute));
                if (attr != null)
                {
                    //Console.WriteLine($"Attribute FieldNumber: {attr.FieldNumber}");
                    //Console.WriteLine($"Attribute IsMandatory: {attr.IsMandatory}");
                    //Console.WriteLine($"Attribute ValidationRegEx: {attr.ValidationRegEx}");
                    //Console.WriteLine($"Attribute DefaultValue: {attr.DefaultValue}");
                    //Console.WriteLine($"Attribute Options: {attr.Options}");
                    //Console.WriteLine($"Attribute SubstitutionFieldNumber: {attr.SubstitutionFieldNumber}");

                    //Data preparetion
                    if (string.IsNullOrEmpty(value?.ToString()) && !string.IsNullOrEmpty(attr.DefaultValue))
                    {
                        property.SetValue(model, attr.DefaultValue);
                        value = property.GetValue(model, null);
                    }

                    if (attr.IsMandatory && string.IsNullOrEmpty(value?.ToString()) && attr.SubstitutionFieldNumber == 0)
                    {
                        model.RowStatus = RowStatus.Error;
                        model.ErrorText += $", Field {attr.FieldNumber} is mandatory";
                    }
                    else if (attr.IsMandatory && string.IsNullOrEmpty(value?.ToString()) && attr.SubstitutionFieldNumber != 0 && attr.SubstitutionFieldNumber != 24)
                    {
                        var substitutionValue = GetPropertyByFieldNumber(model, attr.SubstitutionFieldNumber).GetValue(model, null);
                        if (string.IsNullOrEmpty(value?.ToString()))
                        {
                            property.SetValue(model, substitutionValue);
                            value = property.GetValue(model, null);
                        }
                    }
                    else if (attr.SubstitutionFieldNumber == 24)
                    {
                        //Qaytib kegan Sana qo'yilgan bo'sa keyingi polyalar to'dirilmaydi
                        var substitutionValue = GetPropertyByFieldNumber(model, attr.SubstitutionFieldNumber).GetValue(model, null);
                        if (!string.IsNullOrEmpty(substitutionValue?.ToString().Replace("0","").Trim()))
                        {
                            property.SetValue(model, null);
                            continue;
                        }
                    }

                    //Data comparation and correction
                    if (attr.Options != null && attr.Options.Length > 0)
                    {
                        var currentValue = value?.ToString() ?? string.Empty;

                        currentValue = HelperFunctions.LatinToCyrillicUzbek(currentValue.Trim());

                        var optionExistValue = attr.Options.FirstOrDefault(op => op.ToLower().Equals(currentValue.ToLower()));

                        if (optionExistValue == null)
                        {
                            var prevExperience = prevExperienceProvider.GetPrevExperienceResolveValue(attr.FieldNumber, currentValue);

                            if (string.IsNullOrEmpty(prevExperience))
                            {
                                string maxDefValue = string.Empty;
                                double similarity = 0;
                                foreach (var option in attr.Options)
                                {
                                    var temp = HelperFunctions.CalculateSimilarity(currentValue.ToLower(), option.ToLower());

                                    if (temp > similarity)
                                    {
                                        similarity = temp;
                                        maxDefValue = option;
                                    }
                                }

                                if (similarity >= 0.5)
                                {
                                    property.SetValue(model, maxDefValue);
                                    prevExperienceProvider.SetPrevExperienceResolveValue(attr.FieldNumber,
                                        value?.ToString(), maxDefValue);
                                }
                                else
                                {
                                    property.SetValue(model, attr.DefaultValue);
                                }
                            }
                            else
                            {
                                property.SetValue(model, prevExperience);
                            }
                        }
                        else
                        {
                            property.SetValue(model, optionExistValue);
                        }
                    }

                    //Check Data Existing In Database
                    if (!string.IsNullOrEmpty(model.SeriaPassport) && !string.IsNullOrEmpty(model.RaqamPassport))
                    {
                        var checkResult = databaseDataCheckProvider.GetIchkiIshlarBazaDannix(
                            HelperFunctions.CyrillicToLatinUzbek(model.SeriaPassport).ToUpper(),
                            HelperFunctions.RemovePunctuations(model.RaqamPassport).PadLeft(7, '0'));

                        model.BazadaBorligi = checkResult == null ? "0" : "1";
                    }
                    else
                    {                         
                        model.BazadaBorligi = "0";
                    }

                }
            }

            if (model.RowStatus != RowStatus.Error)
            {
                model.RowStatus = RowStatus.Processed;
            }
        }

        private PropertyInfo GetPropertyByFieldNumber(MigrantImportModel model, int fieldNumber)
        {
            Type type = model.GetType();
            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                var attr = (FieldAttribute)Attribute.GetCustomAttribute(property, typeof(FieldAttribute));
                if (attr != null && attr.FieldNumber == fieldNumber)
                {
                    return property;
                }
            }

            return null;
        }

        private void SetFieldValue(MigrantImportModel model, int fieldNumber, object value)
        {
            var property = GetPropertyByFieldNumber(model, fieldNumber);
            if (property != null)
            {
                property.SetValue(model, value);
            }
        }

        private readonly IPrevExperienceProvider prevExperienceProvider;
        private readonly IDatabaseDataCheckProvider databaseDataCheckProvider;
    }
}
