/***********************************************************************
 * Module:  Personnel.cs
 * Author:  clercreh
 * Purpose: Definition of the Class Personnel
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using System.Data;

namespace SAE_DEV_WPF.Model
{
    public class Personnel : Crud<Personnel>
    {
        private String email, nom, prenom;

        private int id;

        public Personnel() { }

        public Personnel(int id, string nom, string prenom, string email)
        {
            this.Id = id;
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

        public void Create()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Personnel> FindAll()
        {
            ObservableCollection<Personnel> lepersonnel = new ObservableCollection<Personnel>();
            DataAccess accesBD = new DataAccess();
            String requete = "select idpersonnel ,  emailpersonnel , nompersonnel , prenompersonnel from personnel;";
            DataTable datas = accesBD.GetData(requete);
            if (datas != null)
            {
                foreach (DataRow row in datas.Rows)
                {
                    Personnel p = new Personnel(int.Parse(row["idpersonnel"].ToString()), (String)row["emailpersonnel"], (String)row["nompersonnel"],(String)row["prenompersonnel"]);
                    lepersonnel.Add(p);
                }
            }
            return lepersonnel;
        }

        public ObservableCollection<Personnel> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }

        public void Read()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
