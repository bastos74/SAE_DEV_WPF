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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SAE_DEV_WPF
{
    /// <summary>
    /// Interaction logic for WinConnect.xaml
    /// </summary>
    public partial class WinConnect : Window
    {
       public bool isClosed = false;

        public WinConnect()
        {
            InitializeComponent();


        }

        private void btnSeConnecter_Click(object sender, RoutedEventArgs e)
        {
            if(tbIdentifiant.Text == "admin" && tbPassword.Password == "passwordadmin")
            {
                Close();
            }
            else
            {
                                
                if (!(tbIdentifiant.Text == "admin"))
                {
                    tbIdentifiant.BorderBrush = Brushes.Red;
                }
                if (!(tbPassword.Password == "passwordadmin"))
                {
                    tbPassword.BorderBrush = Brushes.Red;
                }
                tbIdentifiant.Text = "";
                tbPassword.Password = "";
            }          
            
        }

        private void btnFermer_Click(object sender, RoutedEventArgs e)
        {
            Close();
            isClosed= true;
        }
   
    
    
    
    }
}
