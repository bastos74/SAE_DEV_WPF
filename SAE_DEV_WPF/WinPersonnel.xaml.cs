using SAE_DEV_WPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SAE_DEV_WPF
{
    /// <summary>
    /// Logique d'interaction pour WinMateriel.xaml
    /// </summary>
    public partial class WinPersonnel : Window 
    {
        public WinPersonnel(WinAttribution owner)
        {
            InitializeComponent();
            this.Owner = owner;


            dgPersonnel.Items.Refresh();
        }

        private void Button_Click_Ajouter(object sender, RoutedEventArgs e)
        {

            if (!String.IsNullOrEmpty(tbEmailP.Text) && !String.IsNullOrEmpty(tbNomP.Text) && !String.IsNullOrEmpty(tbPrenomP.Text))
            {
                // On crée le nouvel objet Personnel 
                Personnel p = new Personnel(Util.ConvertToOneUpperCase(tbEmailP.Text), tbNomP.Text, tbPrenomP.Text);

                // On ajoute le nouveau matériel dans la BDD
                p.Create();
                applicationData.LesPersonnels.Add(p);
                applicationData.LesPersonnels.Last().FindAll(); // tentative d'actualisation

                // On reset les champs
                tbEmailP.Text = "";
                tbNomP.Text = "";
                tbPrenomP.Text = "";
                
            }
            else ((Button)sender).Background = Brushes.LightPink;

        }
    }
}
