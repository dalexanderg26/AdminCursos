using Controladores;
using Modelo;
using System.Collections.Generic;

namespace AdminCursosSvc
{
    public class Modalidades : IModalidad
    {
        public Resultado Actualizar(Modalidad pModalidad)
        {
            ModalidadController controladorModalidad = new ModalidadController();
            return (Resultado)controladorModalidad.Actualizar(pModalidad);
        }

        public List<Modalidad> Consultar(Modalidad pModalidad)
        {
            ModalidadController controladorModalidad = new ModalidadController();
            return (List<Modalidad>)controladorModalidad.Consultar(pModalidad);
        }

        public Resultado Guardar(Modalidad pModalidad)
        {
            ModalidadController controladorModalidad = new ModalidadController();
            return (Resultado)controladorModalidad.Guardar(pModalidad);
        }
    }
}
