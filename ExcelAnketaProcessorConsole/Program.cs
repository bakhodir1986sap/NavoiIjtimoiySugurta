using CoreDataProcessing;
using ExcelAnketaProcessorConsole;
using Excel = Microsoft.Office.Interop.Excel;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Migrantlar malumotini qayta ishlash");

IPrevExperienceProvider prevExperienceProvider = new PrevExperienceProvider();
IDatabaseDataCheckProvider databaseDataCheckProvider = new DatabaseDataCheckProvider();
IDataProcessing dataProcessing = new DataProcessingService(prevExperienceProvider, databaseDataCheckProvider);
ExcelController excelController = new ExcelController(dataProcessing);
excelController.ReadAllVipiskaFiles();



