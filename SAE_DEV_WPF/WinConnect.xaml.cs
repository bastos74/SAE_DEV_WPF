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
                tbIdentifiant.BorderBrush = Util.GetBaseColorTextBox();
                tbPassword.BorderBrush = Util.GetBaseColorTextBox();              

                
                if (String.IsNullOrEmpty(tbIdentifiant.Text))
                {
                    tbIdentifiant.BorderBrush = Brushes.Red;
                }
                if (String.IsNullOrEmpty(tbPassword.Password))
                {
                    tbPassword.BorderBrush = Brushes.Red;
                } 
                
                
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
