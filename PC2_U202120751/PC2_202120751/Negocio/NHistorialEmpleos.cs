using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NHistorialEmpleos
    {
        private DHistorialEmpleos dHistorialEmpleos = new DHistorialEmpleos();

        //public NHistorialEmpleos() { }

        public String Registrar(HistorialEmpleos docenteXCurso)
        {
            return dHistorialEmpleos.Asignar(docenteXCurso);
        }

        public List<HistorialEmpleos> ListarTodo()
        {
            return dHistorialEmpleos.ListarTodo();
        }
    }


}
