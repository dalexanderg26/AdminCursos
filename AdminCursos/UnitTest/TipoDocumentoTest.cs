using Controladores;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Modelo;

namespace UnitTest
{
    [TestClass]
    public class TipoDocumentoTest
    {
        [TestMethod]
        public void AgregarTipoDocumentoExitoso()
        {
            TipoDocumentoController administracion = new TipoDocumentoController();
            TipoDocumento tipoDocumento = new TipoDocumento();
            tipoDocumento.Nombre = "Cédula de Ciudadania";
            Resultado resultado = new Resultado();
            bool insertado = true;
            resultado = (Resultado)administracion.Guardar(tipoDocumento);
            Assert.AreEqual(insertado, resultado.Error == false);
        }
    }
}
