/***********************************************************************
 * Module:  Personnel.cs
 * Author:  clercreh
 * Purpose: Definition of the Class Personnel
 ***********************************************************************/

using System;

namespace SAE_DEV_WPF.Model
{
    public class Personnel
    {
        private String email, nom, prenom;

        private int id;

        public Personnel() { }

        public Personnel(string nom, string prenom, string email)
        {
            this.Email = email;
            this.Nom = nom;
            this.Prenom = prenom;
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public string Nom
        {
            get
            {
                return nom;
            }

            set
            {
                nom = value;
            }
        }

        public string Prenom
        {
            get
            {
                return prenom;
            }

            set
            {
                prenom = value;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }
    }
}
