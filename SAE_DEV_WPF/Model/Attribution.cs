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
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
