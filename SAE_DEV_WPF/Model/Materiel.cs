/***********************************************************************
 * Module:  Materiel.cs
 * Author:  clercreh
 * Purpose: Definition of the Class Materiel
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;

namespace SAE_DEV_WPF.Model
{
    public class Materiel : Crud<Materiel>
    {
        public static ApplicationData Ad;
        private String refConstructeur, nom, codeBarre;
        private Categorie categorie;

        private int id; /*, fk_categorie;*/

        public Materiel() { }

        public Materiel(int id, string codeBarre, string refConstructeur, string nom, Categorie c) // Constructeur pour INSERT & FindAll
        {
            this.Id = id;
            this.CodeBarre = codeBarre;
            this.RefConstructeur = refConstructeur;
            this.Nom = nom;
            //this.Ad = ad;
            this.Categorie = c;
            //this.CatName = categorieName;
        }

        public Materiel(string catFormate, string nomMat, string refConst, string codeBarre) // Constructeur pour CREATE
        {
            this.CodeBarre = codeBarre;
            this.RefConstructeur = refConst;
            this.Nom = nomMat;
            this.Categorie = Ad.LesCategories.ToList().Find(x => x.Nom == catFormate);
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

        public void Create()
        {
            DataAccess accesBD = new DataAccess();
            DataTable datas;
            String requeteSelect, requeteInsert;

            /* On définit l'id de la categorie à partir de son nom
            requeteSelect = $"select idcategorie from categorie_materiel where nomcategorie = '{Categorie.Nom}';";
            datas = accesBD.GetData(requeteSelect);
            Fk_categorie = int.Parse(datas.Rows[0]["idcategorie"].ToString());
            */

            // On définit l'ID du materiel
            requeteSelect = "SELECT nextval('materiel_idmateriel_seq'::regclass);";
            datas = accesBD.GetData(requeteSelect);
            Id = int.Parse(datas.Rows[0][0].ToString());

            // INSERT 
            requeteInsert = $"INSERT INTO materiel (idcategorie, nommateriel, referenceconstructeurmateriel, codebarreinventaire) VALUES({Categorie.Id}, '{Nom}', '{RefConstructeur}', '{CodeBarre}'); ";
            accesBD.SetData(requeteInsert);
        }

        public void Delete()
        {
            DataAccess accesBD = new DataAccess();
            string requeteDelete;

            // DELETE
            requeteDelete = $"DELETE FROM materiel WHERE idmateriel = {Id};";
            accesBD.SetData(requeteDelete);
        }


        public ObservableCollection<Materiel> FindAll()
        {
            ObservableCollection<Materiel> lesMateriels = new ObservableCollection<Materiel>();
            DataAccess accesBD = new DataAccess();
            String requete = "select idmateriel, categorie_materiel.idcategorie, nommateriel, referenceconstructeurmateriel, codebarreinventaire from materiel " +
                "join categorie_materiel on categorie_materiel.idcategorie = materiel.idcategorie;";
            DataTable datas = accesBD.GetData(requete);
            if (datas != null)
            {
                foreach (DataRow row in datas.Rows)
                {
                    Categorie = Ad.LesCategories.ToList().Find(x => x.Id == int.Parse(row["idcategorie"].ToString()));
                    Materiel e = new Materiel(int.Parse(row["idmateriel"].ToString()), (String)row["codebarreinventaire"], (String)row["referenceconstructeurmateriel"], (String)row["nommateriel"], Categorie);
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
            DataAccess accesBD = new DataAccess();
            String requeteUpdate;

            // requete UPDATE 
            requeteUpdate = $"UPDATE materiel SET nommateriel = '{Nom}' , referenceconstructeurmateriel = '{RefConstructeur}' , codebarinventaire = '{CodeBarre}' , idcategorie {Categorie.Id} WHERE idmateriel = {Id};";
            accesBD.SetData(requeteUpdate);
        }
    }
}
