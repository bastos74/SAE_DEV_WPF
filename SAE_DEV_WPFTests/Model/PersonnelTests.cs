using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAE_DEV_WPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_DEV_WPF.Model.Tests
{
    [TestClass()]
    public class PersonnelTests
    {
        [TestMethod()]
        public void PersonnelTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CreateTest()
        {
            string connectionString = "Data Source=server_name;Initial Catalog=database_name;User ID=username;Password=password;";



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
            Assert.Fail();
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