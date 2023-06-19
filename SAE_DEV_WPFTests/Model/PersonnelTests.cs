using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAE_DEV_WPF.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.TextFormatting;
using static System.Net.Mime.MediaTypeNames;

namespace SAE_DEV_WPF.Model.Tests
{
    [TestClass()]
    public class PersonnelTests
    {
        //private string connectionString = "Server=iutannecy-deptinfo.fr;port=5432;Database=sae201;Search Path=matinfoauto;uid=clehug;password=LMwggD;";

        [TestMethod()]
        public void CreateTest()
        {
            Personnel p1 = new Personnel("test1","toto","toto@gmail.com");
            p1.Create();
            ObservableCollection<Personnel> personnels = p1.FindAll();
            Assert.AreEqual("toto@gmail.com", personnels.ToList().Find(x => x.Email == p1.Email).Email);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Personnel p2 = new Personnel("test2", "toto2", "toto2@gmail.com");
            p2.Delete();
            ObservableCollection<Personnel> personnels = p2.FindAll();
            Assert.AreEqual(null, personnels.ToList().Find(x => x.Email == p2.Email));
        }

        [TestMethod()]
        public void UpdateTest()
        {
            Personnel p4 = new Personnel(4, "test4", "toto4", "toto4@gmail.com");
            Assert.AreEqual("test4", p4.Nom);
            p4.Nom = "testUpdate";
            p4.Update();
            Assert.AreEqual("testUpdate", p4.Nom);

        }

        [TestMethod()]
        //[ExpectedException(typeof(Exception))]
        public void ReadTest()
        {
            Personnel p3 = new Personnel(3, "test3", "toto3", "toto3@gmail.com");
            p3.Read();
        }
    }
}