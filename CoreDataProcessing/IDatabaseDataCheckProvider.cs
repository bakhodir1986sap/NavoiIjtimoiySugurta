using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDataProcessing
{
    public interface IDatabaseDataCheckProvider
    {
        IchkiIshlarBazaDannix GetIchkiIshlarBazaDannix(string passportSeria, string passportNumber);
    }
}
