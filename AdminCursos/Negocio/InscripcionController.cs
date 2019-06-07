using Controladores;
using Interfaces;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Controladores
{
    public class InscripcionController : IOperaciones
    {
        public object Guardar(object pInscripcion)
        {
            Inscripcion inscripcion = new Inscripcion();
            return inscripcion.Guardar((Inscripcion)pInscripcion);
        }

        public object Actualizar(object pInscripcion)
        {
            Inscripcion inscripcion = new Inscripcion();
            return inscripcion.Actualizar((Inscripcion)pInscripcion);
        }

        public object Consultar(object pInscripcion)
        {
            Inscripcion inscripcion = new Inscripcion();
            return inscripcion.Consultar((Inscripcion)pInscripcion);
        }

        public bool ValidarCuposDisponibles(int idCurso)
        {
            Curso curso = new Curso();
            List<Curso> cursos = new List<Curso>();
            CursoController controladorCurso = new CursoController();
            curso.Id = idCurso;
            cursos = (List<Curso>)controladorCurso.Consultar(curso);
            var cursosFiltrados = cursos.FirstOrDefault();

            List<Inscripcion> inscripciones = new List<Inscripcion>();
            Inscripcion inscripcion = new Inscripcion();
            inscripcion.Id = 0;
            inscripciones = (List<Inscripcion>)this.Consultar(inscripcion);
            List<Inscripcion> inscripcionesFiltradas = inscripciones.Where(x => x.Curso.Id == idCurso).ToList();

            return inscripcionesFiltradas.Count() < cursosFiltrados.TotalCupos;
        }

        public bool ValidarFechaInscripcion(int idCurso, DateTime fechaInscripcion)
        {
            Curso curso = new Curso();
            List<Curso> cursos = new List<Curso>();
            CursoController controladorCurso = new CursoController();
            curso.Id = idCurso;
            cursos = (List<Curso>)controladorCurso.Consultar(curso);
            var cursosFiltrados = cursos.FirstOrDefault();

            return fechaInscripcion < cursosFiltrados.FechaLimiteInscripcion;
        }
    }
}
