using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_DEV_WPF.Model
{
    public class Util
    {
        public static string ConvertToOneUpperCase(string txt)
        {
            return txt.Substring(0, 1).ToUpper() + txt.Substring(1).ToLower();
        }

        public bool IsEmailFormat(string input)
        {
            // Vérification basique de la structure de l'adresse e-mail en utilisant des opérations sur les chaînes de caractères

            if (string.IsNullOrEmpty(input))
                return false;

            int atIndex = input.IndexOf('@');
            int dotIndex = input.LastIndexOf('.');

            // Vérifier qu'il y a un seul caractère @ et au moins un caractère après
            if (atIndex <= 0 || atIndex != input.LastIndexOf('@') || atIndex >= input.Length - 1)
                return false;

            // Vérifier qu'il y a un caractère . après le caractère @ et qu'il y a au moins un caractère entre les deux
            if (dotIndex <= atIndex || dotIndex >= input.Length - 1)
                return false;

            return true;
        }

    }
}
