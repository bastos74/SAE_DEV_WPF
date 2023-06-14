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

        public ApplicationData()
        {
            // Find all Pour le personnel 
            Personnel p = new Personnel();
            LesPersonnels = p.FindAll();

            Materiel m = new Materiel();
            LesMateriels = m.FindAll();

            // pour chaque materiel, on lui affecte son groupe
            foreach (Materiel mat in LesMateriels.ToList())
            {
                mat.Categorie = LesCategorie.ToList().Find(g => g.Id == unEtud.FK_IdGroupe);
            }
            // pour chaque categorie, on affecte toutes les références des matériel appartenant au groupe
            foreach (Groupe unGroupe in LesGroupes.ToList())
            {
                unGroupe.LesEtudiants = new ObservableCollection<Etudiant>(
                LesEtudiants.ToList().FindAll(e => e.FK_IdGroupe == unGroupe.Id));
            }
        }
    }
}
