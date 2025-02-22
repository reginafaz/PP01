using pp_01.Admin;
using pp_01.Roditeli;
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

namespace pp_01
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void EntryParents(object sender, RoutedEventArgs e)
        {
            RaspisanieView r = new RaspisanieView();
            r.Show();
            this.Close();
        }

        private void EntryAdmin(object sender, RoutedEventArgs e)
        {
            ViewModelMenu v = new ViewModelMenu();
            v.Show();
            this.Close();
        }

       
    }
}
