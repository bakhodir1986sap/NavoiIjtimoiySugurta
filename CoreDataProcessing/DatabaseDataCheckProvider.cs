using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDataProcessing
{
    public class DatabaseDataCheckProvider : IDatabaseDataCheckProvider
    {
        private List<string> _existingMigrantPassports = new List<string>();

        public IchkiIshlarBazaDannix GetIchkiIshlarBazaDannix(string passportSeria, string passportNumber)
        {
            try
            {
                if (_existingMigrantPassports.Count == 0)
                {
                    string filePath = "ExistingMigrantPassports.txt";

                    if (!File.Exists(filePath))
                    {
                        throw new FileNotFoundException($"File not found: {filePath}");
                    }

                    _existingMigrantPassports.AddRange(File.ReadAllLines(filePath));
                }

                var pspData = _existingMigrantPassports.FirstOrDefault(x => x.Contains($"{passportSeria}{passportNumber}"));

                if (pspData == null)
                {
                    return null;
                }

                return new IchkiIshlarBazaDannix
                {
                    psp = pspData
                };
            }
            catch (FileNotFoundException)
            {
                return null;
            }
        }
    }
}
