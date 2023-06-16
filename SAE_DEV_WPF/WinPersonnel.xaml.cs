﻿using SAE_DEV_WPF.Model;
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

            if (!String.IsNullOrEmpty(tbEmailP.Text) && !String.IsNullOrEmpty(tbNomP.Text) && !String.IsNullOrEmpty(tbPrenomP.Text))
            {
                if (!Util.IsEmailFormat(tbEmailP.Text))
                {
                    ((Button)sender).Background = Brushes.LightPink;
                    return;
                }

                // On crée le nouvel objet Personnel 
                Personnel p = new Personnel(tbEmailP.Text, tbNomP.Text, tbPrenomP.Text);

                // On ajoute le nouveau matériel dans la BDD
                p.Create();
                applicationData.LesPersonnels.Add(p);
                applicationData.LesPersonnels.Last().FindAll(); // tentative d'actualisation

                // On reset les champs
                tbEmailP.Text = "";
                tbNomP.Text = "";
                tbPrenomP.Text = "";

                ((Button)sender).Background = Util.GetBaseColor();

            }
            else ((Button)sender).Background = Brushes.LightPink;

        }      

        private void btModifier_Click(object sender, RoutedEventArgs e)
        {
            Personnel p = applicationData.LesPersonnels[dgPersonnel.SelectedIndex];
            applicationData.LesPersonnels[dgPersonnel.SelectedIndex].Email = tbEmailP.Text;
            applicationData.LesPersonnels[dgPersonnel.SelectedIndex].Nom = tbNomP.Text;
            applicationData.LesPersonnels[dgPersonnel.SelectedIndex].Prenom = tbPrenomP.Text;
            dgPersonnel.Items.Refresh();
            p.Update();
            applicationData.LesCategories.Last().FindAll(); // tentative d'actualisation
        }

        private void btSupprimer_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mes = MessageBox.Show("voulez vous vraiment supprimer ", " suppression ", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (mes == MessageBoxResult.Yes)
            {
                Personnel p = applicationData.LesPersonnels[dgPersonnel.SelectedIndex];
                applicationData.LesPersonnels.Remove(p);
                dgPersonnel.Items.Refresh();
                p.Delete();
            }
               
        }
    }
}
