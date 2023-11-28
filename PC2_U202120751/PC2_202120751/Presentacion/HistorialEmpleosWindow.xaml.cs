using Datos;
using Negocio;
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
    /// Lógica de interacción para HistorialEmpleosWindow.xaml
    /// </summary>
    public partial class HistorialEmpleosWindow : Window
    {
        private NHistorialEmpleos nHistorial = new NHistorialEmpleos();
        private NEmpleos nEmpleos = new NEmpleos();
        private NEmpleado nEmpleado = new NEmpleado();

        public HistorialEmpleosWindow()
        {
            InitializeComponent();
            MostrarHistorialEmpleos(nHistorial.ListarTodo());
            MostrarEmpleado(nEmpleado.ListarTodo());
            MostrarEmpleos(nEmpleos.ListarTodo());

        }

        private void MostrarHistorialEmpleos(List<HistorialEmpleos> historial)
        {
            dgHistorial.ItemsSource = new List<HistorialEmpleos>();
            dgHistorial.ItemsSource = historial;
        }

        private void MostrarEmpleado(List<Empleado> empleado)
        {
            cbEmpleado.ItemsSource = new List<Empleado>();
            cbEmpleado.ItemsSource = empleado;
            cbEmpleado.DisplayMemberPath = "Nombre";
            cbEmpleado.SelectedValuePath = "Codigo_empleado";
        }

        private void MostrarEmpleos(List<Empleos> empleos)
        {
            cbEmpleo.ItemsSource = new List<Empleos>();
            cbEmpleo.ItemsSource = empleos;
            cbEmpleo.DisplayMemberPath = "NombreEmpleo";
            cbEmpleo.SelectedValuePath = "Codigo_empleo";
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (cbEmpleado.Text == "" || cbEmpleo.Text == "" ||
                dpFechaInicio.SelectedDate == null || dpFechaFIN.SelectedDate == null)
            {
                MessageBox.Show("Ingrese todos los campos");
                return;
            }
            //DateTime? fechainicio = dpFechaInicio.SelectedDate;
            //DateTime? fechafin = dpFechaFIN.SelectedDate;


            HistorialEmpleos historial = new HistorialEmpleos
            {
                Codigo_empleado = (int) cbEmpleado.SelectedValue,
                Codigo_empleo = (int) cbEmpleo.SelectedValue,
                FechaInicio = dpFechaInicio.SelectedDate.Value,
                FechaFIN= dpFechaFIN.SelectedDate.Value
            };

            String mensaje = nHistorial.Registrar(historial);
            MessageBox.Show(mensaje);

            MostrarHistorialEmpleos(nHistorial.ListarTodo());
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();   
        }
    }
}
