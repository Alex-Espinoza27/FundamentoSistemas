using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public  class DEmpleos
    {
        public DEmpleos() { }

        public bool Existe(String nombre)
        {
            //Empleos em = null;
            using (var context = new BDEFEntities())
            {
                Empleos em = context.Empleos.FirstOrDefault(e => e.NombreEmpleo.Equals(nombre));
                if(em == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        public String Registrar(Empleos Empleos)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    context.Empleos.Add(Empleos);
                    context.SaveChanges();
                }
                return "Registrado exitosamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public String Modificar(Empleos Empleos)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    Empleos EmpleosTemp = context.Empleos.Find(Empleos.Codigo_empleo);
                    EmpleosTemp.NombreEmpleo = Empleos.NombreEmpleo;
                    EmpleosTemp.SalarioMinimo = Empleos.SalarioMinimo;
                    EmpleosTemp.SalarioMaximo = Empleos.SalarioMaximo;
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
                    Empleos EmpleosTemp = context.Empleos.Find(id);
                    context.Empleos.Remove(EmpleosTemp);
                    context.SaveChanges();
                }
                return "Eliminado exitosamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public List<Empleos> ListarTodo()
        {
            List<Empleos> empleoos = new List<Empleos>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    empleoos = context.Empleos.ToList();
                }
                return empleoos;
            }
            catch (Exception ex)
            {
                return empleoos;
            }
        }
    }
}
