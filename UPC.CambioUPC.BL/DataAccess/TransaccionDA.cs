using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPC.CambioUPC.BL.DataAccess
{
    interface ITransaccionDA {
        int Registrar(Transaccion objTransaccion);
        Transaccion Buscar(int Id);
        bool Actualizar(Transaccion objTransaccion);
        bool Eliminar(int Id);
    }

    class TransaccionDA : ITransaccionDA
    {
        private readonly dbCambioUPCDataContext dc;

        public TransaccionDA()
        {
            dc = new dbCambioUPCDataContext();
        }

        public bool Actualizar(Transaccion objTransaccion)
        {
            try
            {
                var query = (from transaccion in dc.Transaccions
                             where transaccion.Id.Equals(objTransaccion.Id)
                             select transaccion).Single();

                query.Eliminado = objTransaccion.Eliminado;
                query.IdTarjeta = objTransaccion.IdTarjeta;
                query.IdTipoTransaccion = objTransaccion.IdTipoTransaccion;
                query.MontoPEN = objTransaccion.MontoPEN;
                query.MontoUSD = objTransaccion.MontoUSD;
                query.FechaModifico = DateTime.Now;
                query.IdUsuarioModifico = objTransaccion.IdUsuarioModifico;

                dc.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Transaccion Buscar(int Id)
        {
            try
            {
                var query = from transaccion in dc.Transaccions
                            where transaccion.Id.Equals(Id)
                            select transaccion;

                return query.Single();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(int Id)
        {
            try
            {
                var query = (from transaccion in dc.Transaccions
                             where transaccion.Id.Equals(Id)
                             select transaccion).Single();

                dc.Transaccions.DeleteOnSubmit(query);
                dc.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public int Registrar(Transaccion objTransaccion)
        {
            try
            {
                objTransaccion.FechaRegistro = DateTime.Now;
                dc.Transaccions.InsertOnSubmit(objTransaccion);
                dc.SubmitChanges();

                return objTransaccion.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
