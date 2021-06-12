using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC.CambioUPC.BL.DataAccess;

namespace UPC.CambioUPC.BL.BusinessLogic
{
    interface ITransaccionBL
    {
        int Registrar(Transaccion objTransaccion);
        Transaccion Buscar(int Id);
        bool Actualizar(Transaccion objTransaccion);
        bool Eliminar(int Id);
    }

    public class TransaccionBL : ITransaccionBL
    {
        private readonly TransaccionDA objTransaccionDA;

        public TransaccionBL()
        {
            objTransaccionDA = new TransaccionDA();
        }

        public bool Actualizar(Transaccion objTransaccion)
        {
            try
            {
                return objTransaccionDA.Actualizar(objTransaccion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Transaccion Buscar(int Id)
        {
            try
            {
                return objTransaccionDA.Buscar(Id);
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
                return objTransaccionDA.Eliminar(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Registrar(Transaccion objTransaccion)
        {
            try
            {
                return objTransaccionDA.Registrar(objTransaccion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
