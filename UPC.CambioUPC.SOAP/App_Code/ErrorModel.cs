using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// Use a data contract as illustrated in the sample below to add composite types to service operations.
[DataContract]
public class ErrorModel
{
    [DataMember]
    public bool Error { get; set; }
    [DataMember]
    public string ErrorMessage { get; set; }
}
