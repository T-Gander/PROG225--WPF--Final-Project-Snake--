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

namespace PROG225__Final_Project_Snake__
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Creates 100x100 grid.
            const int n = 100;
            for (int i = 0; i < n; ++i)
            {
                Grid.ColumnDefinitions.Add(new ColumnDefinition());
                Grid.RowDefinitions.Add(new RowDefinition());
            }
        }
    }
}
