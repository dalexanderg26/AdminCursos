using Interfaces;
using Modelo;

namespace Controladores
{
    public class EstudianteController : IOperaciones
    {
        public object Guardar(object pEstudiante)
        {
            Estudiante estudiante = new Estudiante();
            return estudiante.Guardar((Estudiante)pEstudiante);
        }

        public object Actualizar(object pEstudiante)
        {
            Estudiante estudiante = new Estudiante();
            return estudiante.Actualizar((Estudiante)pEstudiante);
        }

        public object Consultar(object pEstudiante)
        {
            Estudiante estudiante = new Estudiante();
            return estudiante.Consultar((Estudiante)pEstudiante);
        }
    }
}
