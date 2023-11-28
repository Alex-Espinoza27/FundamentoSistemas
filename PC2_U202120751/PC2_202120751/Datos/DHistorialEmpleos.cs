using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DHistorialEmpleos
    {
        public DHistorialEmpleos() { }

        public String Asignar(HistorialEmpleos historial)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    context.HistorialEmpleos.Add(historial);
                    context.SaveChanges();
                }
                return "Asignado exitosamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<HistorialEmpleos> ListarTodo()
        {
            List<HistorialEmpleos> historial = new List<HistorialEmpleos>();
            try
            {
                using (var context = new BDEFEntities())
                { 
                    historial = context.HistorialEmpleos.ToList();
                }
                return historial;
            }
            catch (Exception ex)
            {
                return historial;
            }
        }
    }
}
