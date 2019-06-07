using System;
using System.Runtime.Serialization;

namespace Modelo
{
    [Serializable]
    [DataContract(Namespace = "http://AdminCursos.Entidades/")]
    public class Resultado
    {
        private bool error;
        private string mensaje;

        public Resultado()
        {
            this.Error = false;
        }

        [DataMember(IsRequired = false)]
        public bool Error
        {
            get => error;
            set => error = value;
        }

        [DataMember(IsRequired = false)]
        public string Mensaje
        {
            get => mensaje;
            set => mensaje = value;
        }
    }
}
