/***********************************************************************
 * Module:  Categorie.cs
 * Author:  clercreh
 * Purpose: Definition of the Class Categorie
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;

namespace SAE_DEV_WPF.Model
{
    public class Categorie : Crud<Categorie>
    {
        private string nom;
        private ObservableCollection<Materiel> lesMateriels;

        private int id;

        public Categorie(){}

        public Categorie(string nom, ObservableCollection<Materiel> lesMateriels)
        {
            this.Nom = nom;
            this.LesMateriels = lesMateriels;
        }

        public Categorie(string nom) : this(nom, new ObservableCollection<Materiel>()){}

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

        public ObservableCollection<Materiel> LesMateriels
        {
            get
            {
                return lesMateriels;
            }

            set
            {
                lesMateriels = value;
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

        public void Read()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Categorie> FindAll()
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Categorie> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }
    }
}

