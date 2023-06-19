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

        private void btAjouter_Click(object sender, RoutedEventArgs e)
        {

            tbEmailP.BorderBrush = Util.GetBaseColorTextBox();
            tbNomP.BorderBrush = Util.GetBaseColorTextBox();
            tbPrenomP.BorderBrush = Util.GetBaseColorTextBox();

            ChangeColorChampVide();

            if (!Util.IsEmailFormat(tbEmailP.Text))
            {
                tbEmailP.BorderBrush = Brushes.Red;
            }

            if (AreChampCorrectEtNonVide())
            {
                // On crée le nouvel objet Personnel 
                Personnel p = new Personnel(tbNomP.Text, tbPrenomP.Text, tbEmailP.Text);

                // On ajoute le nouveau matériel dans la BDD
                p.Create();
                applicationData.LesPersonnels.Add(p);
                applicationData.LesPersonnels.Last().FindAll(); // tentative d'actualisation

                // On reset les champs
                ResetChamp();

                ((Button)sender).Background = Util.GetBaseColor();

            }           

        }      

        private void btModifier_Click(object sender, RoutedEventArgs e)
        {
            
            if (!TailleChampCorrect())
            {
                ((Button)sender).Background = Brushes.LightPink;
                return;
            }

            if (personnelEstSelectionne())
            {
                Personnel p = applicationData.LesPersonnels[dgPersonnel.SelectedIndex];

                // On modifie uniquement les champs ayant un texte
                p.Email = tbEmailP.Text == "" ? p.Email : tbEmailP.Text;
                p.Nom = tbNomP.Text == "" ? p.Nom : tbNomP.Text;
                p.Prenom = tbPrenomP.Text == "" ? p.Prenom : tbPrenomP.Text;

                dgPersonnel.Items.Refresh();
                p.Update();
                applicationData.LesCategories.Last().FindAll(); // tentative d'actualisation
            }
            
        }

        private void btSupprimer_Click(object sender, RoutedEventArgs e)
        {
            if (personnelEstSelectionne())
            {
                if (Util.ShowMessageBoxSupp(applicationData, dgPersonnel))
                {
                    Personnel p = applicationData.LesPersonnels[dgPersonnel.SelectedIndex];
                    applicationData.LesPersonnels.Remove(p);
                    dgPersonnel.Items.Refresh();
                    p.Delete();
                }
            }         

        }

        // On reset les champs
        private void ResetChamp()
        {
            tbEmailP.Text = "";
            tbNomP.Text = "";
            tbPrenomP.Text = "";
        }

        private bool AreChampCorrectEtNonVide()
        {
            bool verif;

            // On vérifie que les champs ne soient pas vides
            if (!String.IsNullOrEmpty(tbEmailP.Text) && !String.IsNullOrEmpty(tbNomP.Text) && !String.IsNullOrEmpty(tbPrenomP.Text))
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
            if (!Util.HasTheGoodLength(tbEmailP.Text, 30) || !Util.HasTheGoodLength(tbNomP.Text, 20) || !Util.HasTheGoodLength(tbPrenomP.Text, 20))
            {
                return false;
            }
            else return true;
        }

        //On vérifie si un personnel est sélectionné
        private bool personnelEstSelectionne()
        {
            if (dgPersonnel.SelectedIndex == -1)
            {
                MessageBoxResult mes = MessageBox.Show("Vous devez sélectionner un personnel.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else return true;
        }

        private void ChangeColorChampVide()
        {
            List<TextBox> lesTextBox = new List<TextBox>();
            lesTextBox.Add(tbEmailP);
            lesTextBox.Add(tbNomP);
            lesTextBox.Add(tbPrenomP);

            foreach (TextBox tb in lesTextBox)
            {
                if (String.IsNullOrEmpty(tb.Text))
                {
                    tb.BorderBrush = Brushes.Red;
                }
            }
        }
    }
}
