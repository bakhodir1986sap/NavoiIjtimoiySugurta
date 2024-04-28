using NavoiKasabaUyushmasi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDataProcessing
{
    public interface IDataProcessing
    {
        List<MigrantImportModel> ProcessData(List<MigrantImportModel> migrantImportModels);

        MigrantImportModel GetProcessedRow(MigrantImportModel migrantImportModel);
    }
}
