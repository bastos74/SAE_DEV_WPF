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
            InitializeComponent();
            this.Owner = owner;
        }

        private void lAjouter_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void lModifer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void lSupprimer_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
