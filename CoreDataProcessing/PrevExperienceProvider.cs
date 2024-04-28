using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDataProcessing
{
    public class PrevExperienceProvider : IPrevExperienceProvider
    {
        private Dictionary<int, Dictionary<string, string>> _prevExperienceResolveValues = new Dictionary<int, Dictionary<string, string>>();

        public string GetPrevExperienceResolveValue(int field, string key)
        {
            return _prevExperienceResolveValues.ContainsKey(field) && _prevExperienceResolveValues[field].ContainsKey(key) ? _prevExperienceResolveValues[field][key] : null;
        }

        public void SetPrevExperienceResolveValue(int field, string key, string value)
        {
            if (!_prevExperienceResolveValues.ContainsKey(field))
            {
                _prevExperienceResolveValues.Add(field, new Dictionary<string, string>());
            }

            if (_prevExperienceResolveValues[field].ContainsKey(key))
            {
                _prevExperienceResolveValues[field][key] = value;
            }
            else
            {
                _prevExperienceResolveValues[field].Add(key, value);
            }
        }
    }
}
