
namespace CatalogManagementSystem.Constant
{
    public static class Constants
    {
        public static class ErrorCodes
        {
            public const string FileNotFound = "Input file missing !!!";
            public const string FileIsEmpty = "File is empty !";
        }

        public static class Filepath
        {
            public const string CatalogA = "./../../../input/catalogA.csv";
            public const string CatalogB = "./../../../input/catalogB.csv";
            public const string SupplierA = "./../../../input/suppliersA.csv";
            public const string SupplierB = "./../../../input/suppliersB.csv";
            public const string BarcodeA = "./../../../input/barcodesA.csv";
            public const string BarcodeB = "./../../../input/barcodesB.csv";
            public const string OutputFilePath = "./../../../output/result_output.csv";
        }

        public static class SupplierSource
        {
            public const string SupplierA = "A";
            public const string SupplierB = "B";
        }

        public static class OutputFile
        {
            public const string Header = "SKU, Description, Source";
        }
    }
}
