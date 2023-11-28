using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NEmpleos
    {
        DEmpleos dEmpleos = new DEmpleos();

        public NEmpleos() { }

        public String Registrar(Empleos Empleos)
        {
            return dEmpleos.Registrar(Empleos);
        }

        public String Modificar(Empleos Empleos)
        {
            return dEmpleos.Modificar(Empleos);

        }

        public String Eliminar(int id)
        {
            return dEmpleos.Eliminar(id);

        }

        public List<Empleos> ListarTodo()
        {
            return dEmpleos.ListarTodo();
        }
        public List<Empleos> ListarSalarioMinimo(int salario)
        {
            return dEmpleos.ListarTodo().FindAll(e => e.SalarioMinimo > salario);
        }
        public List<Empleos> ListarSalarioMaximo(int salario)
        {
            return dEmpleos.ListarTodo().FindAll(e => e.SalarioMaximo > salario);
        }
    }
}
