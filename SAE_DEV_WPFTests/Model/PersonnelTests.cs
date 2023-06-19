using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAE_DEV_WPF.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.TextFormatting;

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

            


            Personnel p1 = new Personnel("test1","toto","toto@gmail.com");
            p1.Create();
            p1.Read();
            Assert.AreEqual(1, p1.Id);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Personnel p1 = new Personnel("test1", "toto", "toto@gmail.com");
            p1.Delete(); 
            p1.Read();
            Assert.AreEqual(null, p1.Id,"Objet doit être delete");
            
        }

        [TestMethod()]
        public void FindAllTest()
        {
            //Personnel p1 = new Personnel(1, "test1", "toto", "toto@gmail.com");

        //[TestMethod()]
        //public void ReadTest()
        //{
        //    Personnel p1 = new Personnel(1, "test1", "toto", "toto@gmail.com");
        //    p1.Read();
        //    Assert.AreEqual(1, p1.Id);
            
        //}

        [TestMethod()]
        public void UpdateTest()
        {
            Personnel p1 = new Personnel(1, "test1", "toto", "toto@gmail.com");
            p1.Update();

            Assert.Fail();
        }
    
    
    
    
    
    }
}