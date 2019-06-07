using Modelo;
using System.Collections.Generic;
using System.ServiceModel;

namespace AdminCursosSvc
{
    [ServiceContract(Name = "Modalidad", Namespace = "http://AdminCursos.Modalidad/")]
    public interface IModalidad
    {
        [OperationContract]
        Resultado Guardar(Modalidad pModalidad);

        [OperationContract]
        Resultado Actualizar(Modalidad pModalidad);

        [OperationContract]
        List<Modalidad> Consultar(Modalidad pModalidad);
    }
}
