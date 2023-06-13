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
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            //DataAccess accesBD = new DataAccess();
            //bool res = accesBD.OpenConnection();
            //MessageBox.Show("Résultat de la connexion : " + res);


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
    }
}
