/***********************************************************************
 * Module:  Attribution.cs
 * Author:  clercreh
 * Purpose: Definition of the Class Attribution
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using System.Data;
using System.IO.Packaging;
using System.Linq;
using System.Windows;

namespace SAE_DEV_WPF.Model
{
    public class Attribution : Crud<Attribution>
    {
        public static ApplicationData Ad;

        private Materiel materiel;
        private Personnel personnel;
        private DateTime date;
        private string commentaire;

        public Attribution() { }

        public Attribution(DateTime date, string commentaire, Materiel m, Personnel p)
        {
            //this.Id = id;
            this.Date = date;
            this.Commentaire = commentaire;
            this.Materiel = m;
            this.Personnel = p;
            //this.Nommateriel = nommateriel;
            //this.Nompersonnel = nompersonnel;
        }
        public Attribution(DateTime date, string commentaire, string nomMat, string nomPer) // Constructeur pour CREATE
        {
            this.Commentaire = commentaire;
            this.Date = date;
            this.Personnel = Ad.LesPersonnels.ToList().Find(x => x.Nom == nomPer);
            this.Materiel = Ad.LesMateriels.ToList().Find(x => x.Nom == nomMat);
        }

        public Materiel Materiel
        {
            get
            {
                return materiel;
            }

            set
            {
                materiel = value;
            }
        }

        public Personnel Personnel
        {
            get
            {
                return personnel;
            }

            set
            {
                personnel = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
            }
        }

        public string Commentaire
        {
            get
            {
                return commentaire;
            }

            set
            {
                commentaire = value;
            }
        }

        public void Create()
        {
            DataAccess accesBD = new DataAccess();
            DataTable datas;
            String requeteSelect, requeteInsert;

            // INSERT 
            requeteInsert = $"INSERT INTO est_attribue (idpersonnel, idmateriel, dateattribution, commentaireattribution) VALUES({Personnel.Id}, {Materiel.Id}, '{this.Date}', '{Commentaire}'); ";
            accesBD.SetData(requeteInsert);
        }

        public void Delete()
        {
            DataAccess accesBD = new DataAccess();
            string requete = $"DELETE FROM est_attribue WHERE idpersonnel = {this.Personnel.Id} and idmateriel = {this.Materiel.Id};";
            accesBD.SetData(requete);
        }

        public ObservableCollection<Attribution> FindAll()
        {
            ObservableCollection<Attribution> lesAttributions = new ObservableCollection<Attribution>();
            DataAccess accesBD = new DataAccess();
            String requete = "select dateattribution, commentaireattribution, materiel.idmateriel, personnel.idpersonnel from est_attribue " +
                "join materiel on est_attribue.idmateriel = materiel.idmateriel " +
                "join personnel on est_attribue.idpersonnel = personnel.idpersonnel ";
            DataTable datas = accesBD.GetData(requete);
            if (datas != null)
            {
                foreach (DataRow row in datas.Rows)
                {
                    Materiel = Ad.LesMateriels.ToList().Find(x => x.Id == int.Parse(row["idmateriel"].ToString()));
                    Personnel = Ad.LesPersonnels.ToList().Find(x => x.Id == int.Parse(row["idpersonnel"].ToString()));
                    Attribution e = new Attribution(DateTime.Parse(row["dateattribution"].ToString()), (String)row["commentaireattribution"], Materiel, Personnel);
                    lesAttributions.Add(e);
                }
            }
            return lesAttributions;
        }

        public ObservableCollection<Attribution> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }

        public void Read()
        {
            ObservableCollection<Attribution> lAttribution = new ObservableCollection<Attribution>();
            DataAccess accesBD = new DataAccess();
            String requete = $"select personnel.idpersonnel, materiel.idmateriel, dateattribution, commentaireattribution from est_attribue where personnel.idpersonnel = {Personnel.Id} and materiel.idmateriel = {Materiel.Id} and dateattribution = {Date};";
            DataTable datas = accesBD.GetData(requete);
        }

        public void Update()
        {
            DataAccess accesBD = new DataAccess();
            string requete = $"UPDATE est_attribue SET dateattribution = '{this.Date}', commentaireattribution = '{this.Commentaire}' WHERE idpersonnel = {this.Personnel.Id} and idmateriel = {this.Materiel.Id};";
            accesBD.SetData(requete);
        }
    }
}
