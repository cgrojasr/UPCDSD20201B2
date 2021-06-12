using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using UPC.CambioUPC.BL;
using UPC.CambioUPC.BL.BusinessLogic;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TransaccionService" in code, svc and config file together.
public class TransaccionService : ITransaccionService
{
    private readonly TransaccionBL objTransaccionBL;

    public TransaccionService()
    {
        objTransaccionBL = new TransaccionBL();
    }

    public TransaccionModel Buscar(int Id)
    {
        var objTransaccion = new TransaccionModel();
        try
        {
            var transaccion = objTransaccionBL.Buscar(Id);
            objTransaccion.Id = transaccion.Id;
            objTransaccion.Fecha = transaccion.Fecha;
            objTransaccion.MontoPEN = transaccion.MontoPEN;
            objTransaccion.MontoUSD = transaccion.MontoUSD;
            objTransaccion.Eliminado = transaccion.Eliminado;
        }
        catch (Exception ex)
        {
            objTransaccion.Error = true;
            objTransaccion.ErrorMessage = ex.Message;
        }

        return objTransaccion;
    }

    public bool Eliminar(int Id)
    {
        try
        {
            return objTransaccionBL.Eliminar(Id);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public bool Modificar(TransaccionModel objTransaccion)
    {
        try
        {
            var transaccion = new Transaccion
            {
                Id = objTransaccion.Id,
                IdTipoTransaccion = objTransaccion.IdTipoTransaccion,
                Fecha = objTransaccion.Fecha,
                MontoUSD = objTransaccion.MontoUSD,
                MontoPEN = objTransaccion.MontoPEN,
                IdTarjeta = objTransaccion.IdTarjeta,
                Eliminado = objTransaccion.Eliminado,
                IdUsuarioModifico = objTransaccion.IdUsuarioRegistro
            };
            return objTransaccionBL.Actualizar(transaccion);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int Registrar(TransaccionModel objTransaccion)
    {
        try
        {
            var transaccion = new Transaccion { 
                Id = objTransaccion.Id,
                IdTipoTransaccion = objTransaccion.IdTipoTransaccion,
                Fecha = objTransaccion.Fecha,
                MontoUSD = objTransaccion.MontoUSD,
                MontoPEN = objTransaccion.MontoPEN,
                IdTarjeta = objTransaccion.IdTarjeta,
                Eliminado = objTransaccion.Eliminado,
                IdUsuarioRegistro = objTransaccion.IdUsuarioRegistro
            };

            return objTransaccionBL.Registrar(transaccion);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
