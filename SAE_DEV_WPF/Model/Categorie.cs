/***********************************************************************
 * Module:  Categorie.cs
 * Author:  clercreh
 * Purpose: Definition of the Class Categorie
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using System.Data;

namespace SAE_DEV_WPF.Model
{
    public class Categorie : Crud<Categorie>
    {
        private string nom;

        private int id;

        public Categorie(){}

        public Categorie(int id, string nom)
        {
            this.Id = id;
            this.Nom = nom;
        }

        public Categorie(string nom) //Constructeur pour insert
        {
            this.Nom = nom;
        }

        //public Categorie(int id, string nom) : this(id, nom, new ObservableCollection<Materiel>()){}

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

            
            // On définit l'ID de la categorie
            requeteSelect = "SELECT nextval('categorie_materiel_idcategorie_seq'::regclass);";
            datas = accesBD.GetData(requeteSelect);
            Id = int.Parse(datas.Rows[0][0].ToString());

            // INSERT -- Faire refactor sans insérer l'id
            requeteInsert = $"INSERT INTO categorie_materiel (nomcategorie) VALUES('{Nom}'); ";
            accesBD.SetData(requeteInsert);

            
        }

        public void Read()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            DataAccess accesBD = new DataAccess();
            String requeteUpdate ;

            // requete UPDATE 
            requeteUpdate = $"UPDATE categorie_materiel SET nomcategorie = '{Nom}' WHERE idcategorie = {Id};";
            accesBD.SetData(requeteUpdate);

        }

        public void Delete()
        {
            DataAccess accesBD = new DataAccess();
            string requeteDelete;

            // DELETE
            requeteDelete = $"DELETE FROM categorie_materiel WHERE idcategorie = {Id};";
            accesBD.SetData(requeteDelete);
        }

        public ObservableCollection<Categorie> FindAll()
        {
            ObservableCollection<Categorie> lesCategories = new ObservableCollection<Categorie>();
            DataAccess accesBD = new DataAccess();
            String requete = "select idcategorie, nomcategorie from categorie_materiel ;";
            DataTable datas = accesBD.GetData(requete);
            if (datas != null)
            {
                foreach (DataRow row in datas.Rows)
                {
                    Categorie e = new Categorie(int.Parse(row["idcategorie"].ToString()), (String)row["nomcategorie"]);
                    lesCategories.Add(e);
                }
            }
            return lesCategories;

           
        }

        public ObservableCollection<Categorie> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return this.Nom;
        }
    }
}

