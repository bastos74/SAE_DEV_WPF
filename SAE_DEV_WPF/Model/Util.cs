using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SAE_DEV_WPF.Model
{
    public class Util
    {
        public static string ConvertToOneUpperCase(string txt)
        {
            return txt.Substring(0, 1).ToUpper() + txt.Substring(1).ToLower();
        }

        public static bool IsEmailFormat(string texte)
        {
            // Vérification basique de la structure de l'adresse e-mail en utilisant des opérations sur les chaînes de caractères

            int pArobase = texte.IndexOf('@');
            int pPoint = texte.LastIndexOf('.');

            // Vérifier qu'il y a un seul caractère @ et au moins un caractère après
            if (pArobase <= 0 || pArobase != texte.LastIndexOf('@') || pArobase >= texte.Length - 1)
                return false;

            // Vérifier qu'il y a un . après le caractère @ et qu'il y a au moins un caractère entre les deux
            if (pPoint <= pArobase || pPoint >= texte.Length - 1)
                return false;

            return true;
        }

        public static Brush GetBaseColor()
        {
            return new SolidColorBrush(Color.FromRgb(221, 221, 221));
        }
        public static Brush GetBaseColorTextBox()
        {
            return new SolidColorBrush(Color.FromRgb(171, 173, 179));
        }

        public static bool HasTheGoodLength(string text, int length)
        {
            return text.Length < length ? true : false;
        }

        public static bool ShowMessageBoxSupp(ApplicationData applicationData, DataGrid dg)
        {
            MessageBoxResult mes = MessageBox.Show("Voulez-vous vraiment supprimer", "Suppression", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (mes == MessageBoxResult.Yes)
            {
                return true;
            }
            else return false;
        }

    }
}
