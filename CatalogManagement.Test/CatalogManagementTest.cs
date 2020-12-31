using CatalogManagementSystem;
using CatalogService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace CatalogManagement.Test
{
    [TestClass]
    public class CatalogManagementTest
    {
        [TestMethod]
        public void CreateMasterCatalog_Success()
        {
            //Data Preparation
            var catalogA = CreateCatalogAData();

            var catalogB = CreateCatalogBData();

            //Function call
            var output = CatalogManager.CreateMasterCatalog(catalogA, catalogB);

            //Assert
            Assert.IsTrue(output.Count == (catalogA.Count + catalogB.Count));
        }

        [TestMethod]
        public void CreateMasterCatalog_Fail()
        {
            //Data Preparation
            var catalogA = CreateCatalogAData();

            var catalogB = CreateCatalogBData_Fail();

            //Function call
            var output = CatalogManager.CreateMasterCatalog(catalogA, catalogB);

            //Assert
            Assert.IsFalse(output.Count == (catalogA.Count + catalogB.Count - 1));
        }

        [TestMethod]
        public void CreateFinalCatalog_Pass()
        {
            //Data Preparation
            var catalogA = CreateCatalogAData();

            var catalogB = CreateCatalogBData();

            var expectedOutputCatalog = CreateOutputData_Valid();

            var barCodeAList = CreateBarcodeAData();

            var barCodeBList = CreateBarcodeBData();

            //Function call
            var output = CatalogManager.CreateFinalCatalog(catalogA, barCodeAList, barCodeBList, CatalogManager.CreateMasterCatalog(catalogA, catalogB));

            //Sorting the list for compare
            var sortedOutputList = output.OrderBy(c => c.Sku).ThenBy(c => c.Description).ThenBy(c => c.Source).ToList();

            var expectedOutputSortedList = expectedOutputCatalog.OrderBy(c => c.Sku).ThenBy(c => c.Description).ThenBy(c => c.Source).ToList();

            //Assert
            Assert.IsTrue(CompareOutput(expectedOutputSortedList, sortedOutputList));

        }

        [TestMethod]
        public void CreateFinalCatalog_Fail()
        {
            //Data Preparation
            var catalogA = CreateCatalogAData();

            var catalogB = CreateCatalogBData();

            var expectedOutputCatalog = CreateOutputData_Invalid();

            var barCodeAList = CreateBarcodeAData();

            var barCodeBList = CreateBarcodeBData();

            //Function call
            var output = CatalogManager.CreateFinalCatalog(catalogA, barCodeAList, barCodeBList, CatalogManager.CreateMasterCatalog(catalogA, catalogB));

            //Sorting the list for compare
            var sortedOutputList = output.OrderBy(c => c.Sku).ThenBy(c => c.Description).ThenBy(c => c.Source).ToList();

            var expectedOutputSortedList = expectedOutputCatalog.OrderBy(c => c.Sku).ThenBy(c => c.Description).ThenBy(c => c.Source).ToList();

            var result = CompareOutput(expectedOutputSortedList, sortedOutputList);
            //Assert
            Assert.IsFalse(result);

        }

        #region Create test dataset
        private static List<Barcodes> CreateBarcodeBData()
        {
            return new List<Barcodes>()
            {
                new Barcodes { SupplierId = 00001, Sku="999-vyk-317",Barcode="z2783613083817"},
                new Barcodes { SupplierId = 00001, Sku="999-vyk-317",Barcode="n7405223693844"},
                new Barcodes { SupplierId = 00001, Sku="999-vyk-317",Barcode="c7417468772846"},
                new Barcodes { SupplierId = 00001, Sku="999-vyk-317",Barcode="w3744746803743"},
                new Barcodes { SupplierId = 00001, Sku="999-vyk-317",Barcode="w2572813758673"},
                new Barcodes { SupplierId = 00001, Sku="999-vyk-317",Barcode="s7013910076253"},
                new Barcodes { SupplierId = 00001, Sku="999-vyk-317",Barcode="m1161615509466"},
                new Barcodes { SupplierId = 00002, Sku="999-oad-768",Barcode="p2359014924610"},
                new Barcodes { SupplierId = 00002, Sku="999-oad-768",Barcode="a7802303764525"},
                new Barcodes { SupplierId = 00002, Sku="999-oad-768",Barcode="o5194275040472"},
                new Barcodes { SupplierId = 00002, Sku="999-oad-768",Barcode="j9023946968130"},
                new Barcodes { SupplierId = 00002, Sku="999-oad-768",Barcode="x5678105140949"},
                new Barcodes { SupplierId = 00002, Sku="999-oad-768",Barcode="c9083052423045"},
                new Barcodes { SupplierId = 00002, Sku="999-oad-768",Barcode="f4322915485228"},
                new Barcodes { SupplierId = 00002, Sku="999-oad-768",Barcode="i0471865670980"},
                new Barcodes { SupplierId = 00002, Sku="999-oad-768",Barcode="b4381274928349"},
                new Barcodes { SupplierId = 00003, Sku="165-rcy-650",Barcode="u5160747892301"},
                new Barcodes { SupplierId = 00003, Sku="165-rcy-650",Barcode="m8967092785598"},
                new Barcodes { SupplierId = 00003, Sku="165-rcy-650",Barcode="l7342139757479"},
                new Barcodes { SupplierId = 00003, Sku="165-rcy-650",Barcode="p1667270888414"},
                new Barcodes { SupplierId = 00003, Sku="165-rcy-650",Barcode="v0874763455559"},
                new Barcodes { SupplierId = 00003, Sku="165-rcy-650",Barcode="p9774916416859"},
                new Barcodes { SupplierId = 00003, Sku="165-rcy-650",Barcode="c4858834209466"},
                new Barcodes { SupplierId = 00003, Sku="165-rcy-650",Barcode="x7331732444187"},
                new Barcodes { SupplierId = 00003, Sku="165-rcy-650",Barcode="u7720008047675"},
                new Barcodes { SupplierId = 00003, Sku="165-rcy-650",Barcode="i2431892662423"},
                new Barcodes { SupplierId = 00003, Sku="165-rcy-650",Barcode="o1336108796249"},
                new Barcodes { SupplierId = 00003, Sku="165-rcy-650",Barcode="w7839803663600"},
                new Barcodes { SupplierId = 00004, Sku="999-eol-949",Barcode="x6971219877032"},
                new Barcodes { SupplierId = 00004, Sku="999-eol-949",Barcode="x7340270328026"},
                new Barcodes { SupplierId = 00004, Sku="999-eol-949",Barcode="x0126648261918"},
                new Barcodes { SupplierId = 00004, Sku="999-eol-949",Barcode="x9858014383660"},
                new Barcodes { SupplierId = 00004, Sku="999-eol-949",Barcode="x2338856941909"},
                new Barcodes { SupplierId = 00004, Sku="999-eol-949",Barcode="x5056026479965"},
                new Barcodes { SupplierId = 00004, Sku="999-eol-949",Barcode="x7425424390056"},
                new Barcodes { SupplierId = 00004, Sku="999-eol-949",Barcode="x0864219864945"},
                new Barcodes { SupplierId = 00004, Sku="999-eol-949",Barcode="x1257743939800"},
                new Barcodes { SupplierId = 00004, Sku="999-eol-949",Barcode="x0880467790155"},
                new Barcodes { SupplierId = 00004, Sku="999-eol-949",Barcode="x4469253605532"},
                new Barcodes { SupplierId = 00004, Sku="999-eol-949",Barcode="x0891358702681"},
                new Barcodes { SupplierId = 00005, Sku="999-epd-782",Barcode="b8954999835177"},
                new Barcodes { SupplierId = 00005, Sku="999-epd-782",Barcode="b2381485695273"},
                new Barcodes { SupplierId = 00005, Sku="999-epd-782",Barcode="b0588794459804"},
                new Barcodes { SupplierId = 00005, Sku="999-epd-782",Barcode="b8710606253394"},
                new Barcodes { SupplierId = 00005, Sku="999-epd-782",Barcode="b5184937926186"},
                new Barcodes { SupplierId = 00005, Sku="999-epd-782",Barcode="b4059282550570"},
                new Barcodes { SupplierId = 00005, Sku="999-epd-782",Barcode="b3213966445562"},
                new Barcodes { SupplierId = 00005, Sku="999-epd-782",Barcode="b3343396882074"}
            };
        }
        private static List<Barcodes> CreateBarcodeAData()
        {
            return new List<Barcodes>()
            {
                 new Barcodes { SupplierId = 00001, Sku="647-vyk-317",Barcode="z2783613083817"},
                new Barcodes { SupplierId = 00001, Sku="647-vyk-317",Barcode="z2783613083818"},
                new Barcodes { SupplierId = 00001, Sku="647-vyk-317",Barcode="z2783613083819"},
                new Barcodes { SupplierId = 00001, Sku="647-vyk-317",Barcode="n7405223693844"},
                new Barcodes { SupplierId = 00001, Sku="647-vyk-317",Barcode="c7417468772846"},
                new Barcodes { SupplierId = 00001, Sku="647-vyk-317",Barcode="w3744746803743"},
                new Barcodes { SupplierId = 00001, Sku="647-vyk-317",Barcode="w2572813758673"},
                new Barcodes { SupplierId = 00001, Sku="647-vyk-317",Barcode="s7013910076253"},
                new Barcodes { SupplierId = 00001, Sku="647-vyk-317",Barcode="m1161615509466"},
                new Barcodes { SupplierId = 00002, Sku="280-oad-768",Barcode="p2359014924610"},
                new Barcodes { SupplierId = 00002, Sku="280-oad-768",Barcode="a7802303764525"},
                new Barcodes { SupplierId = 00002, Sku="280-oad-768",Barcode="o5194275040472"},
                new Barcodes { SupplierId = 00002, Sku="280-oad-768",Barcode="j9023946968130"},
                new Barcodes { SupplierId = 00002, Sku="280-oad-768",Barcode="x5678105140949"},
                new Barcodes { SupplierId = 00002, Sku="280-oad-768",Barcode="c9083052423045"},
                new Barcodes { SupplierId = 00002, Sku="280-oad-768",Barcode="f4322915485228"},
                new Barcodes { SupplierId = 00002, Sku="280-oad-768",Barcode="i0471865670980"},
                new Barcodes { SupplierId = 00002, Sku="280-oad-768",Barcode="i0471865670981"},
                new Barcodes { SupplierId = 00002, Sku="280-oad-768",Barcode="i0471865670982"},
                new Barcodes { SupplierId = 00002, Sku="280-oad-768",Barcode="b4381274928349"},
                new Barcodes { SupplierId = 00003, Sku="165-rcy-650",Barcode="u5160747892301"},
                new Barcodes { SupplierId = 00003, Sku="165-rcy-650",Barcode="m8967092785598"},
                new Barcodes { SupplierId = 00003, Sku="165-rcy-650",Barcode="l7342139757479"},
                new Barcodes { SupplierId = 00003, Sku="165-rcy-650",Barcode="p1667270888414"},
                new Barcodes { SupplierId = 00003, Sku="165-rcy-650",Barcode="v0874763455559"},
                new Barcodes { SupplierId = 00003, Sku="165-rcy-650",Barcode="p9774916416859"},
                new Barcodes { SupplierId = 00003, Sku="165-rcy-650",Barcode="c4858834209466"},
                new Barcodes { SupplierId = 00003, Sku="165-rcy-650",Barcode="x7331732444187"},
                new Barcodes { SupplierId = 00003, Sku="165-rcy-650",Barcode="u7720008047675"},
                new Barcodes { SupplierId = 00003, Sku="165-rcy-650",Barcode="i2431892662423"},
                new Barcodes { SupplierId = 00003, Sku="165-rcy-650",Barcode="o1336108796249"},
                new Barcodes { SupplierId = 00003, Sku="165-rcy-650",Barcode="w7839803663600"},
                new Barcodes { SupplierId = 00004, Sku="167-eol-949",Barcode="a6971219877032"},
                new Barcodes { SupplierId = 00004, Sku="167-eol-949",Barcode="a7340270328026"},
                new Barcodes { SupplierId = 00004, Sku="167-eol-949",Barcode="a0126648261918"},
                new Barcodes { SupplierId = 00004, Sku="167-eol-949",Barcode="a9858014383660"},
                new Barcodes { SupplierId = 00004, Sku="167-eol-949",Barcode="a2338856941909"},
                new Barcodes { SupplierId = 00004, Sku="167-eol-949",Barcode="a5056026479965"},
                new Barcodes { SupplierId = 00004, Sku="167-eol-949",Barcode="a7425424390056"},
                new Barcodes { SupplierId = 00004, Sku="167-eol-949",Barcode="a0864219864945"},
                new Barcodes { SupplierId = 00004, Sku="167-eol-949",Barcode="a1257743939800"},
                new Barcodes { SupplierId = 00004, Sku="167-eol-949",Barcode="a0880467790155"},
                new Barcodes { SupplierId = 00004, Sku="167-eol-949",Barcode="a4469253605532"},
                new Barcodes { SupplierId = 00004, Sku="167-eol-949",Barcode="a0891358702681"},
                new Barcodes { SupplierId = 00005, Sku="650-epd-782",Barcode="n8954999835177"},
                new Barcodes { SupplierId = 00005, Sku="650-epd-782",Barcode="d2381485695273"},
                new Barcodes { SupplierId = 00005, Sku="650-epd-782",Barcode="y0588794459804"},
                new Barcodes { SupplierId = 00005, Sku="650-epd-782",Barcode="v8710606253394"},
                new Barcodes { SupplierId = 00005, Sku="650-epd-782",Barcode="o5184937926186"},
                new Barcodes { SupplierId = 00005, Sku="650-epd-782",Barcode="r4059282550570"},
                new Barcodes { SupplierId = 00005, Sku="650-epd-782",Barcode="k3213966445562"},
                new Barcodes { SupplierId = 00005, Sku="650-epd-782",Barcode="a3343396882074"}
            };
        }
        private static List<Catalog> CreateOutputData_Valid()
        {
            return new List<Catalog>() {
                new Catalog { Description = "Walkers Special Old Whiskey", Sku = "647-vyk-317" , Source="A"},
                new Catalog { Description = "Bread - Raisin", Sku = "280-oad-768" , Source="A"},
                new Catalog { Description = "Tea - Decaf 1 Cup", Sku = "165-rcy-650" , Source="A"},
                new Catalog { Description = "Cheese - Grana Padano", Sku = "999-eol-949" , Source="B"},
                new Catalog { Description = "Cheese - Grana Padano", Sku = "167-eol-949" , Source="A"},
                new Catalog { Description = "Carbonated Water - Lemon Lime", Sku = "999-epd-782" , Source="B"},
                new Catalog { Description = "Carbonated Water - Lemon Lime", Sku = "650-epd-782" , Source="A"}
            };
        }
        private static List<Catalog> CreateCatalogAData()
        {
            return new List<Catalog>() {
                new Catalog { Description = "Walkers Special Old Whiskey", Sku = "647-vyk-317"},
                new Catalog { Description = "Bread - Raisin", Sku = "280-oad-768" },
                new Catalog { Description = "Tea - Decaf 1 Cup", Sku = "165-rcy-650" },
                new Catalog { Description = "Cheese - Grana Padano", Sku = "167-eol-949" },
                new Catalog { Description = "Carbonated Water - Lemon Lime", Sku = "650-epd-782" }
            };
        }
        private static List<Catalog> CreateCatalogBData()
        {
            return new List<Catalog>() {
                new Catalog { Description = "Walkers Special Old Whiskey test", Sku = "999-vyk-317" },
                new Catalog { Description = "Bread - Raisin", Sku = "999-oad-768" },
                new Catalog { Description = "Tea - Decaf 1 Cup", Sku = "165-rcy-650" },
                new Catalog { Description = "Cheese - Grana Padano", Sku = "999-eol-949" },
                new Catalog { Description = "Carbonated Water - Lemon Lime", Sku = "999-epd-782" }
            };
        }
        private static List<Catalog> CreateCatalogBData_Fail()
        {
            return new List<Catalog>() {
                new Catalog { Description = "Walkers Special Old Whiskey test", Sku = "999-vyk-317" },
                new Catalog { Description = "Bread - Raisin", Sku = "999-oad-768" },
                new Catalog { Description = "Tea - Decaf 1 Cup", Sku = "165-rcy-650" },
                new Catalog { Description = "Cheese - Grana Padano", Sku = "999-eol-949" },
                new Catalog { Description = "Carbonated Water - Lemon Lime", Sku = "999-epd-782" },
                new Catalog { Description = "Carbonated Water - Lemon Lime", Sku = "999-epd-782" },
                new Catalog { Description = "Carbonated Water - Lemon Lime", Sku = "999-epd-782" }
            };
        }
        private static List<Catalog> CreateOutputData_Invalid()
        {
            return new List<Catalog>() {
                new Catalog { Description = "Walkers Special Old Whiskey", Sku = "647-vyk-317" , Source="A"},
                new Catalog { Description = "Bread - Raisintest", Sku = "280-oad-768" , Source="A"},
                new Catalog { Description = "Tea - Decaf 1 Cup", Sku = "165-rcy-650" , Source="A"},
                new Catalog { Description = "Cheese - Grana Padano", Sku = "999-eol-949" , Source="B"},
                new Catalog { Description = "Cheese - Grana Padano", Sku = "167-eol-949" , Source="A"},
                new Catalog { Description = "Carbonated Water - Lemon Lime", Sku = "999-epd-782" , Source="B"},
                new Catalog { Description = "Carbonated Water - Lemon Lime", Sku = "650-epd-782" , Source="A"}
            };
        }
        #endregion

        #region Compare output function
        private static bool CompareOutput(List<Catalog> expectedOutput, List<Catalog> result)
        {
            var counter = 0;
            foreach (var item in result)
            {
                if (item.Sku == expectedOutput[counter].Sku && item.Description == expectedOutput[counter].Description && item.Source == expectedOutput[counter].Source)
                {
                    counter++;
                    continue;
                }
                return false;
            }
            return true;
        }
        #endregion
    }
}
