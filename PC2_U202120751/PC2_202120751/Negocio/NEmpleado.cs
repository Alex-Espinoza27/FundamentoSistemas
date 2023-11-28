using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NEmpleado
    {
        DEmpleado dEmpleado = new DEmpleado();
        public NEmpleado() { }

        private DEmpleado dCurso = new DEmpleado();

        public String Registrar(Empleado empleado)
        {
            return dEmpleado.Registrar(empleado);
        }
        public String Eliminar(int id)
        {
            return dEmpleado.Eliminar(id);
        }
        public List<Empleado> ListarTodo()
        {
            return dEmpleado.ListarTodo();
        }
        public List<Empleado> ListarProFecha(DateTime fechaI, DateTime fechaF)
        {
            return dEmpleado.ListarProFecha(fechaI, fechaF);
        }

    }
}
