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

namespace lab_24_Customers_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        static List<Customer> customers;
        public MainWindow()
        {
            InitializeComponent();
            Initialise();
        }

        void Initialise()
        {
            StackPanel01.Visibility = Visibility.Visible;
            StackPanel02.Visibility = Visibility.Collapsed;
            StackPanel03.Visibility = Visibility.Collapsed;



            using(var db = new NorthwindEntities())
            {
                customers = db.Customers.ToList();
                ListBoxCustomers.ItemsSource = customers;
            }
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            if(StackPanel01.Visibility == Visibility.Visible)
            {
                StackPanel01.Visibility = Visibility.Collapsed;
                StackPanel02.Visibility = Visibility.Collapsed;
                StackPanel03.Visibility = Visibility.Visible;
            }
            else if (StackPanel02.Visibility == Visibility.Visible)
            {
                StackPanel01.Visibility = Visibility.Visible;
                StackPanel02.Visibility = Visibility.Collapsed;
                StackPanel03.Visibility = Visibility.Collapsed;
            }
            else if (StackPanel03.Visibility == Visibility.Visible)
            {
                StackPanel01.Visibility = Visibility.Collapsed;
                StackPanel02.Visibility = Visibility.Visible;
                StackPanel03.Visibility = Visibility.Collapsed;
            }
        }

        private void ButtonForward_Click(object sender, RoutedEventArgs e)
        {
            if (StackPanel01.Visibility == Visibility.Visible)
            {
                StackPanel01.Visibility = Visibility.Collapsed;
                StackPanel02.Visibility = Visibility.Visible;
                StackPanel03.Visibility = Visibility.Collapsed;
            }
            else if (StackPanel02.Visibility == Visibility.Visible)
            {
                StackPanel01.Visibility = Visibility.Collapsed;
                StackPanel02.Visibility = Visibility.Collapsed;
                StackPanel03.Visibility = Visibility.Visible;
            }
            else if (StackPanel03.Visibility == Visibility.Visible)
            {
                StackPanel01.Visibility = Visibility.Visible;
                StackPanel02.Visibility = Visibility.Collapsed;
                StackPanel03.Visibility = Visibility.Collapsed;
            }
        }

        private void CustomerSearch_KeyUp(object sender, KeyEventArgs e)
        {
            
            ListBoxCustomers.ItemsSource = customers.Where
                (c => c.ContactName.Contains(CustomerSearch.Text)).ToList(); 
        }

        private void ViewOrders(object sender, EventArgs e)
        {

        }
        private void CustomerSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ListBoxCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
