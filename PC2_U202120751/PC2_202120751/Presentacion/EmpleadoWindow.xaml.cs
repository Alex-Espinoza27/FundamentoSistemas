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
    /// Lógica de interacción para EmpleadoWindow.xaml
    /// </summary>
    public partial class EmpleadoWindow : Window
    {
        private NEmpleado nEmpleado = new NEmpleado();
        Empleado empleadoSeleccionado = new Empleado();
        public EmpleadoWindow()
        {
            InitializeComponent();
            MostrarEmpleado(nEmpleado.ListarTodo());
        }

        private void MostrarEmpleado(List<Empleado> empleados)
        {
            dgEmpleados.ItemsSource = new List<Empleado>();
            dgEmpleados.ItemsSource = empleados;
        }
        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            if (tbNombre.Text == "" || tbDNI.Text == "" || tbApellido.Text == "" || tbSalario.Text == ""
               || tbDNI.Text == "" || dpFechaNaci.SelectedDate == null || dpFechaContratacion.SelectedDate == null)
            {
                MessageBox.Show("Ingrese todos los campos");
                return;
            }

            // Creación del objeto
            Empleado emp = new Empleado
            {
                DNI = tbDNI.Text,
                Nombre = tbNombre.Text,
                Apellido = tbApellido.Text,
                FechaNacimiento = dpFechaNaci.SelectedDate.Value,
                FechaContratacion = dpFechaContratacion.SelectedDate.Value,
                Salario = int.Parse(tbSalario.Text)
            };


            String mensaje = nEmpleado.Registrar(emp);
            MessageBox.Show(mensaje);

            // Mostrar en el DataGrid
            MostrarEmpleado(nEmpleado.ListarTodo());
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if(empleadoSeleccionado == null)
            {
                MessageBox.Show("Primero seleccione unn empleado");
                return;
            }
            String mensaje = nEmpleado.Eliminar(empleadoSeleccionado.Codigo_empleado);
            MessageBox.Show(mensaje);
            MostrarEmpleado(nEmpleado.ListarTodo());

        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
         }

        private void dgEmpleados_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            empleadoSeleccionado = dgEmpleados.SelectedItem as Empleado;
        }

        private void btnFiltrarPorFecha_Click(object sender, RoutedEventArgs e)
        {
            if ( dpFechaNaci.SelectedDate == null || dpFechaContratacion.SelectedDate == null)
            {
                MessageBox.Show("Ingrese todos los campos");
                return;
            }
            MostrarEmpleado(nEmpleado.ListarProFecha(dpFechaNaci.SelectedDate.Value, dpFechaContratacion.SelectedDate.Value));
        }
    }
}
