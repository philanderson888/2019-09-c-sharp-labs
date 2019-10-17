using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab_18_Rabbit_Database_CRUD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        static List<Rabbit> rabbits;
        static Rabbit rabbit = new Rabbit();

        public MainWindow()
        {
            InitializeComponent();
            Initialise();
        }

        void Initialise()
        {

            // using : automatic clean-up ((C# does not know
            // inherently when we're done so this block help
            // C# know that we are done, and clean all memory
            using (var db = new RabbitDbEntities())
            {
                rabbits = db.Rabbits.ToList();
            }

            // MANUAL METHOD
            // Fancy 'lambda' to a) loop rabbits b) each loop, add item to listbox on screen
            // get the list of rabbits.  For each rabbit in the list of rabbits do the following
            // rabbits.ForEach(rabbit => ListBoxRabbits.Items.Add(rabbit));
            // foreach (var rabbit in rabbits){ ... ListBoxRabbits.Items.Add...}

            // BINDING METHOD : BIND LISTBOX TO DATABASE (BETTER)
            ListBoxRabbits.DisplayMemberPath = "Name";
            ListBoxRabbits.ItemsSource = rabbits;

            TextBoxAge.IsReadOnly = false;
            TextBoxName.IsReadOnly = true;

            ButtonEdit.IsEnabled = false;
            ButtonDelete.IsEnabled = false;

        }

        private void ListBoxRabbits_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // when deselect a rabbit, don't run this code
            // if(rabbit != null)  // or
            if(ListBoxRabbits.SelectedItem != null)
            {
                // whenever we select an item in the list, cast it from (Object) type 
                // and put it as a (Rabbit) type.  Put in the global 'rabbit' variable.
                rabbit = (Rabbit)ListBoxRabbits.SelectedItem;
                TextBoxName.Text = rabbit.Name;
                TextBoxAge.Text = rabbit.Age.ToString();
                // enable edit and delete
                ButtonEdit.IsEnabled = true;
                ButtonDelete.IsEnabled = true;
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (ButtonAdd.Content.Equals("Add")){
                ButtonAdd.Content = "Save";
                ButtonAdd.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#9589FF"));
                // clear boxes and set to white
                TextBoxName.Text = "";
                TextBoxAge.Text = "";
                TextBoxName.Background = (SolidColorBrush)Brushes.White;
                TextBoxAge.Background = (SolidColorBrush)Brushes.White;
                TextBoxName.IsReadOnly = false;
                TextBoxAge.IsReadOnly = false;
                ButtonEdit.IsEnabled = false;
                ButtonDelete.IsEnabled = false;
            }
            else
            {
                ButtonAdd.Content = "Add";
                ButtonAdd.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#B3C6ED"));
                TextBoxName.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#D3E9ED"));
                TextBoxAge.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#D3E9ED"));
                TextBoxName.IsReadOnly = true;
                TextBoxAge.IsReadOnly = true;
                // commit changes
                if ((TextBoxName.Text.Length > 0) && (TextBoxAge.Text.Length > 0))
                {
                    // get age
                    if(int.TryParse(TextBoxAge.Text,out int age)){
                        var RabbitToAdd = new Rabbit()
                        {
                            Name = TextBoxName.Text,
                            Age = age
                        };
                        // read db and add new rabbit
                        using (var db = new RabbitDbEntities())
                        {
                            db.Rabbits.Add(RabbitToAdd);
                            db.SaveChanges();
                            // update view
                            rabbit = null;

                            rabbits = db.Rabbits.ToList();
                            ListBoxRabbits.ItemsSource = null;
                            ListBoxRabbits.ItemsSource = rabbits;
                        }
                    }
                }
                
            }
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (ButtonEdit.Content.Equals("Edit"))
            {
                ButtonEdit.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#9589FF"));
                ButtonEdit.Content = "Save";
                TextBoxName.IsReadOnly = false;
                TextBoxAge.IsReadOnly = false;
                TextBoxName.Background = (SolidColorBrush)Brushes.White;
                TextBoxAge.Background = (SolidColorBrush)Brushes.White;
                ButtonAdd.IsEnabled = false;
                TextBoxName.Focus();
                TextBoxName.SelectAll();
            }
            else
            {
                Color color = (Color)ColorConverter.ConvertFromString("#B3C6ED");
                var brush = new SolidColorBrush(color);
                ButtonEdit.Background = brush;
                ButtonEdit.Content = "Edit";
                if ((TextBoxAge.Text.Length > 0) && (TextBoxName.Text.Length > 0))
                {
                    // must have selected a rabbit
                    if (rabbit != null)
                    {
                        rabbit.Name = TextBoxName.Text;
                        if(int.TryParse(TextBoxAge.Text, out int age))
                        {
                            rabbit.Age = age;
                        }

                        using (var db = new RabbitDbEntities())
                        {
                            // read rabbit from database by ID
                            var rabbitToUpdate = db.Rabbits.Find(rabbit.RabbitId);
                            // update rabbit
                            rabbitToUpdate.Name = rabbit.Name;
                            rabbitToUpdate.Age = rabbit.Age;
                            // save rabbit back to DB
                            db.SaveChanges();
                            // clear listbox because we're going to change (the binding)
                            rabbit = null;  // remove binding on rabbit
                           // ListBoxRabbits.ItemsSource = null;  // remove binding
                           // ListBoxRabbits.Items.Clear();       // clear it out
                            // repopulate listbox // re-read from db
                            rabbits = db.Rabbits.ToList();                // get rabbits
                            ListBoxRabbits.ItemsSource = rabbits;         // bind to listbox again

                        }

                    }
                }
                ButtonAdd.IsEnabled = true;
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (ButtonDelete.Content.Equals("Delete"))
            { 
                ButtonDelete.Content = "Confirm Delete";
            }
            else
            {
                // delete record
                // find record in database which matches selected rabbit
                if (rabbit != null)
                {
                    using (var db = new RabbitDbEntities())
                    {
                        var rabbitToDelete = db.Rabbits.Find(rabbit.RabbitId);
                        db.Rabbits.Remove(rabbitToDelete);
                        db.SaveChanges();

                        //ListBoxRabbits.ItemsSource = null;

                        rabbits = db.Rabbits.ToList();

                        ListBoxRabbits.ItemsSource = rabbits;
                    }
                }

                TextBoxName.Text = "";
                TextBoxAge.Text = "";

                ButtonDelete.IsEnabled = false;
                ButtonDelete.Content = "Delete";
            }
        }

        private void DoThis(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "A")
            {
                MessageBox.Show(e.Key.ToString());
            }
   
        }
    }
}
