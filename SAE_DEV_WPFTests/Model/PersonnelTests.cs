using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAE_DEV_WPF.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_DEV_WPF.Model.Tests
{
    [TestClass()]
    public class PersonnelTests
    {

       private string connectionString = "Server=iutannecy-deptinfo.fr;port=5432;Database=sae201;Search Path=matinfoauto;uid=clehug;password=LMwggD;";

        [TestMethod()]
        public void PersonnelTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CreateTest()
        {

          


            Personnel p1 = new Personnel(1,"test1","toto","toto@gmail.com");
            Assert.IsNotNull(p1);

            

        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void FindAllTest()
        {
            //Personnel p1 = new Personnel(1, "test1", "toto", "toto@gmail.com");

            //string requete = "SELECT * FROM personnel ";

            //int rowCount = p1.FindAll(x => x.);

            //// Assert
            //Assert.AreEqual(rowCount, "Unexpected row count.");



        }

        [TestMethod()]
        public void FindBySelectionTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ReadTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateTest()
        {
            Assert.Fail();
        }
    
    
    
    
    
    }
}