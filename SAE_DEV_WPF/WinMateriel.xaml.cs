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
    public partial class WinMateriel : Window 
    {
        public WinMateriel(WinAttribution owner)
        {
            this.Owner = owner;
            this.DataContext = owner.DataContext; // On assigne notre DataContext à cette fenêtre, à faire avant l'initialisation

            InitializeComponent();

            dgMateriel.Items.Refresh();
        }

        private void lAjouter_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(tbCategorieM.Text) && !String.IsNullOrEmpty(tbNomM.Text) && !String.IsNullOrEmpty(tbRefConstM.Text) && !String.IsNullOrEmpty(tbCodeBarreM.Text))
            {
                // On crée le nouvel objet matériel
                Materiel m = new Materiel(Util.ConvertToOneUpperCase(tbCategorieM.Text), tbNomM.Text, tbRefConstM.Text, tbCodeBarreM.Text);

                // On ajoute le nouveau matériel dans la BDD
                m.Create();
                applicationData.LesMateriels.Add(m);
                applicationData.LesMateriels.Last().FindAll(); // tentative d'actualisation

                // On reset les champs
                tbCategorieM.Text = "";
                tbCodeBarreM.Text = "";
                tbNomM.Text = "";
                tbRefConstM.Text = "";

                ((Button)sender).Background = Util.GetBaseColor();
            }
            else ((Button)sender).Background = Brushes.LightPink;
        }

        private void lModifer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void lSupprimer_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult mes = MessageBox.Show("voulez vous vraiment supprimer ", " suppression ", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (mes == MessageBoxResult.Yes)
            {
                Materiel m = applicationData.LesMateriels[dgMateriel.SelectedIndex];
                applicationData.LesMateriels.Remove(m);
                dgMateriel.Items.Refresh();
                m.Delete();
            }
               
        }
    }
}
