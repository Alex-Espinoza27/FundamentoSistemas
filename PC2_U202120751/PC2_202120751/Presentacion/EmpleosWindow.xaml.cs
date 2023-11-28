using Negocio;
using Datos;
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
using System.Windows.Shapes;

namespace Presentacion
{
    /// <summary>
    /// Lógica de interacción para EmpleosWindow.xaml
    /// </summary>
    public partial class EmpleosWindow : Window
    {
        private NEmpleos nEmpleos = new NEmpleos();
        Empleos empleoSeleccionado = new Empleos();
        public EmpleosWindow()
        {
            InitializeComponent();
            MostrarEmpleos(nEmpleos.ListarTodo());
        }
        private void MostrarEmpleos(List<Empleos> empleos)
        {
            dgEmpleos.ItemsSource = new List<Empleos>();
            dgEmpleos.ItemsSource = empleos;
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            if (tbNombre.Text == "" || tbSalarioMaximo.Text == "" || tbSalarioMinimo.Text == "")
            {
                MessageBox.Show("Ingrese todos los campos");
                return;
            }

            Empleos empleo = new Empleos
            {
                NombreEmpleo = tbNombre.Text,
                SalarioMaximo = int.Parse(tbSalarioMaximo.Text),
                SalarioMinimo = int.Parse(tbSalarioMinimo.Text)
            };

            String mensaje = nEmpleos.Registrar(empleo);
            MessageBox.Show(mensaje);
            MostrarEmpleos(nEmpleos.ListarTodo());

        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (tbNombre.Text == "" || tbSalarioMaximo.Text == "" || tbSalarioMinimo.Text == "")
            {
                MessageBox.Show("Ingrese todos los campos");
                return;
            }

            Empleos empleo = new Empleos
            {
                Codigo_empleo = empleoSeleccionado.Codigo_empleo,
                NombreEmpleo = tbNombre.Text,
                SalarioMaximo = int.Parse(tbSalarioMaximo.Text),
                SalarioMinimo = int.Parse(tbSalarioMinimo.Text)
            };

            String mensaje = nEmpleos.Modificar(empleo);
            MessageBox.Show(mensaje);
            MostrarEmpleos(nEmpleos.ListarTodo());

        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (empleoSeleccionado == null)
            {
                MessageBox.Show("Primero seleccione un empleo");
                return;
            }
            String mensaje = nEmpleos.Eliminar(empleoSeleccionado.Codigo_empleo);
            MessageBox.Show(mensaje);
            MostrarEmpleos(nEmpleos.ListarTodo());
        }
        private void btnConsultarSalarioMinimo_Click(object sender, RoutedEventArgs e)
        {
            if ( tbSalarioMinimo.Text == "")
            {
                MessageBox.Show("Ingrese el salario minimo primero");
                return;
            }
            MostrarEmpleos(nEmpleos.ListarSalarioMinimo(int.Parse(tbSalarioMinimo.Text)));
        }

        private void btnConsultarSalarioMaximo_Click(object sender, RoutedEventArgs e)
        {
            if (tbSalarioMaximo.Text == "")
            {
                MessageBox.Show("Ingrese el salario maximo primero");
                return;
            } 
            MostrarEmpleos(nEmpleos.ListarSalarioMaximo(int.Parse(tbSalarioMaximo.Text)));
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgEmpleos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            empleoSeleccionado = dgEmpleos.SelectedItem as Empleos;
        }

        private void tbSalarioMaximo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text,0))
            {
                e.Handled = true;
            }
            TimeSpan s = new TimeSpan(0,0,0);

        }
    }
}
