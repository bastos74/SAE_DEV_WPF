/***********************************************************************
 * Module:  Attribution.cs
 * Author:  clercreh
 * Purpose: Definition of the Class Attribution
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;

namespace SAE_DEV_WPF.Model
{
    public class Attribution : Crud<Attribution>
    {
        private Materiel materiel;
        private Personnel personnel;
        private DateTime date;
        private string commentaire;

        public Attribution() { }

        public Attribution(Materiel materiel, Personnel personnel, DateTime date, string commentaire)
        {
            this.Materiel = materiel;
            this.Personnel = personnel;
            this.Date = date;
            this.Commentaire = commentaire;
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
            throw new NotImplementedException();
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
