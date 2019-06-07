using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Modelo
{
    public class Inscripcion
    {
        private int id;
        private Estudiante estudiante;
        private Curso curso;
        private DateTime? fechaInscripcion;
        private double notaFinal;

        public int Id { get => id; set => id = value; }
        public Estudiante Estudiante { get => estudiante; set => estudiante = value; }
        public Curso Curso { get => curso; set => curso = value; }
        public DateTime? FechaInscripcion { get => fechaInscripcion; set => fechaInscripcion = value; }
        public double NotaFinal { get => notaFinal; set => notaFinal = value; }

        public Inscripcion()
        {
        }

        public Inscripcion(DataRow fila)
        {
            this.Id = int.Parse(fila["Id"].ToString());
            this.Estudiante = new Estudiante(
                int.Parse(fila["IdEstudiante"].ToString()), 
                fila["NumeroDocumento"].ToString(),
                fila["PrimerApellido"].ToString(),
                fila["SegundoApellido"].ToString(),
                fila["PrimerNombre"].ToString(),
                fila["SegundoNombre"].ToString()
                );
            this.Curso = new Curso(int.Parse(fila["IdCurso"].ToString()), fila["NombreCurso"].ToString());
            this.FechaInscripcion = Convert.ToDateTime(fila["FechaInscripcion"].ToString());
            this.NotaFinal = double.Parse(fila["Nota"].ToString());
        }

        public Resultado Guardar(Inscripcion pInscripcion)
        {
            Resultado resultado = new Resultado();
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro();
            bool insertado = true;
            AccesoDatos acceso = new AccesoDatos();
            parametro.Nombre = "IdEstudiante";
            parametro.Valor = pInscripcion.Estudiante.Id;
            parametros.Add(parametro);
            parametro = new Parametro();
            parametro.Nombre = "IdCurso";
            parametro.Valor = pInscripcion.Curso.Id;
            parametros.Add(parametro);
            parametro = new Parametro();
            parametro.Nombre = "FechaInscripcion";
            parametro.Valor = pInscripcion.FechaInscripcion;
            parametros.Add(parametro);
            parametro = new Parametro();
            parametro.Nombre = "Nota";
            parametro.Valor = pInscripcion.NotaFinal;
            parametros.Add(parametro);

            insertado = acceso.Insertar("AgregarInscripcion", parametros);

            if (insertado == true)
            {
                resultado.Error = false;
                resultado.Mensaje = string.Empty;
            }
            else
            {
                resultado.Error = true;
                resultado.Mensaje = "Error al crear el registro";
            }

            return resultado;
        }

        public Resultado Actualizar(Inscripcion pInscripcion)
        {
            Resultado resultado = new Resultado();
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro();
            bool actualizado = true;
            AccesoDatos acceso = new AccesoDatos();
            parametro.Nombre = "IdInscripcion";
            parametro.Valor = pInscripcion.Id;
            parametros.Add(parametro);
            parametro = new Parametro();
            parametro.Nombre = "IdEstudiante";
            parametro.Valor = pInscripcion.Estudiante.Id;
            parametros.Add(parametro);
            parametro = new Parametro();
            parametro.Nombre = "IdCurso";
            parametro.Valor = pInscripcion.Curso.Id;
            parametros.Add(parametro);
            parametro = new Parametro();
            parametro.Nombre = "FechaInscripcion";
            parametro.Valor = pInscripcion.FechaInscripcion;
            parametros.Add(parametro);
            parametro = new Parametro();
            parametro.Nombre = "Nota";
            parametro.Valor = pInscripcion.NotaFinal;
            parametros.Add(parametro);

            actualizado = acceso.Actualizar("ActualizarInscripcion", parametros);

            if (actualizado == true)
            {
                resultado.Error = false;
                resultado.Mensaje = string.Empty;
            }
            else
            {
                resultado.Error = true;
                resultado.Mensaje = "Error al actualizar el registro";
            }

            return resultado;
        }

        public List<Inscripcion> Consultar(Inscripcion pInscripcion)
        {
            List<Inscripcion> inscripciones = new List<Inscripcion>();
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro();
            AccesoDatos acceso = new AccesoDatos();
            parametro.Nombre = "IdInscripcion";
            parametro.Valor = pInscripcion.Id;
            parametros.Add(parametro);
            DataTable tabla = acceso.Obtener("ObtenerInscripciones", parametros);

            if (tabla.Rows.Count > 0)
            {
                inscripciones = (from fila in tabla.AsEnumerable()
                                 select new Inscripcion(fila)).ToList();
            }

            return inscripciones;
        }
    }
}