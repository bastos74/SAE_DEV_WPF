using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            // CATEGORIE -- à faire en 1er
            Categorie c = new Categorie();
            LesCategories = c.FindAll();
            
            // Find all Pour le personnel 
            Personnel p = new Personnel();
            LesPersonnels = p.FindAll();

            // MATERIEL
            Materiel m = new Materiel();
            Materiel.Ad = this;
            LesMateriels = m.FindAll();



            /*
            // pour chaque materiel, on lui affecte son groupe
            foreach (Materiel mat in LesMateriels.ToList())
            {
                mat.Categorie = LesCategories.ToList().Find(g => g.Id == mat.Fk_categorie);
                //throw new Exception(mat.Categorie.Nom);
            }
            // pour chaque categorie, on affecte toutes les références des matériel
            foreach (Categorie cat in LesCategories.ToList())
            {
                cat.LesMateriels = new ObservableCollection<Materiel>(
                LesMateriels.ToList().FindAll(e => e.Fk_categorie == cat.Id));
            }
            */
            
        }
    }
}
