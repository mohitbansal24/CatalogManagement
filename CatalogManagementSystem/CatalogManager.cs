using CatalogService;
using CatalogService.Manager;
using CatalogService.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ErrorCode = CatalogManagementSystem.Constant.Constants.ErrorCodes;
using Filepath = CatalogManagementSystem.Constant.Constants.Filepath;
using OutputFile = CatalogManagementSystem.Constant.Constants.OutputFile;
using Supplier = CatalogManagementSystem.Constant.Constants.SupplierSource;

namespace CatalogManagementSystem
{
    public static class CatalogManager
    {
        static void Main(string[] args)
        {

            if (!ValidateIfAllInputFileExist())
            {
                Console.WriteLine(ErrorCode.FileNotFound);

                LoggerManager.Error(ErrorCode.FileNotFound);
            }
            else
            {
                try
                {
                    var catalogAList = FileImporter.ImportCatalogData(Filepath.CatalogA);
                    var barcodeAList = FileImporter.ImportBarcodeData(Filepath.BarcodeA);
                    var catalogBList = FileImporter.ImportCatalogData(Filepath.CatalogB);
                    var barcodeBList = FileImporter.ImportBarcodeData(Filepath.BarcodeB);

                    //mega-merge
                    var masterCatalogList = CreateMasterCatalog(catalogAList, catalogBList);

                    //consolidation
                    var mergedCatalog = CreateFinalCatalog(catalogAList, barcodeAList, barcodeBList, masterCatalogList);

                    CsvGenerator.Generate(mergedCatalog, Filepath.OutputFilePath, OutputFile.Header);

                    Console.WriteLine("Output file generated successfully !!!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while running the program, please review the logs !");

                    LoggerManager.Error(ex.InnerException.ToString());
                }
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Validate if file Exist
        /// </summary>
        /// <returns>true if all file exist</returns>
        private static bool ValidateIfAllInputFileExist()
        {
            return File.Exists(Filepath.CatalogA) && File.Exists(Filepath.BarcodeA) && File.Exists(Filepath.SupplierA) && File.Exists(Filepath.CatalogB) && File.Exists(Filepath.BarcodeB) && File.Exists(Filepath.SupplierB);
        }

        /// <summary>
        /// Function to create full catalog list
        /// </summary>
        /// <param name="catalogAList"></param>
        /// <param name="catalogBList"></param>
        /// <returns>List containing all the catalog items from both the catalogs</returns>
        public static List<Catalog> CreateMasterCatalog(List<Catalog> catalogAList, List<Catalog> catalogBList)
        {
            var masterCatalogList = new List<Catalog>();
            masterCatalogList.AddRange(catalogAList.Select(ca => new Catalog { Description = ca.Description, Sku = ca.Sku, Source = Supplier.SupplierA }));
            masterCatalogList.AddRange(catalogBList.Select(cb => new Catalog { Description = cb.Description, Sku = cb.Sku, Source = Supplier.SupplierB }));

            return masterCatalogList;
        }

        /// <summary>
        /// Functions to remove matching barcode from the master catalog
        /// </summary>
        /// <param name="catalogAList"></param>
        /// <param name="barcodeAList"></param>
        /// <param name="barcodeBList"></param>
        /// <param name="masterCatalogList">merged output list</param>
        /// <returns></returns>
        public static List<Catalog> CreateFinalCatalog(List<Catalog> catalogAList, List<Barcodes> barcodeAList, List<Barcodes> barcodeBList, List<Catalog> masterCatalogList)
        {
            catalogAList.ForEach(ca =>
            {
                barcodeAList.Where(ba => ba.Sku == ca.Sku).ToList().ForEach(ba =>
                {
                    masterCatalogList.RemoveAll(mc => barcodeBList.Where(bb => bb.Barcode == ba.Barcode).Select(bb => bb.Sku).Distinct().Contains(mc.Sku) && mc.Source != Supplier.SupplierA);
                });
            });

            return masterCatalogList;
        }
    }
}
