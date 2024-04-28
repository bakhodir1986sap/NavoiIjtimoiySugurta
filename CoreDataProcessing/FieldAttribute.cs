using System.ComponentModel;

namespace NavoiKasabaUyushmasi.Tool
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FieldAttribute : Attribute
    {
        public int FieldNumber { get; private set; }
        public bool IsMandatory { get; private set; }
        public string ValidationRegEx { get; private set; }
        public string DefaultValue { get; set; }
        public string[] Options { get; set; }
        public int SubstitutionFieldNumber { get; set; }

        public int MaxLength { get; set; }

        public FieldAttribute(int fieldNumber, bool isMandatory, string validationRegEx = "^.*$", string defaultValue = "", string[] options = null, int substitutionFieldNumber = 0, int maxLength = 0)
        {
            FieldNumber = fieldNumber;
            IsMandatory = isMandatory;
            ValidationRegEx = validationRegEx;
            DefaultValue = defaultValue;
            Options = options;
            SubstitutionFieldNumber = substitutionFieldNumber;
            MaxLength = maxLength;
        }
    }
}
