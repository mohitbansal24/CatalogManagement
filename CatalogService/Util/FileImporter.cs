using CatalogService.Manager;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CatalogService.Util
{
    public static class FileImporter
    {
        public static List<Catalog> ImportCatalogData(string filePath)
        {
            try
            {
                var CatalogData = CsvReader.ReadCsv(filePath);

                return CatalogData
                 .Select(csv => new Catalog() { Sku = csv[0], Description = csv[1] })
                 .ToList();
            }
            catch (Exception ex)
            {
                LoggerManager.Error(ex.InnerException.ToString());
                throw;
            }
        }

        public static List<Supplier> ImportSupplierData(string filePath)
        {
            try
            {
                var supplierData = CsvReader.ReadCsv(filePath);

                return supplierData
                 .Select(csv => new Supplier() { SupplierId = Convert.ToInt32(csv[0]), SupplierName = csv[1] })
                 .ToList();

            }
            catch (Exception ex)
            {
                LoggerManager.Error(ex.InnerException.ToString());
                throw;
            }
        }

        public static List<Barcodes> ImportBarcodeData(string filePath)
        {
            try
            {
                var barcodeData = CsvReader.ReadCsv(filePath);

                return barcodeData
                 .Select(csv => new Barcodes() { SupplierId = Convert.ToInt32(csv[0]), Sku = csv[1], Barcode = csv[2] })
                 .ToList();
            }
            catch (Exception ex)
            {
                LoggerManager.Error(ex.InnerException.ToString());
                throw;
            }
        }
    }
}
