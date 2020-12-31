using CatalogService.Manager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace CatalogService.Util
{
    public static class CsvGenerator
    {
        public static void Generate(List<Catalog> outputList, string filePath, string columnHeader)
        {
            try
            {
                var output = new List<string>() { columnHeader };

                output.AddRange(outputList.Select(c => string.Join(",", c.Sku, c.Description, c.Source)).ToList());

                LoggerManager.Info("Generating output file !");

                File.WriteAllLines(filePath, output);
            }
            catch (Exception ex)
            {
                LoggerManager.Error(ex.InnerException.ToString());
                throw;
            }
        }
    }
}
