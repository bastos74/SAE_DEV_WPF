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
        private String refConstructeur, nom, codeBarre, catName;
        private Categorie categorie;

        private int id, fk_categorie;

        public Materiel() { }

        public Materiel(int id, String codeBarre, string refConstructeur, string nom, string categorieName)
        {
            this.Id = id;
            this.CodeBarre = codeBarre;
            this.RefConstructeur = refConstructeur;
            this.Nom = nom;
            this.CatName = categorieName;
        }

        public Materiel(string catFormate, string nomMat, string refConst, string codeBarre) // Constructeur pour INSERT
        {
            this.CodeBarre = codeBarre;
            this.RefConstructeur = refConst;
            this.Nom = nomMat;
            this.CatName = catFormate;
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

        public string CodeBarre
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

        public string CatName
        {
            get
            {
                return catName;
            }

            set
            {
                catName = value;
            }
        }

        public void Create()
        {
            DataAccess accesBD = new DataAccess();
            DataTable datas;
            String requeteSelect, requeteInsert;

            // On définit l'id de la categorie à partir de son nom
            requeteSelect = $"select * from categorie_materiel where nomcategorie = '{Categorie}';";
            datas = accesBD.GetData(requeteSelect);
            Fk_categorie = int.Parse(datas.Rows[0]["idcategorie"].ToString());

            // On définit l'ID du materiel
            requeteSelect = "nextval('materiel_idmateriel_seq'::regclass)";
            datas = accesBD.GetData(requeteSelect);
            Id = int.Parse(datas.Rows[0][0].ToString());

            // INSERT -- Faire refactor sans insérer l'id
            requeteInsert = $"INSERT INTO materiel (idmateriel, idcategorie, nommateriel, referenceconstructeurmateriel, codebarreinventaire) VALUES({Id}, {Fk_categorie}, '{Nom}', '{RefConstructeur}', '{CodeBarre}'); ";
            accesBD.SetData(requeteInsert);       
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        
        public ObservableCollection<Materiel> FindAll()
        {   
            ObservableCollection<Materiel> lesMateriels = new ObservableCollection<Materiel>();
            DataAccess accesBD = new DataAccess();
            String requete = "select idmateriel, categorie_materiel.idcategorie, nommateriel, referenceconstructeurmateriel, codebarreinventaire, categorie_materiel.nomcategorie from materiel " +
                "join categorie_materiel on categorie_materiel.idcategorie = materiel.idcategorie;";
            DataTable datas = accesBD.GetData(requete);
            if (datas != null)
            {
                foreach (DataRow row in datas.Rows)
                {
                    Materiel e = new Materiel(int.Parse(row["idmateriel"].ToString()) , (String)row["codebarreinventaire"], (String)row["referenceconstructeurmateriel"], (String)row["nommateriel"], (String)row["nomcategorie"]);
                    lesMateriels.Add(e);
                }
            }
            return lesMateriels;
                    
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
