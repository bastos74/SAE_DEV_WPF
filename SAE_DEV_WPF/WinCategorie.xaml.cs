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
            if (!String.IsNullOrEmpty(tbNomC.Text))
            {
                // On crée le nouvel objet matériel
                Categorie c = new Categorie(Util.ConvertToOneUpperCase(tbNomC.Text));

                // On ajoute le nouveau matériel dans la BDD
                c.Create();
                applicationData.LesCategories.Add(c);
                applicationData.LesCategories.Last().FindAll(); // tentative d'actualisation

                // On reset les champs
                tbNomC.Text = "";

                ((Button)sender).Background = Util.GetBaseColor();

            }
            else ((Button)sender).Background = Brushes.LightPink;
        }

        private void btModifier_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btSupprimer_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
