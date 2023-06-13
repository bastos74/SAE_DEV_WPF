/***********************************************************************
 * Module:  Materiel.cs
 * Author:  clercreh
 * Purpose: Definition of the Class Materiel
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using System.Data;

namespace SAE_DEV_WPF.Model {
    public class Materiel : Crud<Materiel>
    {
        private long codeBarre;
        private String refConstructeur, nom;
        private Categorie categorie;

        private int id, fk_categorie;

        public Materiel() { }

        public Materiel(int id, long codeBarre, string refConstructeur, string nom)
        {
            this.Id = id;
            this.CodeBarre = codeBarre;
            this.RefConstructeur = refConstructeur;
            this.Nom = nom;
        }

        public long CodeBarre
        {
            get
            {
                return codeBarre;
            }

            set
            {
                codeBarre = value;
            }
        }

        public string RefConstructeur
        {
            get
            {
                return refConstructeur;
            }

            set
            {
                refConstructeur = value;
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

        public Categorie Categorie
        {
            get
            {
                return categorie;
            }

            set
            {
                categorie = value;
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

        public int Fk_categorie
        {
            get
            {
                return fk_categorie;
            }

            set
            {
                fk_categorie = value;
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

        
        public ObservableCollection<Materiel> FindAll()
        {   
            ObservableCollection<Materiel> lesEtudiants = new ObservableCollection<Materiel>();
            DataAccess accesBD = new DataAccess();
            String requete = "select idmateriel, idcategorie, nommateriel, referenceconstructeurmateriel, codebarreinventaire from materiel ;";
            DataTable datas = accesBD.GetData(requete);
            if (datas != null)
            {
                foreach (DataRow row in datas.Rows)
                {
                    Materiel e = new Materiel(int.Parse(row["idmateriel"].ToString()) ,long.Parse(row["codebarreinventaire"].ToString()), (String)row["referenceconstructeurmateriel"], (String)row["nommateriel"]);
                    lesEtudiants.Add(e);
                }
            }
            return lesEtudiants;
                    
            throw new NotImplementedException();
        }


        public ObservableCollection<Materiel> FindBySelection(string criteres)
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
