namespace Interfaces
{
    public interface IOperaciones
    {
        object Actualizar(object pEntidad);
        object Consultar(object pDato);
        object Guardar(object pEntidad);
    }
}