using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace TermProject.Model
{
    public class Vehicle
    {
        public int Id { get; set; }
        public int DriverId { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string LicenseNumber { get; set; }
        public string City { get; set; }
        public float Cost { get; set; }
    }

    public class VehicleDb
    {
        public static bool Save(Vehicle v)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {  
                new SqlParameter("@DriverId", v.DriverId),
                new SqlParameter("@Model", v.Model),
                new SqlParameter("@Year",v.Year),
                new SqlParameter("@LicenseNumber",v.LicenseNumber),
                new SqlParameter("@City",v.City),
                new SqlParameter("@Cost", v.Cost),      
            };

            string query = "INSERT INTO Vehicles VALUES(@DriverId, @Model, @Year, @LicenseNumber, @City, @Cost)";

            DataAccess dbAcess = new DataAccess();

            return dbAcess.ExecuteNonQuery(query, CommandType.Text, parameters);
        }

        public static bool Update(Vehicle v)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {  
                new SqlParameter("@Id", v.Id),
                new SqlParameter("@Model", v.Model),
                new SqlParameter("@Year", v.Year),
                new SqlParameter("@LicenseNumber", v.LicenseNumber),
                new SqlParameter("@City", v.City),
                new SqlParameter("@Cost", v.Cost),
            };
        
            string query = "UPDATE Vehicles SET Model = @Model, Year= @Year, LicenseNumber = @LicenseNumber, City = @City, Cost = @Cost WHERE Id = @Id";

            DataAccess dbAcess = new DataAccess();

            return dbAcess.ExecuteNonQuery(query, CommandType.Text, parameters);
        }

        public static Vehicle getVehicleByUserId(int userId)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {  
                new SqlParameter("@DriverId", userId)
            };

            string query = "SELECT * FROM Vehicles WHERE DriverId = @DriverId";

            DataAccess dbAcess = new DataAccess();
            DataTable dt = dbAcess.ExecuteParamerizedSelectCommand(query, CommandType.Text, parameters);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    Vehicle v = new Vehicle();
                    v.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                    v.DriverId = Convert.ToInt32(dt.Rows[0]["DriverId"]);
                    v.Model = dt.Rows[0]["Model"].ToString();
                    v.Year = Convert.ToInt32(dt.Rows[0]["Year"]);
                    v.LicenseNumber= dt.Rows[0]["LicenseNumber"].ToString();
                    v.City = dt.Rows[0]["City"].ToString();
                    v.Cost= Convert.ToInt32(dt.Rows[0]["Cost"]);
                    return v;
                }
            }

            return null;
        }

        public static Vehicle getVehicleById(int id)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {  
                new SqlParameter("@Id", id)
            };

            string query = "SELECT * FROM Vehicles WHERE Id = @Id";

            DataAccess dbAcess = new DataAccess();
            DataTable dt = dbAcess.ExecuteParamerizedSelectCommand(query, CommandType.Text, parameters);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    Vehicle v = new Vehicle();
                    v.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                    v.DriverId = Convert.ToInt32(dt.Rows[0]["DriverId"]);
                    v.Model = dt.Rows[0]["Model"].ToString();
                    v.Year = Convert.ToInt32(dt.Rows[0]["Year"]);
                    v.LicenseNumber = dt.Rows[0]["LicenseNumber"].ToString();
                    v.City = dt.Rows[0]["City"].ToString();
                    v.Cost = Convert.ToInt32(dt.Rows[0]["Cost"]);
                    return v;
                }
            }

            return null;
        }

        public static DataTable Search(string city)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {  
                new SqlParameter("@City", city),            
            };
         
            string query =  @"select v.Id, u.FullName, v.Model, v.Cost
                            from Vehicles as v
                            left outer join Users as u on u.Id = v.DriverId
                            where v.City like '%" + city + "%' ";

            DataAccess dbAcess = new DataAccess();

            return dbAcess.ExecuteParamerizedSelectCommand(query, CommandType.Text, parameters);
        }


    }
}
