using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;


namespace SAE_DEV_WPF
{
    /// <summary>
    /// Logique d'interaction pour WindowCreer2.xaml
    /// </summary>
    public partial class WindowCreer2 : Window
    {
        TextBox tbCategorie = new TextBox();
        TextBox tbPersonnel = new TextBox();
        TextBox tbMateriel = new TextBox();
        TextBox tbAttribution = new TextBox();
        TextBox tbexemple1 = new TextBox();

        
        StackPanel stackPanelPersonnelHaut = new StackPanel();
        StackPanel stackPanelPersonnelBas = new StackPanel();
        StackPanel stackPanelMaterielHaut = new StackPanel();
        StackPanel stackPanelMaterielBas = new StackPanel();
        StackPanel stackPanelAttribution = new StackPanel();
        StackPanel stackPanelCategorieHaut = new StackPanel();
        StackPanel stackPanelCategorieBas = new StackPanel();

        TextBox textboxNomPerssonel = new TextBox();
        TextBox textboxPrenom = new TextBox(); 
        TextBox textboxEmail = new TextBox();
        TextBox textboxCodeBarre = new TextBox();
        TextBox textboxReferenceConstructeur = new TextBox();
        TextBox textboxNomMateriel = new TextBox();
        TextBox textboxNomCategorie = new TextBox();

        Label labelPersonnel = new Label();
        Label labelNomPerssonel = new Label();
        Label labelPrenom = new Label();
        Label labelEmail = new Label();
        Label labelMateriel= new Label();
        Label labelCodeBarre = new Label();
        Label labelReferenceConstructeur = new Label();
        Label labelNomMateriel = new Label();
        Label labelAtribution = new Label();
        Label labelCategorie = new Label();
        Label labelNomCategorie = new Label();


        DataGrid dataGridPersonnel = new DataGrid();
        DataGrid dataGridMateriel = new DataGrid();
        DataGrid dataGridAttribution = new DataGrid();
        DataGrid dataGriCategorie = new DataGrid();

        DataGridTextColumn column1Materiel = new DataGridTextColumn();
        DataGridTextColumn column2Materiel = new DataGridTextColumn();
        DataGridTextColumn column3Materiel = new DataGridTextColumn();
        DataGridTextColumn column1Perssonel = new DataGridTextColumn();
        DataGridTextColumn column2Perssonel = new DataGridTextColumn();
        DataGridTextColumn column3Perssonel = new DataGridTextColumn();
        DataGridTextColumn column1Categorie = new DataGridTextColumn();
        public WindowCreer2()
        {
            InitializeComponent();
            



        }

        private void cbitAttribution_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void cbitPersonnel_Selected(object sender, RoutedEventArgs e)
        {
            grid.Children.Remove(stackPanelPersonnelHaut);
            grid.Children.Remove(stackPanelPersonnelBas);

            grid.Children.Remove(stackPanelMaterielHaut);
            grid.Children.Remove(stackPanelMaterielBas);

            grid.Children.Remove(stackPanelCategorieHaut);
            grid.Children.Remove(stackPanelCategorieBas);

            dataGridPersonnel.Columns.Remove(column1Perssonel);
            dataGridPersonnel.Columns.Remove(column2Perssonel);
            dataGridPersonnel.Columns.Remove(column3Perssonel);

            stackPanelPersonnelHaut.Children.Remove(labelPersonnel);
            stackPanelPersonnelHaut.Children.Remove(dataGridPersonnel);
            
            stackPanelPersonnelBas.Children.Remove(labelNomPerssonel);
            stackPanelPersonnelBas.Children.Remove(textboxNomPerssonel);
            stackPanelPersonnelBas.Children.Remove(labelPrenom);
            stackPanelPersonnelBas.Children.Remove(textboxPrenom);
            stackPanelPersonnelBas.Children.Remove(labelEmail);
            stackPanelPersonnelBas.Children.Remove(textboxEmail);

            grid.Children.Remove(stackPanelPersonnelHaut);

            grid.Children.Remove(stackPanelPersonnelBas);


            // Création du StackPanel

            stackPanelPersonnelHaut.Margin = new Thickness(0, -136, 0, 0);
            Grid.SetRow(stackPanelPersonnelHaut, 0);

            Grid.SetRow(stackPanelPersonnelBas, 1);
            stackPanelPersonnelBas.Orientation = Orientation.Horizontal;

            // Création du Label

            labelPersonnel.Content = "Personnel";
            labelPersonnel.FontWeight = FontWeights.Bold;
            labelPersonnel.HorizontalAlignment = HorizontalAlignment.Center;
            labelPersonnel.Margin = new Thickness(55, 151, 0, 0);
            Grid.SetRow(labelPersonnel, 1);
            Grid.SetColumnSpan(labelPersonnel, 2);
            Grid.SetRowSpan(labelPersonnel, 2);
            labelPersonnel.Width = 130;

            // Création du DataGrid

            dataGridPersonnel.Margin = new Thickness(0, 24, 0, 0);
            dataGridPersonnel.VerticalAlignment = VerticalAlignment.Top;
            dataGridPersonnel.AutoGenerateColumns = false;
            Grid.SetColumnSpan(dataGridPersonnel, 2);

            // Création des colonnes du DataGrid
            //DataGridTextColumn column1 = new DataGridTextColumn();
            column1Perssonel.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column1Perssonel.Header = "Nom";
            dataGridPersonnel.Columns.Add(column1Perssonel);

            // DataGridTextColumn column2 = new DataGridTextColumn();
            column2Perssonel.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column2Perssonel.Header = "Prénom";
            dataGridPersonnel.Columns.Add(column2Perssonel);

            //DataGridTextColumn column3 = new DataGridTextColumn();
            column3Perssonel.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column3Perssonel.Header = "Email";
            dataGridPersonnel.Columns.Add(column3Perssonel);





            // Création du Label lbNom

            labelNomPerssonel.Name = "labelNomPerssonel";
            labelNomPerssonel.Content = "Nom";
            labelNomPerssonel.HorizontalAlignment = HorizontalAlignment.Left;
            Grid.SetRow(labelNomPerssonel, 1);
            labelNomPerssonel.VerticalAlignment = VerticalAlignment.Center;

            // Création du TextBox tbNom

            textboxNomPerssonel.Name = "tbNom";
            Grid.SetRow(textboxNomPerssonel, 1);
            textboxNomPerssonel.TextWrapping = TextWrapping.Wrap;
            textboxNomPerssonel.Text = "";
            textboxNomPerssonel.Width = 120;
            textboxNomPerssonel.VerticalAlignment = VerticalAlignment.Center;
            textboxNomPerssonel.HorizontalAlignment = HorizontalAlignment.Left;

            // Création du Label lbPrenom
            
            labelPrenom.Name = "labelPrenom";
            labelPrenom.Content = "Prénom";
            labelPrenom.HorizontalAlignment = HorizontalAlignment.Left;
            Grid.SetRow(labelPrenom, 1);
            labelPrenom.VerticalAlignment = VerticalAlignment.Center;
            labelPrenom.Margin = new Thickness(40, 0, 0, 0);

            // Création du TextBox tbPrenom
            
            textboxPrenom.Name = "tbPrenom";
            textboxPrenom.HorizontalAlignment = HorizontalAlignment.Left;
            Grid.SetRow(textboxPrenom, 1);
            textboxPrenom.TextWrapping = TextWrapping.Wrap;
            textboxPrenom.Text = "";
            textboxPrenom.VerticalAlignment = VerticalAlignment.Center;
            textboxPrenom.Width = 120;

            // Création du Label lbEmail
            
            labelEmail.Name = "labelEmail";
            labelEmail.Content = "Email";
            labelEmail.HorizontalAlignment = HorizontalAlignment.Left;
            Grid.SetRow(labelEmail, 1);
            labelEmail.VerticalAlignment = VerticalAlignment.Center;
            labelEmail.Margin = new Thickness(40, 0, 0, 0);

            // Création du TextBox tbEmail
            
            textboxEmail.Name = "tbEmail";
            textboxEmail.HorizontalAlignment = HorizontalAlignment.Left;
            Grid.SetRow(textboxEmail, 1);
            textboxEmail.TextWrapping = TextWrapping.Wrap;
            textboxEmail.Text = "";
            textboxEmail.VerticalAlignment = VerticalAlignment.Center;
            textboxEmail.Width = 120;
            textboxEmail.Margin = new Thickness(0, 0, 0, 0);

            // Ajout du Label et du DataGrid dans le StackPanel
            stackPanelPersonnelHaut.Children.Add(labelPersonnel);
            stackPanelPersonnelHaut.Children.Add(dataGridPersonnel);

            stackPanelPersonnelBas.Children.Add(labelNomPerssonel);
            stackPanelPersonnelBas.Children.Add(textboxNomPerssonel);
            stackPanelPersonnelBas.Children.Add(labelPrenom);
            stackPanelPersonnelBas.Children.Add(textboxPrenom);
            stackPanelPersonnelBas.Children.Add(labelEmail);
            stackPanelPersonnelBas.Children.Add(textboxEmail);

            // Ajout du StackPanel au Grid parent (votre grille)
            // grid est une référence à votre Grid parent
            grid.Children.Add(stackPanelPersonnelHaut);

            grid.Children.Add(stackPanelPersonnelBas);

        }

        private void cbitMateriel_Selected(object sender, RoutedEventArgs e)
        {
            grid.Children.Remove(stackPanelPersonnelHaut);
            grid.Children.Remove(stackPanelPersonnelBas);

            grid.Children.Remove(stackPanelMaterielHaut);
            grid.Children.Remove(stackPanelMaterielBas);

            grid.Children.Remove(stackPanelCategorieHaut);
            grid.Children.Remove(stackPanelCategorieBas);

            stackPanelMaterielHaut.Children.Remove(labelMateriel);
            stackPanelMaterielHaut.Children.Remove(dataGridMateriel);

            stackPanelMaterielBas.Children.Remove(labelCodeBarre);
            stackPanelMaterielBas.Children.Remove(textboxCodeBarre);
            stackPanelMaterielBas.Children.Remove(labelReferenceConstructeur);
            stackPanelMaterielBas.Children.Remove(textboxReferenceConstructeur);
            stackPanelMaterielBas.Children.Remove(labelNomMateriel);
            stackPanelMaterielBas.Children.Remove(textboxNomMateriel);


            dataGridMateriel.Columns.Remove(column1Materiel);
            dataGridMateriel.Columns.Remove(column2Materiel);
            dataGridMateriel.Columns.Remove(column3Materiel);


            // Création du StackPanel

            stackPanelMaterielHaut.Margin = new Thickness(0, -136, 0, 0);
            Grid.SetRow(stackPanelMaterielHaut, 0);

            Grid.SetRow(stackPanelMaterielBas, 1);
            stackPanelMaterielBas.Orientation = Orientation.Horizontal;

            // Création du Label

            labelMateriel.Content = "Matériel";
            labelMateriel.FontWeight = FontWeights.Bold;
            labelMateriel.HorizontalAlignment = HorizontalAlignment.Center;
            labelMateriel.Margin = new Thickness(55, 151, 0, 0);
            Grid.SetRow(labelMateriel, 1);
            Grid.SetColumnSpan(labelMateriel, 2);
            Grid.SetRowSpan(labelMateriel, 2);
            labelMateriel.Width = 130;

            // Création du DataGrid

            dataGridMateriel.Margin = new Thickness(0, 24, 0, 0);
            dataGridMateriel.VerticalAlignment = VerticalAlignment.Top;
            dataGridMateriel.AutoGenerateColumns = false;
            Grid.SetColumnSpan(dataGridMateriel, 2);

            // Création des colonnes du DataGrid

            column1Materiel.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column1Materiel.Header = "Code Barre";
            dataGridMateriel.Columns.Add(column1Materiel);


            column2Materiel.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column2Materiel.Header = "Reference Constructeur";
            dataGridMateriel.Columns.Add(column2Materiel);


            column3Materiel.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column3Materiel.Header = "Nom";
            dataGridMateriel.Columns.Add(column3Materiel);


            // Création du Label labelCodeBarre

            labelCodeBarre.Name = "labelCodeBarre";
            labelCodeBarre.Content = "Code Barre";
            labelCodeBarre.HorizontalAlignment = HorizontalAlignment.Left;
            Grid.SetRow(labelCodeBarre, 1);
            labelCodeBarre.VerticalAlignment = VerticalAlignment.Center;

            // Création du TextBox textboxCodeBarre

            textboxCodeBarre.Name = "textboxCodeBarre";
            Grid.SetRow(textboxCodeBarre, 1);
            textboxCodeBarre.TextWrapping = TextWrapping.Wrap;
            textboxCodeBarre.Text = "";
            textboxCodeBarre.Width = 100;
            textboxCodeBarre.VerticalAlignment = VerticalAlignment.Center;
            textboxCodeBarre.HorizontalAlignment = HorizontalAlignment.Left;

            // Création du Label labelReferenceConstructeur

            labelReferenceConstructeur.Name = "labelReferenceConstructeur";
            labelReferenceConstructeur.Content = "Reference Constructeur";
            labelReferenceConstructeur.HorizontalAlignment = HorizontalAlignment.Left;
            Grid.SetRow(labelReferenceConstructeur, 1);
            labelReferenceConstructeur.VerticalAlignment = VerticalAlignment.Center;
            labelReferenceConstructeur.Margin = new Thickness(20, 0, 0, 0);

            // Création du TextBox textboxReferenceConstructeur

            textboxReferenceConstructeur.Name = "textboxReferenceConstructeur";
            textboxReferenceConstructeur.HorizontalAlignment = HorizontalAlignment.Left;
            Grid.SetRow(textboxReferenceConstructeur, 1);
            textboxReferenceConstructeur.TextWrapping = TextWrapping.Wrap;
            textboxReferenceConstructeur.Text = "";
            textboxReferenceConstructeur.VerticalAlignment = VerticalAlignment.Center;
            textboxReferenceConstructeur.Width = 100;

            // Création du Label labelNomMateriel

            labelNomMateriel.Name = "labelNomMateriel";
            labelNomMateriel.Content = "Nom";
            labelNomMateriel.HorizontalAlignment = HorizontalAlignment.Left;
            Grid.SetRow(labelNomMateriel, 1);
            labelNomMateriel.VerticalAlignment = VerticalAlignment.Center;
            labelNomMateriel.Margin = new Thickness(20, 0, 0, 0);

            // Création du TextBox texteboxNomMateriel

            textboxNomMateriel.Name = "texteboxNomMateriel";
            textboxNomMateriel.HorizontalAlignment = HorizontalAlignment.Left;
            Grid.SetRow(textboxNomMateriel, 1);
            textboxNomMateriel.TextWrapping = TextWrapping.Wrap;
            textboxNomMateriel.Text = "";
            textboxNomMateriel.VerticalAlignment = VerticalAlignment.Center;
            textboxNomMateriel.Width = 100;
            textboxNomMateriel.Margin = new Thickness(0, 0, 0, 0);

            // Ajout du Label et du DataGrid dans le StackPanel
            stackPanelMaterielHaut.Children.Add(labelMateriel);
            stackPanelMaterielHaut.Children.Add(dataGridMateriel);

            stackPanelMaterielBas.Children.Add(labelCodeBarre);
            stackPanelMaterielBas.Children.Add(textboxCodeBarre);
            stackPanelMaterielBas.Children.Add(labelReferenceConstructeur);
            stackPanelMaterielBas.Children.Add(textboxReferenceConstructeur);
            stackPanelMaterielBas.Children.Add(labelNomMateriel);
            stackPanelMaterielBas.Children.Add(textboxNomMateriel);

            // Ajout du StackPanel au Grid parent (votre grille)
            // grid est une référence à votre Grid parent
            grid.Children.Add(stackPanelMaterielHaut);
            grid.Children.Add(stackPanelMaterielBas);

        }

        private void cbitCategorie_Selected(object sender, RoutedEventArgs e)
        {
            grid.Children.Remove(stackPanelPersonnelHaut);
            grid.Children.Remove(stackPanelPersonnelBas);

            grid.Children.Remove(stackPanelMaterielHaut);
            grid.Children.Remove(stackPanelMaterielBas);

            grid.Children.Remove(stackPanelCategorieHaut);
            grid.Children.Remove(stackPanelCategorieBas);

            stackPanelCategorieHaut.Children.Remove(labelCategorie);
            stackPanelCategorieHaut.Children.Remove(dataGriCategorie);

            stackPanelCategorieBas.Children.Remove(labelNomCategorie);
            stackPanelCategorieBas.Children.Remove(textboxNomCategorie);

            dataGriCategorie.Columns.Remove(column1Categorie);


            // Création du StackPanel


            Grid.SetRow(stackPanelCategorieHaut, 0);
            stackPanelCategorieHaut.Margin = new Thickness(0, -136, 0, 0);

            Grid.SetRow(stackPanelCategorieBas, 1);
            stackPanelCategorieBas.Orientation = Orientation.Horizontal;

            // Création du Label labelCategorie

            labelCategorie.Content = "Catégorie";
            labelCategorie.FontWeight = FontWeights.Bold;
            labelCategorie.HorizontalAlignment = HorizontalAlignment.Center;
            labelCategorie.Margin = new Thickness(55, 151, 0, 0);
            Grid.SetRow(labelCategorie, 1);
            Grid.SetColumnSpan(labelCategorie, 2);
            Grid.SetRowSpan(labelCategorie, 2);
            labelCategorie.Width = 130;

            // Création du DataGrid

            dataGriCategorie.Margin = new Thickness(0, 24, 0, 0);
            dataGriCategorie.VerticalAlignment = VerticalAlignment.Top;
            dataGriCategorie.AutoGenerateColumns = false;
            Grid.SetColumnSpan(dataGriCategorie, 2); ;

            // Création des colonnes du DataGrid

            column1Categorie.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column1Categorie.Header = "Nom";
            dataGriCategorie.Columns.Add(column1Categorie);

            // Création du Label labelNomCategorie
            labelNomCategorie.Name = "labelNomCategorie";
            labelNomCategorie.Content = "Nom";
            labelNomCategorie.HorizontalAlignment = HorizontalAlignment.Left;
            Grid.SetRow(labelNomCategorie, 1);
            labelNomCategorie.VerticalAlignment = VerticalAlignment.Center;
            labelNomCategorie.Margin = new Thickness(208, 0, 0, 0);

            // Création du TextBox textboxNomCategorie

            textboxNomCategorie.Name = "textboxNomCategorie";
            Grid.SetRow(textboxCodeBarre, 1);
            textboxNomCategorie.TextWrapping = TextWrapping.Wrap;
            textboxNomCategorie.Text = "";
            textboxNomCategorie.Width = 100;
            textboxNomCategorie.VerticalAlignment = VerticalAlignment.Center;
            textboxNomCategorie.HorizontalAlignment = HorizontalAlignment.Left;

            // Ajout des éléments au StackPanel
            stackPanelCategorieHaut.Children.Add(labelCategorie);
            stackPanelCategorieHaut.Children.Add(dataGriCategorie);

            stackPanelCategorieBas.Children.Add(labelNomCategorie);
            stackPanelCategorieBas.Children.Add(textboxNomCategorie);

            // Ajout du StackPanel à la grille parent (votre Grid)
            // grid est une référence à votre Grid parent
            grid.Children.Add(stackPanelCategorieHaut);
            grid.Children.Add(stackPanelCategorieBas);


        }
    }
    
}
