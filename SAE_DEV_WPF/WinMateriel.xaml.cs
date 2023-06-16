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
            tbCategorieM.BorderBrush = Util.GetBaseColorTextBox();
            tbNomM.BorderBrush = Util.GetBaseColorTextBox();
            tbRefConstM.BorderBrush = Util.GetBaseColorTextBox();
            tbCodeBarreM.BorderBrush = Util.GetBaseColorTextBox();

            if (String.IsNullOrEmpty(tbCategorieM.Text))
            {
                tbCategorieM.BorderBrush = Brushes.Red;
            }
            if (String.IsNullOrEmpty(tbNomM.Text))
            {
                tbNomM.BorderBrush = Brushes.Red;
            }
            if (String.IsNullOrEmpty(tbRefConstM.Text))
            {
                tbRefConstM.BorderBrush = Brushes.Red;
            }
            if (String.IsNullOrEmpty(tbCodeBarreM.Text))
            {
                tbCodeBarreM.BorderBrush = Brushes.Red;
            }

            bool verif;
            // On vérifie que les champs ne soient pas vides
            if (!String.IsNullOrEmpty(tbCategorieM.Text) && !String.IsNullOrEmpty(tbNomM.Text) && !String.IsNullOrEmpty(tbRefConstM.Text) && !String.IsNullOrEmpty(tbCodeBarreM.Text))
            {
                verif = true;
                // On vérifie que chauqe champ ne dépasse pas le charcter varying de la base
                if(!Util.HasTheGoodLength(tbCategorieM.Text, 50) || !Util.HasTheGoodLength(tbNomM.Text, 100) || !Util.HasTheGoodLength(tbRefConstM.Text, 100) || !Util.HasTheGoodLength(tbCodeBarreM.Text, 100))
                {
                    verif = false;
                }
            }
            else verif = false;


            if (verif)
            {
                // On crée le nouvel objet matériel
                Materiel m = new Materiel(Util.ConvertToOneUpperCase(tbCategorieM.Text), tbNomM.Text, tbRefConstM.Text, tbCodeBarreM.Text);

                // On ajoute le nouveau matériel dans la BDD
                m.Create();
                applicationData.LesMateriels.Add(m);
                applicationData.LesMateriels.Last().FindAll(); // tentative d'actualisation

                // On reset les champs
                ResetChamp();

                
            }
           
        }

        private void lModifer_Click(object sender, RoutedEventArgs e)
        {
            if (!TailleChampCorrect())
            {
                ((Button)sender).Background = Brushes.LightPink;
                return;
            }

            Materiel m = applicationData.LesMateriels[dgMateriel.SelectedIndex];

            // Si le champ est nul, on ne le modifie pas
            m.Nom = tbNomM.Text == "" ? m.Nom : tbNomM.Text;
            m.RefConstructeur = tbRefConstM.Text == "" ? m.RefConstructeur : tbRefConstM.Text;
            m.CodeBarre = tbCodeBarreM.Text == "" ? m.CodeBarre : tbCodeBarreM.Text;
            m.Categorie = tbCategorieM.Text == "" ? m.Categorie : applicationData.LesCategories.ToList().Find(x => x.Nom == tbCategorieM.Text);

            dgMateriel.Items.Refresh();
            m.Update();
            applicationData.LesCategories.Last().FindAll(); // tentative d'actualisation

            ((Button)sender).Background = Util.GetBaseColor();

        }

        private void lSupprimer_Click(object sender, RoutedEventArgs e)
        {
            if (Util.ShowMessageBoxSupp(applicationData, dgMateriel))
            {
                Materiel m = applicationData.LesMateriels[dgMateriel.SelectedIndex];
                applicationData.LesMateriels.Remove(m);
                dgMateriel.Items.Refresh();
                m.Delete();
            }     
        }

        // On reset les champs
        private void ResetChamp()
        {
            tbCategorieM.Text = "";
            tbCodeBarreM.Text = "";
            tbNomM.Text = "";
            tbRefConstM.Text = "";
        }

        private bool AreChampCorrect()
        {
            bool verif;

            // On vérifie que les champs ne soient pas vides
            if (!String.IsNullOrEmpty(tbCategorieM.Text) && !String.IsNullOrEmpty(tbNomM.Text) && !String.IsNullOrEmpty(tbRefConstM.Text) && !String.IsNullOrEmpty(tbCodeBarreM.Text))
            {
                // On vérifie que chaque champ ne dépasse pas le charcter varying de la base
                verif = TailleChampCorrect();
            }
            else verif = false;

            return verif;
        }

        private bool TailleChampCorrect()
        {
            if (!Util.HasTheGoodLength(tbCategorieM.Text, 50) || !Util.HasTheGoodLength(tbNomM.Text, 100) || !Util.HasTheGoodLength(tbRefConstM.Text, 100) || !Util.HasTheGoodLength(tbCodeBarreM.Text, 100))
            {
                return false;
            }
            else return true;
        }
    }
}
