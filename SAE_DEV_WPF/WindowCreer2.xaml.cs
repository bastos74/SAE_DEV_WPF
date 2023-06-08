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

        StackPanel stackPanelCategorie = new StackPanel();
        StackPanel stackPanelPersonnelHaut = new StackPanel();
        StackPanel stackPanelPersonnelBas = new StackPanel();
        StackPanel stackPanelMateriel = new StackPanel();
        StackPanel stackPanelAttribution = new StackPanel();


        Label labelCategorie = new Label();
        Label labelPersonnel = new Label();
        Label labelMateriel= new Label();
        Label labelAtribution = new Label();

        DataGrid dataGriCategorie = new DataGrid();
        DataGrid dataGridPersonnel = new DataGrid();
        DataGrid dataGridMateriel = new DataGrid();
        DataGrid dataGridAttribution = new DataGrid();

        DataGridTextColumn column1 = new DataGridTextColumn();
        DataGridTextColumn column2 = new DataGridTextColumn();
        DataGridTextColumn column3 = new DataGridTextColumn();
        public WindowCreer2()
        {
            InitializeComponent();
            



        }

        private void cbitAttribution_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void cbitPersonnel_Selected(object sender, RoutedEventArgs e)
        {
            grid.Children.Remove(stackPanelMateriel);


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
            DataGridTextColumn column1 = new DataGridTextColumn();
            column1.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column1.Header = "Nom";
            dataGridPersonnel.Columns.Add(column1);

            DataGridTextColumn column2 = new DataGridTextColumn();
            column2.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column2.Header = "Prénom";
            dataGridPersonnel.Columns.Add(column2);

            DataGridTextColumn column3 = new DataGridTextColumn();
            column3.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column3.Header = "Email";
            dataGridPersonnel.Columns.Add(column3);





            // Création du Label lbNom
            Label lbNom = new Label();
            lbNom.Name = "lbNom";
            lbNom.Content = "Nom";
            lbNom.HorizontalAlignment = HorizontalAlignment.Left;
            Grid.SetRow(lbNom, 1);
            lbNom.VerticalAlignment = VerticalAlignment.Center;

            // Création du TextBox tbNom
            TextBox tbNom = new TextBox();
            tbNom.Name = "tbNom";
            Grid.SetRow(tbNom, 1);
            tbNom.TextWrapping = TextWrapping.Wrap;
            tbNom.Text = "";
            tbNom.Width = 120;
            tbNom.VerticalAlignment = VerticalAlignment.Center;
            tbNom.HorizontalAlignment = HorizontalAlignment.Left;

            // Création du Label lbPrenom
            Label lbPrenom = new Label();
            lbPrenom.Name = "lbPrenom";
            lbPrenom.Content = "Prénom";
            lbPrenom.HorizontalAlignment = HorizontalAlignment.Left;
            Grid.SetRow(lbPrenom, 1);
            lbPrenom.VerticalAlignment = VerticalAlignment.Center;
            lbPrenom.Margin = new Thickness(50, 0, 0, 0);

            // Création du TextBox tbPrenom
            TextBox tbPrenom = new TextBox();
            tbPrenom.Name = "tbPrenom";
            tbPrenom.HorizontalAlignment = HorizontalAlignment.Left;
            Grid.SetRow(tbPrenom, 1);
            tbPrenom.TextWrapping = TextWrapping.Wrap;
            tbPrenom.Text = "";
            tbPrenom.VerticalAlignment = VerticalAlignment.Center;
            tbPrenom.Width = 120;

            // Création du Label lbEmail
            Label lbEmail = new Label();
            lbEmail.Name = "lbEmail";
            lbEmail.Content = "Email";
            lbEmail.HorizontalAlignment = HorizontalAlignment.Left;
            Grid.SetRow(lbEmail, 1);
            lbEmail.VerticalAlignment = VerticalAlignment.Center;
            lbEmail.Margin = new Thickness(50, 0, 0, 0);

            // Création du TextBox tbEmail
            TextBox tbEmail = new TextBox();
            tbEmail.Name = "tbEmail";
            tbEmail.HorizontalAlignment = HorizontalAlignment.Left;
            Grid.SetRow(tbEmail, 1);
            tbEmail.TextWrapping = TextWrapping.Wrap;
            tbEmail.Text = "";
            tbEmail.VerticalAlignment = VerticalAlignment.Center;
            tbEmail.Width = 120;
            tbEmail.Margin = new Thickness(0, 0, 0, 0);

            // Ajout du Label et du DataGrid dans le StackPanel
            stackPanelPersonnelHaut.Children.Add(labelPersonnel);
            stackPanelPersonnelHaut.Children.Add(dataGridPersonnel);

            stackPanelPersonnelBas.Children.Add(lbNom);
            stackPanelPersonnelBas.Children.Add(tbNom);
            stackPanelPersonnelBas.Children.Add(lbPrenom);
            stackPanelPersonnelBas.Children.Add(tbPrenom);
            stackPanelPersonnelBas.Children.Add(lbEmail);
            stackPanelPersonnelBas.Children.Add(tbEmail);

            // Ajout du StackPanel au Grid parent (votre grille)
            // grid est une référence à votre Grid parent
            grid.Children.Add(stackPanelPersonnelHaut);

            grid.Children.Add(stackPanelPersonnelBas);

        }

        private void cbitMateriel_Selected(object sender, RoutedEventArgs e)
        {
            grid.Children.Remove(stackPanelPersonnelHaut);
            grid.Children.Remove(stackPanelPersonnelBas);

            grid.Children.Remove(stackPanelMateriel);
            stackPanelMateriel.Children.Remove(labelMateriel);
            stackPanelMateriel.Children.Remove(dataGridMateriel);

            dataGridMateriel.Columns.Remove(column1);
            dataGridMateriel.Columns.Remove(column2);
            dataGridMateriel.Columns.Remove(column3);


            // Création du StackPanel

            stackPanelMateriel.Margin = new Thickness(0, -136, 0, 137);
            Grid.SetRow(stackPanelMateriel, 0);

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
           
            column1.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column1.Header = "Code Barre";
            dataGridMateriel.Columns.Add(column1);

           
            column2.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column2.Header = "Reference Constructeur";
            dataGridMateriel.Columns.Add(column2);

            
            column3.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column3.Header = "Nom";
            dataGridMateriel.Columns.Add(column3);

            // Ajout du Label et du DataGrid dans le StackPanel
            stackPanelMateriel.Children.Add(labelMateriel);
            stackPanelMateriel.Children.Add(dataGridMateriel);

            // Ajout du StackPanel au Grid parent (votre grille)
            // grid est une référence à votre Grid parent
            grid.Children.Add(stackPanelMateriel);






            /*tbexemple1.Text = "Exemple";
            tbexemple1.FontSize = 16;
            tbexemple1.HorizontalAlignment = HorizontalAlignment.Center;
            tbexemple1.VerticalAlignment = VerticalAlignment.Center;
            tbexemple1.Width = 200;
            tbexemple1.Height = 100;
            Grid.SetRow(tbexemple1, 1);


            grid.Children.Add(tbexemple1);*/
            
        }

        private void cbitCategorie_Selected(object sender, RoutedEventArgs e)
        {          
            

            TextBox tbexemple = new TextBox();
            tbexemple.Text = "Exemple";
            tbexemple.Width = 200;
            tbexemple.Height = 100;
            grid.Children.Add(tbexemple);
            
        }

        public void SupprimeElements(Label label, TextBox textbox)
        {
            grid.Children.Remove(label);
            label.ClearValue(Grid.RowProperty);
            label.ClearValue(Grid.ColumnProperty);
            label.ClearValue(ContentProperty);

            grid.Children.Remove(textbox);
            textbox.ClearValue(Grid.RowProperty);
            textbox.ClearValue(Grid.ColumnProperty);
            textbox.ClearValue(ContentProperty);
        }
    }
    
}
