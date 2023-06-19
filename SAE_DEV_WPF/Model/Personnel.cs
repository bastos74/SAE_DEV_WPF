/***********************************************************************
 * Module:  Personnel.cs
 * Author:  clercreh
 * Purpose: Definition of the Class Personnel
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;

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


        // Constructeur pour INSERT 
        public Personnel( string nom, string prenom, string email)
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

        public void Create()
        {
            DataAccess accesBD = new DataAccess();
            DataTable datas;
            String requeteSelect, requeteInsert;
           

            // On définit l'ID du personnel
            requeteSelect = "select nextval('personnel_idpersonnel_seq'::regclass);";
            datas = accesBD.GetData(requeteSelect);
            Id = int.Parse(datas.Rows[0][0].ToString());

            // INSERT -- Faire refactor sans insérer l'id
            requeteInsert = $"INSERT INTO personnel (emailpersonnel , nompersonnel, prenompersonnel) VALUES('{Email}', '{Nom}', '{Prenom}'); ";
            accesBD.SetData(requeteInsert);
        }

        public void Delete()
        {
            DataAccess accesBD = new DataAccess();
            string requeteDelete;

            // DELETE
            requeteDelete = $"DELETE FROM personnel WHERE idpersonnel = {Id};";
            accesBD.SetData(requeteDelete);
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
                    Personnel p = new Personnel(int.Parse(row["idpersonnel"].ToString()), (String)row["nompersonnel"], (String)row["prenompersonnel"],(String)row["emailpersonnel"]);
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
            DataAccess accesBD = new DataAccess();
            String requeteUpdate;

            // requete UPDATE 
            requeteUpdate = $"UPDATE personnel SET emailpersonnel = '{Email}' , nompersonnel = '{Nom}' , prenompersonnel = '{Prenom}'  WHERE idpersonnel = {Id};";
            accesBD.SetData(requeteUpdate);
        }
    }
}
