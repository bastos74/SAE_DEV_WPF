using SAE_DEV_WPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class WinAttribution : Window
    {
        WinMateriel winMat;
        WinPersonnel winPer;
        WinCategorie winCat;

        public WinAttribution()
        {
            InitializeComponent();
            this.Show();

            // Initialisation des fenêtres
            winMat = new WinMateriel(this);
            winPer = new WinPersonnel(this);
            winCat = new WinCategorie(this);

            /*
            DataAccess accesBD = new DataAccess();
            bool res = accesBD.OpenConnection();
            MessageBox.Show("Résultat de la connexion : " + res);*/


            WinConnect fenetre = new WinConnect();
            fenetre.ShowDialog();

            if(fenetre.isClosed == true)
            {
                this.Close();
            }

            dgAttribution.Items.Refresh();
        }

        private void apropos_Click(object sender, RoutedEventArgs e)
        {
            aPropos fenetreApropos = new aPropos();
            fenetreApropos.ShowDialog();
        }

        private void miMateriel_Click(object sender, RoutedEventArgs e)
        {
            winMat = new WinMateriel(this);
            winMat.ShowDialog();
        }

        private void miPersonnel_Click(object sender, RoutedEventArgs e)
        {
            winPer = new WinPersonnel(this);
            winPer.ShowDialog();
        }

        private void miCategorie_Click(object sender, RoutedEventArgs e)
        {
            winCat = new WinCategorie(this);
            winCat.ShowDialog();
        }

        private void btAjouterA_Click(object sender, RoutedEventArgs e)
        {
            ChangeColorChampVide();

            if (AreChampCorrectEtNonVide())
            {
                //MessageBox.Show(tbMaterielA.SelectedItem.ToString() + " " + tbPersonnelA.SelectedItem.ToString());
                // On crée le nouvel objet matériel
                Attribution a = new Attribution(DateTime.Parse(tbDateA.Text), tbCommentaireA.Text, tbMaterielA.SelectedItem.ToString(), tbPersonnelA.SelectedItem.ToString());

                // On ajoute le nouveau matériel dans la BDD
                a.Create();
                applicationData.LesAttributions.Add(a);
                applicationData.LesAttributions.Last().FindAll(); // tentative d'actualisation
                dgAttribution.Items.Refresh();

                // On reset les champs
                ResetChamp();

            }
            dgAttribution.Items.Refresh();
        }

        private void btModiferA_Click(object sender, RoutedEventArgs e)
        {
            if (!TailleChampCorrect())
            {
                ((Button)sender).Background = Brushes.LightPink;
                return;
            }
            if(dgAttribution.SelectedIndex == -1)
            {
                return;
            }
            Attribution a = applicationData.LesAttributions[dgAttribution.SelectedIndex];

            // Si le champ est nul, on ne le modifie pas
            if (tbCommentaireA.Text != "") a.Commentaire = tbCommentaireA.Text;
            if (tbDateA.Text != "") a.Date = DateTime.Parse(tbDateA.Text);
            if (tbMaterielA.SelectedItem != null) a.Materiel = applicationData.LesMateriels.ToList().Find(x => x.Nom == tbMaterielA.SelectedItem.ToString());
            if (tbPersonnelA.SelectedItem != null) a.Personnel = applicationData.LesPersonnels.ToList().Find(x => x.Nom == tbPersonnelA.SelectedItem.ToString());

            a.Update();
            applicationData.LesAttributions.Last().FindAll(); // tentative d'actualisation
            dgAttribution.Items.Refresh();

            
            ((Button)sender).Background = Util.GetBaseColor();
        }

        private void btSupprimerA_Click(object sender, RoutedEventArgs e)
        {
            if (Util.ShowMessageBoxSupp(applicationData, dgAttribution))
            {
                Attribution a = applicationData.LesAttributions[dgAttribution.SelectedIndex];
                applicationData.LesAttributions.Remove(a);
                dgAttribution.Items.Refresh();
                a.Delete();
            }
        }

        // On reset les champs
        private void ResetChamp()
        {
            tbCommentaireA.BorderBrush = Util.GetBaseColorTextBox();
            tbDateA.BorderBrush = Util.GetBaseColorTextBox();
            tbMaterielA.BorderBrush = Util.GetBaseColorTextBox();
            tbPersonnelA.BorderBrush = Util.GetBaseColorTextBox();
            tbCommentaireA.Text = "";
            tbDateA.Text = "";
            tbMaterielA.SelectedIndex = -1;
            tbPersonnelA.SelectedIndex = -1;
        }

        private bool AreChampCorrectEtNonVide()
        {
            bool verif;

            // On vérifie que les champs ne soient pas vides
            if (!String.IsNullOrEmpty(tbCommentaireA.Text) && !String.IsNullOrEmpty(tbDateA.Text) && !String.IsNullOrEmpty(tbMaterielA.Text) && !String.IsNullOrEmpty(tbPersonnelA.Text))
            {
                // On vérifie que chaque champ ne dépasse pas le charcter varying de la base
                verif = TailleChampCorrect();
            }
            else verif = false;

            return verif;
        }

        private bool TailleChampCorrect()
        {
            if (!Util.HasTheGoodLength(tbCommentaireA.Text, 1000))
            {
                return false;
            }
            else return true;
        }

        private void ChangeColorChampVide()
        {
            tbDateA.BorderBrush = Brushes.Red;
            tbMaterielA.BorderBrush = Brushes.Red;
            tbPersonnelA.BorderBrush = Brushes.Red;
            tbCommentaireA.BorderBrush = Brushes.Red;
        }

        private void lvFiltreMat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dgAttribution.SetBinding(DataGrid.ItemsSourceProperty, new Binding("LesAttributions"));
            if (lvFiltreMat.SelectedItem != null)
            {
                applicationData.LesMaterielsFiltres = applicationData.LesAttributions.ToList().FindAll(x => x.Materiel.Nom == ((Materiel)lvFiltreMat.SelectedItem).Nom);
                dgAttribution.SetBinding(DataGrid.ItemsSourceProperty, new Binding("LesMaterielsFiltres"));
                dgAttribution.Items.Refresh();
            }
        }

        private void lvFiltreCat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dgAttribution.SetBinding(DataGrid.ItemsSourceProperty, new Binding("LesAttributions"));
            if (lvFiltreCat.SelectedItem != null)
            {
                applicationData.LesCategoriesFiltres = applicationData.LesAttributions.ToList().FindAll(x => x.Materiel.Categorie.Nom == ((Categorie)lvFiltreCat.SelectedItem).Nom);
                dgAttribution.SetBinding(DataGrid.ItemsSourceProperty, new Binding("LesCategoriesFiltres"));
                dgAttribution.Items.Refresh();
            }
        }

        private void lvFiltrePer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dgAttribution.SetBinding(DataGrid.ItemsSourceProperty, new Binding("LesAttributions"));
            if (lvFiltrePer.SelectedItem != null)
            {
                applicationData.LesPersonnelsFiltres = applicationData.LesAttributions.ToList().FindAll(x => x.Personnel.Nom == ((Personnel)lvFiltrePer.SelectedItem).Nom);
                dgAttribution.SetBinding(DataGrid.ItemsSourceProperty, new Binding("LesPersonnelsFiltres"));
                dgAttribution.Items.Refresh();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            lvFiltreCat.SelectedIndex = -1;
            lvFiltreMat.SelectedIndex = -1;
            lvFiltrePer.SelectedIndex = -1;
            dgAttribution.SetBinding(DataGrid.ItemsSourceProperty, new Binding("LesAttributions"));
        }

        private void lvFiltreCat_GotFocus(object sender, RoutedEventArgs e)
        {
            lvFiltreMat.SelectedIndex = -1;
            lvFiltrePer.SelectedIndex = -1;
        }

        private void lvFiltrePer_GotFocus(object sender, RoutedEventArgs e)
        {
            lvFiltreCat.SelectedIndex = -1;
            lvFiltreMat.SelectedIndex = -1;
        }

        private void lvFiltreMat_GotFocus(object sender, RoutedEventArgs e)
        {
            lvFiltreCat.SelectedIndex = -1;
            lvFiltrePer.SelectedIndex = -1;
        }
    }
}
