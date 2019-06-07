using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    public class Parametro
    {
        private string nombre;
        private object valor;

        public string Nombre
        {
            get => nombre;
            set => nombre = value;
        }

        public object Valor
        {
            get => valor;
            set => valor = value;
        }
    }
}
