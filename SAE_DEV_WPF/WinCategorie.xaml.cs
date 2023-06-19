using SAE_DEV_WPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// Logique d'interaction pour WinCategorie.xaml
    /// </summary>
    public partial class WinCategorie : Window
    {
        public WinCategorie(WinAttribution owner)
        {
            this.Owner = owner;
            this.DataContext = owner.DataContext; // On assigne notre DataContext à cette fenêtre, à faire avant l'initialisation

            InitializeComponent();

            dgCategorie.Items.Refresh();
        }

        private void btAjouter_Click(object sender, RoutedEventArgs e)
        {
            tbNomC.BorderBrush = Util.GetBaseColorTextBox();

            ChangeColorChampVide();

            if (AreChampCorrectEtNonVide())
            {
                // On crée le nouvel objet matériel
                Categorie c = new Categorie(Util.ConvertToOneUpperCase(tbNomC.Text));

                // On vérifie s'il n'existe pas déjà
                if (applicationData.LesCategories.ToList().Find(x => x.Nom == tbNomC.Text) != null)
                {
                    tbNomC.BorderBrush = Brushes.Red;
                    return;
                } 

                // On ajoute le nouveau matériel dans la BDD
                c.Create();
                applicationData.LesCategories.Add(c);
                //applicationData.LesCategories.Last().FindAll(); // tentative d'actualisation

                // On reset les champs
                ResetChamp();

            }
            
                
        }

        private void btModifier_Click(object sender, RoutedEventArgs e)
        {
            if (!TailleChampCorrect())
            {
                ((Button)sender).Background = Brushes.LightPink;
                return;
            }



            if (categorieEstSelectionne())
            {
                Categorie c = applicationData.LesCategories[dgCategorie.SelectedIndex];

                // Si le champ est nul, on ne le modifie pas
                c.Nom = tbNomC.Text == "" ? c.Nom : tbNomC.Text;

                dgCategorie.Items.Refresh();
                c.Update();
                applicationData.LesCategories.Last().FindAll(); // tentative d'actualisation

                ((Button)sender).Background = Util.GetBaseColor();
            }
           


        }

        private void btSupprimer_Click(object sender, RoutedEventArgs e)
        {
            if (categorieEstSelectionne())
            {
                if (Util.ShowMessageBoxSupp(applicationData, dgCategorie))
                {
                    Categorie c = applicationData.LesCategories[dgCategorie.SelectedIndex];
                    applicationData.LesCategories.Remove(c);
                    dgCategorie.Items.Refresh();
                    c.Delete();
                }
            }
           
        }

        // On reset les champs
        private void ResetChamp()
        {
            tbNomC.Text = "";
        }

        private bool AreChampCorrectEtNonVide()
        {
            bool verif;

            // On vérifie que les champs ne soient pas vides
            if (!String.IsNullOrEmpty(tbNomC.Text))
            {
                // On vérifie que chaque champ ne dépasse pas le charcter varying de la base
                verif = TailleChampCorrect();
            }
            else verif = false;

            return verif;
        }

        //On vérifie la taille des champs
        private bool TailleChampCorrect()
        {
            if (!Util.HasTheGoodLength(tbNomC.Text, 50))
            {
                return false;
            }
            else return true;
        }

        //On vérifie si une catégorie est sélectionné
        private bool categorieEstSelectionne()
        {
            if (dgCategorie.SelectedIndex == -1)
            {
                MessageBoxResult mes = MessageBox.Show("Vous devez sélectionner une catégorie.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else return true;
        }

        private void ChangeColorChampVide()
        {
            if (String.IsNullOrEmpty(tbNomC.Text))
            {
                tbNomC.BorderBrush = Brushes.Red;
            }
        }
    }
}
