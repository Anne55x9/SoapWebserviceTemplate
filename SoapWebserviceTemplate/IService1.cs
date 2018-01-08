using ModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SoapWebserviceTemplate
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        double GetValue1(double x1, double x2, double x3);

        [OperationContract]
        double GetValue2(double x2, double x3, double x4);

        [OperationContract]
        void InsertTableXX(string navn, double x1, double x2, double x3, double x4);

        /// <summary>
        /// Metode til at se alle udregninger fra azure tabel.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        IList<ClassModel> GetAllTableXX();

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
