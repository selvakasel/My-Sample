using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using robert.Models;

namespace robert
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string login(string USERNAME, string PASSWORD);

        [OperationContract]
        string Save(Class1 c);

        [OperationContract]
        string Update(Class1 c);

        [OperationContract]
        string Delete(Class1 c); 

    }
}
