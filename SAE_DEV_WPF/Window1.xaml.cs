﻿using SAE_DEV_WPF.Model;
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
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        WinMateriel winMat;
        WinPersonnel winPer;

        public Window1()
        {
            InitializeComponent();
            this.Show();

            // Initialisation des fenêtres
            winMat = new WinMateriel(this);
            winPer = new WinPersonnel(this);

            /*
            DataAccess accesBD = new DataAccess();
            bool res = accesBD.OpenConnection();
            MessageBox.Show("Résultat de la connexion : " + res);*/


            MainWindow fenetre = new MainWindow();
            fenetre.ShowDialog();

            if(fenetre.femer == true)
            {
                this.Close();
            }
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
    }
}
