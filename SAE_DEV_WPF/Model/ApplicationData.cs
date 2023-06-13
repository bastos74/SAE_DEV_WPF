using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_DEV_WPF.Model
{

    public class ApplicationData
    {
        // Pour le personnel 
        public ObservableCollection<Personnel> LesPersonnels { get; set; }

        // Matériel
        public ObservableCollection<Materiel> LesMateriels { get; set; }

        //Catégorie
        public ObservableCollection<Categorie> LesCategories { get; set; }

        public ApplicationData()
        {
            // Find all Pour le personnel 
            Personnel p = new Personnel();
            LesPersonnels = p.FindAll();

            Materiel m = new Materiel();
            LesMateriels = m.FindAll();

            Categorie c = new Categorie();
            LesCategories = c.FindAll();
        }
    }
}
