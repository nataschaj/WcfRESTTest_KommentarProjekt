using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfRESTTest
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        private string connStr = "Server=tcp:natascha.database.windows.net,1433;Initial Catalog = School; Persist Security Info=False;User ID = nataschajakobsen; Password= Roskilde4000;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30";

        public IList<Apartment> GetAllApartments()
        {
            List<Apartment> apartments = new List<Apartment>();

            using (SqlConnection connection = new SqlConnection(connStr)) //// create a connection object "connection"
            {
                connection.Open();

                String sql = "SELECT * FROM Apartment order by Id";

                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();


                //The return value of Read is type bool and returns true as long as there are more records to read.
                //After the last record in the data stream has been read, Read returns false.
                while (reader.Read()) 
                {
                    Apartment nyapt = new Apartment();

                    nyapt.Id = reader.GetInt32(0);
                    nyapt.Size = reader.GetInt32(1);
                    nyapt.NoOfRooms = reader.GetInt32(2);
                    nyapt.Story = reader.GetInt32(3);
                    nyapt.ZipCode = reader.GetInt32(4);
                    nyapt.Adress = reader.GetString(5);

                    apartments.Add(nyapt);

                }

            }

            return apartments;
        }
    }
}
