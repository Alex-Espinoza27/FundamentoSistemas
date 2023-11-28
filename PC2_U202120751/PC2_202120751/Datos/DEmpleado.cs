using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public  class DEmpleado
    {

        public DEmpleado() { }

        public String Registrar(Empleado empleado)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    context.Empleado.Add(empleado);
                    context.SaveChanges();
                }
                return "Registrado exitosamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public String Modificar(Empleado empleado)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    Empleado empleadoTemp = context.Empleado.Find(empleado.Codigo_empleado);
                    empleadoTemp.DNI = empleado.DNI;
                    empleadoTemp.Nombre = empleado.Nombre;
                    empleadoTemp.Apellido = empleado.Apellido;
                    empleadoTemp.Salario = empleado.Salario; 
                     
                    context.SaveChanges();
                }
                return "Modificado exitosamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public String Eliminar(int id)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    Empleado empleadoTemp = context.Empleado.Find(id);
                    context.Empleado.Remove(empleadoTemp);
                    context.SaveChanges();
                }
                return "Eliminado exitosamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Empleado> ListarTodo()
        {
            List<Empleado> empleado = new List<Empleado>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    empleado = context.Empleado.ToList();
                }
                return empleado;
            }
            catch (Exception ex)
            {
                return empleado;
            }
        }
        public List<Empleado> ListarProFecha(DateTime fechaI, DateTime fechaF)
        {
            List<Empleado> empleado = new List<Empleado>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    empleado = context.Empleado.Where(e=>e.FechaNacimiento>=fechaI && e.FechaContratacion<=fechaF).ToList();
                }
                return empleado;
            }
            catch (Exception ex)
            {
                return empleado;
            }
        }

    }
}
