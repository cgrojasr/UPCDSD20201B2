using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITransaccionService" in both code and config file together.
[ServiceContract]
public interface ITransaccionService
{
    [OperationContract]
    int Registrar(TransaccionModel objTransaccion);
    [OperationContract]
    TransaccionModel Buscar(int Id);
    [OperationContract]
    bool Modificar(TransaccionModel objTransaccion);
    [OperationContract]
    bool Eliminar(int Id);
}

[DataContract]
public class TransaccionModel : ErrorModel {
    [DataMember]
    public int Id { get; set; }
    [DataMember]
    public int IdTipoTransaccion { get; set; }
    [DataMember]
    public DateTime Fecha { get; set; }
    [DataMember]
    public decimal MontoUSD { get; set; }
    [DataMember]
    public decimal MontoPEN { get; set; }
    [DataMember]
    public int IdTarjeta { get; set; }
    [DataMember]
    public bool Eliminado { get; set; }
    [DataMember]
    public int IdUsuarioRegistro { get; set; }
}
