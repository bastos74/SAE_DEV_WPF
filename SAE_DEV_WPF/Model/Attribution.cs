/***********************************************************************
 * Module:  Attribution.cs
 * Author:  clercreh
 * Purpose: Definition of the Class Attribution
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using System.Data;
using System.IO.Packaging;

namespace SAE_DEV_WPF.Model
{
    public class Attribution : Crud<Attribution>
    {
        private Materiel materiel;
        private Personnel personnel;
        private DateTime date;
        private string commentaire;

        private int id, fk_materiel, fk_personnel;

        public Attribution() { }

        public Attribution(int id,  DateTime date, string commentaire , string nommateriel, string nompersonnel)
        {
            this.Id = id;
            //this.Materiel = materiel;
            //this.Personnel = personnel;
            this.Date = date;
            this.Commentaire = commentaire;
            this.Nommateriel = nommateriel;
            this.Nompersonnel = nompersonnel;
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

        public int Fk_materiel
        {
            get
            {
                return fk_materiel;
            }

            set
            {
                fk_materiel = value;
            }
        }

        public int Fk_personnel
        {
            get
            {
                return fk_personnel;
            }

            set
            {
                fk_personnel = value;
            }
        }

        public string Nommateriel { get => nommateriel; set => nommateriel = value; }
        public string Nompersonnel { get => nompersonnel; set => nompersonnel = value; }





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
            String requete = " select idattribution , dateattribution , commentaireattribution , nommateriel , nompersonel from attribution " +
                "  join personnel on     ";
            DataTable datas = accesBD.GetData(requete);
            if (datas != null)
            {
                foreach (DataRow row in datas.Rows)
                {
                    Attribution a = new Attribution(int.Parse(row["idattribution"].ToString()),  DateTime.Parse((String)row["dateattribution"]) ,(String)row["commentaireattribution"], (String)row["nommateriel"], (String)row["nompersonnel"]);
                    lesAttributions.Add(a);
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
