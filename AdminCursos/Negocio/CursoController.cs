using Interfaces;
using Modelo;

namespace Controladores
{
    public class CursoController: IOperaciones
    {
        public object Guardar(object pCurso)
        {
            Curso curso = new Curso();
            return curso.Guardar((Curso)pCurso);
        }

        public object Actualizar(object pCurso)
        {
            Curso curso = new Curso();
            return curso.Actualizar((Curso)pCurso);
        }

        public object Consultar(object pCurso)
        {
            Curso curso = new Curso();
            return curso.Consultar((Curso)pCurso);
        }
    }
}
