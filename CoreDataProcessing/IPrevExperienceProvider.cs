using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDataProcessing
{
    public interface IPrevExperienceProvider
    {
        string GetPrevExperienceResolveValue(int field, string key);

        void SetPrevExperienceResolveValue(int field, string key, string value);
    }
}
