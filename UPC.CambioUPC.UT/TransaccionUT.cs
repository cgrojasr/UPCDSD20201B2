using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UPC.CambioUPC.BL;
using UPC.CambioUPC.BL.BusinessLogic;

namespace UPC.CambioUPC.UT
{
    [TestClass]
    public class TransaccionUT
    {
        private readonly TransaccionBL objTransaccionBL;

        public TransaccionUT()
        {
            objTransaccionBL = new TransaccionBL();
        }

        [TestMethod]
        public void RegistrarCompraUSD()
        {
            var transaccion = new Transaccion
            {
                IdTarjeta = 1,
                Fecha = DateTime.Now,
                Eliminado = false,
                IdTipoTransaccion = 1,
                MontoPEN = 4000,
                MontoUSD = (decimal)(4000 / 3.8),
                IdUsuarioRegistro = 0,
                FechaRegistro = DateTime.Now,
            };

            var id = objTransaccionBL.Registrar(transaccion);

            Assert.AreEqual(1, id);
        }

        [TestMethod]
        public void RegistrarVentaUSD()
        {
            var transaccion = new Transaccion
            {
                IdTarjeta = 1,
                Fecha = DateTime.Now,
                Eliminado = false,
                IdTipoTransaccion = 2,
                MontoPEN = (decimal)(1000*3.75),
                MontoUSD = 1000,
                IdUsuarioRegistro = 0,
                FechaRegistro = DateTime.Now,
            };

            var id = objTransaccionBL.Registrar(transaccion);

            Assert.AreEqual(2, id);
        }

        [TestMethod]
        public void Actualizar()
        {
            var transaccion = new Transaccion
            {
                Id = 3,
                IdTarjeta = 1,
                Eliminado = true,
                IdTipoTransaccion = 1,
                MontoPEN = 4000,
                MontoUSD = (decimal)(4000 / 3.78),
                IdUsuarioModifico = 1,
                FechaModifico = DateTime.Now
            };

            var rpta = objTransaccionBL.Actualizar(transaccion);

            Assert.AreEqual(true, rpta);
        }

        [TestMethod]
        public void Buscar()
        {
            var transaccion = objTransaccionBL.Buscar(3);

            Assert.AreEqual(3, transaccion.Id);
        }

        [TestMethod]
        public void Eliminar()
        {
            var rpta = objTransaccionBL.Eliminar(3);

            Assert.AreEqual(true, rpta);
        }
    }
}
