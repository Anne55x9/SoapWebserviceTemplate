
using ModelLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SoapWebserviceTemplate
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private const string connectionString =
            "Server=tcp:annesazure.database.windows.net,1433;Initial Catalog=EasjDBasw;Persist Security Info=False;User ID=anne55x9;Password=Easj2017;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        //Metode som ganger indførte værdier med hinanden.

        public double GetValue1(double x1, double x2, double x3)
        {
            return x1 * x2 * x3;
        }

        /// <summary>
        /// Metode som dividere første værdi med de 2 næste.
        /// </summary>
        /// <param name="x2"></param>
        /// <param name="x3"></param>
        /// <param name="x4"></param>
        /// <returns></returns>
        public double GetValue2(double x2, double x3, double x4)
        {
            return x2/ (x3 * x4);
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }


        /// <summary>
        /// Metode som indsætter værdier i tabellen BoxCalRequest colonner. 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="volume"></param>
        /// <param name="length"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void InsertTableXX(string navn, double x1, double x2, double x3, double x4)
        {
            const string insertRequest = "insert into XXTable (navn, x1, x2, x3, x4) values (@navn, @x1, @x2, @x3, @x4)";
            using (SqlConnection databaseConnection = new SqlConnection(connectionString))
            {
                databaseConnection.Open();
                using (SqlCommand insertCommand = new SqlCommand(insertRequest, databaseConnection))
                {
                    insertCommand.Parameters.AddWithValue("@navn", navn);
                    insertCommand.Parameters.AddWithValue("@x1", x1);
                    insertCommand.Parameters.AddWithValue("@x2", x2);
                    insertCommand.Parameters.AddWithValue("@x3", x3);
                    insertCommand.Parameters.AddWithValue("@x4", x4);

                    insertCommand.ExecuteNonQuery();

                }
            }
        }

        /// <summary>
        /// Metode som henter alle udregninger i azure tabel.
        /// </summary>
        /// <returns></returns>
        public IList<ClassModel> GetAllTableXX()
        {
            const string selectAllRequests = "select * from XXTable order by XXAtriibutteNavn";

            using (SqlConnection databaseConnection = new SqlConnection(connectionString))
            {
                databaseConnection.Open();
                using (SqlCommand selectCommand = new SqlCommand(selectAllRequests, databaseConnection))
                {
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        List<ClassModel> requestList = new List<ClassModel>();
                        while (reader.Read())
                        {
                            ClassModel requests = ReadXX(reader);
                            requestList.Add(requests);
                        }
                        return requestList;
                    }
                }
            }
        }

        private static ClassModel ReadXX(IDataRecord reader)
        {

            string navn = reader.GetString(0);
            double x1 = reader.GetDouble(1);
            double x2 = reader.GetDouble(2);
            double x3 = reader.GetDouble(3);
            double x4 = reader.GetDouble(4);
            ClassModel xx = new ClassModel()
            {
                Navn = navn,
                X1 = x1,
                X2 = x2,
                X3 = x3,
                X4 = x4,
            };
            return xx;
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
