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
        public ObservableCollection<Materiel> LesMateriels { get; set; }

        public ApplicationData()
        {
            Materiel m = new Materiel();
            LesMateriels = m.FindAll();
        }
    }
}
