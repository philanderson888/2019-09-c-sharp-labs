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
using System.Windows.Threading;

namespace lab_16_wpf_rabbit_explosion
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public DispatcherTimer timer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            Initialise();
        }

        void Initialise()
        {
            Button01.Content = "Click Here";
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Tick += changeColor;
            ImageRabbit.Visibility = Visibility.Visible;

        }

        void changeColor(object sender, EventArgs e)
        {
            var randomColor = RandomColorGenerator();
            Label01.Background = new SolidColorBrush(Color.FromRgb(randomColor.R, randomColor.G, randomColor.B));
        }

        static int counter = 0;
        private void Button01_Click(object sender, RoutedEventArgs e)
        {
            counter++;
            Button01.Content = $"{counter} times";

          //  var randomColor = RandomColorGenerator();
          //  Label01.Background = new SolidColorBrush(Color.FromRgb(randomColor.R,randomColor.G,randomColor.B));
            timer.Start();
            if (ImageRabbit.Visibility == Visibility.Visible)
            {
                ImageRabbit.Visibility = Visibility.Hidden;
            }
            else
            {
                ImageRabbit.Visibility = Visibility.Visible;
            }
        }

        public (byte R, byte G, byte B) RandomColorGenerator()
        {
            var r = new Random();
            byte R = (byte)r.Next(0, 256);
            byte G = (byte)r.Next(0, 256);
            byte B = (byte)r.Next(0, 256);
            return (R, G, B);
        }
    }
}
