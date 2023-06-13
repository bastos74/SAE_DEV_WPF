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
        public ObservableCollection<Personnel> lepersonnel { get; set; }
        
        
        
        public ApplicationData()
        {
            // Find all Pour le personnel 
            Personnel p = new Personnel();
            lepersonnel = p.FindAll();




        public ObservableCollection<Materiel> LesMateriels { get; set; }

        public ApplicationData()
        {
            Materiel m = new Materiel();
            LesMateriels = m.FindAll();
        }
    }
}
