using Interfaces;
using Modelo;

namespace Controladores
{
    public class ModalidadController : IOperaciones
    {
        public object Guardar(object pModalidad)
        {
            Modalidad modalidad = new Modalidad();
            return modalidad.Guardar((Modalidad)pModalidad);
        }

        public object Actualizar(object pModalidad)
        {
            Modalidad modalidad = new Modalidad();
            return modalidad.Actualizar((Modalidad)pModalidad);
        }

        public object Consultar(object pModalidad)
        {
            Modalidad modalidad = new Modalidad();
            return modalidad.Consultar((Modalidad)pModalidad);
        }
    }
}
