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

namespace Presentacion
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnVerEmpleados_Click(object sender, RoutedEventArgs e)
        {
            EmpleadoWindow form = new EmpleadoWindow();
            form.ShowDialog();
        }

        private void btnVerEmpleos_Click(object sender, RoutedEventArgs e)
        {
            EmpleosWindow form = new EmpleosWindow();
            form.ShowDialog();
        }

        private void btnHistorialEmpleos_Click(object sender, RoutedEventArgs e)
        {
            HistorialEmpleosWindow form = new HistorialEmpleosWindow();
            form.ShowDialog();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();   
        }
    }
}
