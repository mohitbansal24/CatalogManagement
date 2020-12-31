using CatalogService.Manager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CatalogService
{
    public static class CsvReader
    {
        public static List<string[]> ReadCsv(string filePath)
        {
            try
            {
                if (new FileInfo(filePath).Length == 0)
                    LoggerManager.Warning("File is empty");

                var list = File.ReadAllLines(filePath).Skip(1).Select(csv => csv.Split(',')).ToList();
                return list;
            }
            catch (Exception ex)
            {
                LoggerManager.Error(ex.InnerException.ToString());
                throw;
            }
        }
    }
}
