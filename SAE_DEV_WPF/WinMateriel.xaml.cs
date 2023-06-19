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

            ChangeColorChampVide();

            if (AreChampCorrectEtNonVide())
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

            if (materielEstSelectionne())
            {
                Materiel m = applicationData.LesMateriels[dgMateriel.SelectedIndex];

                // Si le champ est nul, on ne le modifie pas
                m.Nom = tbNomM.Text == "" ? m.Nom : tbNomM.Text;
                m.RefConstructeur = tbRefConstM.Text == "" ? m.RefConstructeur : tbRefConstM.Text;
                m.CodeBarre = tbCodeBarreM.Text == "" ? m.CodeBarre : tbCodeBarreM.Text;
                m.Categorie = tbCategorieM.Text == "" ? m.Categorie : applicationData.LesCategories.ToList().Find(x => x.Nom == tbCategorieM.Text);

            dgMateriel.Items.Refresh();
            m.Update();
            applicationData.LesMateriels.Last().FindAll(); // tentative d'actualisation

                ((Button)sender).Background = Util.GetBaseColor();
            }
            

        }

        private void lSupprimer_Click(object sender, RoutedEventArgs e)
        {
            if (materielEstSelectionne())
            {
                if (Util.ShowMessageBoxSupp(applicationData, dgMateriel))
                {
                    Materiel m = applicationData.LesMateriels[dgMateriel.SelectedIndex];
                    applicationData.LesMateriels.Remove(m);
                    dgMateriel.Items.Refresh();
                    m.Delete();
                }
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

        private bool AreChampCorrectEtNonVide()
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

        //On vérifie la taille des champs
        private bool TailleChampCorrect()
        {
            if (!Util.HasTheGoodLength(tbNomM.Text, 100) || !Util.HasTheGoodLength(tbRefConstM.Text, 100) || !Util.HasTheGoodLength(tbCodeBarreM.Text, 100))
            {
                return false;
            }
            else return true;
        }

        //On vérifie si un matériel est sélectionné
        private bool materielEstSelectionne()
        {
            if (dgMateriel.SelectedIndex == -1)
            {
                MessageBoxResult mes = MessageBox.Show("Vous devez sélectionner un matériel.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else return true;
        }

        private void ChangeColorChampVide()
        {
            List<TextBox> lesTextBox = new List<TextBox>();
            lesTextBox.Add(tbNomM);
            lesTextBox.Add(tbRefConstM);
            lesTextBox.Add(tbCodeBarreM);

            foreach(TextBox tb in lesTextBox)
            {
                if (String.IsNullOrEmpty(tb.Text))
                {
                    tb.BorderBrush = Brushes.Red;
                }
            }
            tbCategorieM.BorderBrush= Brushes.Red;
        }
    }
}
