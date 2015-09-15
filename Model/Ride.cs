using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;


namespace TermProject.Model
{
    public class Ride
    {
        public int Id { get; set; }
        public int PassengerId { get; set; }
        public int DriverId { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Charge { get; set; }      
    
    }

    public class RideDb
    {
        public static bool Save(Ride r)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {  
                new SqlParameter("@PassengerId", r.PassengerId),
                new SqlParameter("@DriverId", r.DriverId),
                new SqlParameter("@Description", r.Description),
                new SqlParameter("@StartDate",r.StartDate),
                new SqlParameter("@EndDate",r.EndDate),
                new SqlParameter("@Charge",r.Charge) 
            };

            string query = "INSERT INTO Rides VALUES(@PassengerId, @DriverId, @Description, @StartDate, @EndDate, @Charge)";

            DataAccess dbAcess = new DataAccess();
            return dbAcess.ExecuteNonQuery(query, CommandType.Text, parameters);
        }

        public static Ride getLastPaidRide(int passengerId)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {  
                new SqlParameter("@PassengerId", passengerId)
            };

            string query = "SELECT * FROM Rides WHERE PassengerId = @PassengerId ORDER BY Id DESC";

            DataAccess dbAcess = new DataAccess();

            DataTable dt = dbAcess.ExecuteParamerizedSelectCommand(query, CommandType.Text, parameters);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    Ride r = new Ride();
                    r.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                    r.PassengerId = Convert.ToInt32(dt.Rows[0]["PassengerId"]);
                    r.DriverId = Convert.ToInt32(dt.Rows[0]["DriverId"]);
                    r.Description = dt.Rows[0]["Description"].ToString();
                    r.StartDate = Convert.ToDateTime(dt.Rows[0]["StartDate"].ToString());
                    r.EndDate = Convert.ToDateTime(dt.Rows[0]["EndDate"].ToString());
                    r.Charge = Convert.ToInt32(dt.Rows[0]["Charge"]);
                    return r;
                }
            }

            return null;
        }

        public static DataTable GetUpcomingRides(int passengerId)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {  
                new SqlParameter("@PassengerId", passengerId),            
            };

            string query = @"select r.Id, r.StartDate, r.EndDate, u.FullName, v.Model
                            , DATEDIFF(HOUR, CURRENT_TIMESTAMP, r.StartDate) AS HourLeft
                            , (CASE WHEN DATEDIFF(HOUR, CURRENT_TIMESTAMP, r.StartDate) < 24 THEN 0
                            WHEN DATEDIFF(HOUR, CURRENT_TIMESTAMP, r.StartDate) > 24 THEN 1
                            END) AS CancelStatus
                            from Rides as r
                            left outer join Vehicles as v on v.DriverId = r.DriverId
                            left outer join Users as u on u.Id = v.DriverId
                            where r.PassengerId = @PassengerId and DATEDIFF(HOUR, CURRENT_TIMESTAMP, r.StartDate) >= 0
                            order by r.StartDate";

            DataAccess dbAcess = new DataAccess();

            return dbAcess.ExecuteParamerizedSelectCommand(query, CommandType.Text, parameters);
        }

        public static DataTable GetRecentRides(int passengerId)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {  
                new SqlParameter("@PassengerId", passengerId),            
            };

            string query = @"select r.Id, r.StartDate, r.EndDate, u.FullName, v.Model
                            , DATEDIFF(HOUR, CURRENT_TIMESTAMP, r.StartDate) AS HourLeft
                            , (CASE WHEN DATEDIFF(HOUR, CURRENT_TIMESTAMP, r.StartDate) < 24 THEN 0
                            WHEN DATEDIFF(HOUR, CURRENT_TIMESTAMP, r.StartDate) > 24 THEN 1
                            END) AS CancelStatus
                            from Rides as r
                            left outer join Vehicles as v on v.DriverId = r.DriverId
                            left outer join Users as u on u.Id = v.DriverId
                            where r.PassengerId = @PassengerId and DATEDIFF(HOUR, CURRENT_TIMESTAMP, r.StartDate) < 0
                            order by r.StartDate";

            DataAccess dbAcess = new DataAccess();

            return dbAcess.ExecuteParamerizedSelectCommand(query, CommandType.Text, parameters);
        }

        public static Ride GetRideById(int rideId)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {  
                new SqlParameter("@Id", rideId)
            };

            string query = "SELECT * FROM Rides WHERE Id = @Id";

            DataAccess dbAcess = new DataAccess();
            DataTable dt = dbAcess.ExecuteParamerizedSelectCommand(query, CommandType.Text, parameters);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    Ride r = new Ride();
                    r.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                    r.PassengerId = Convert.ToInt32(dt.Rows[0]["PassengerId"]);
                    r.DriverId = Convert.ToInt32(dt.Rows[0]["DriverId"]);
                    r.Description = dt.Rows[0]["Description"].ToString();
                    r.StartDate = Convert.ToDateTime(dt.Rows[0]["StartDate"].ToString());
                    r.EndDate = Convert.ToDateTime(dt.Rows[0]["EndDate"].ToString());
                    r.Charge = Convert.ToInt32(dt.Rows[0]["Charge"]);
                    return r;
                }
            }

            return null;
        }

        public static bool CancelRide(int id)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {  
                new SqlParameter("@Id",id) 
            };

            string query = "DELETE FROM Rides WHERE Id = @Id";

            DataAccess dbAcess = new DataAccess();
            return dbAcess.ExecuteNonQuery(query, CommandType.Text, parameters);
        }

        public static int CountRide(int driverId)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {  
                new SqlParameter("@DriverId", driverId),            
            };

            string query = @"SELECT COUNT(Id) AS RideNum FROM Rides WHERE DriverId = @DriverId AND DATEDIFF(SECOND, CURRENT_TIMESTAMP, StartDate) < 0";

            DataAccess dbAcess = new DataAccess();

            DataTable dt = dbAcess.ExecuteParamerizedSelectCommand(query, CommandType.Text, parameters);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    return Convert.ToInt32(dt.Rows[0]["RideNum"]);
                }
            }

            return 0;
        }

        public static int CalculateTotalIncome(int driverId)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {  
                new SqlParameter("@DriverId", driverId),            
            };

            string query = @"SELECT SUM(Charge) AS Income FROM Rides WHERE DriverId = @DriverId AND DATEDIFF(SECOND, CURRENT_TIMESTAMP, StartDate) < 0";

            DataAccess dbAcess = new DataAccess();

            DataTable dt = dbAcess.ExecuteParamerizedSelectCommand(query, CommandType.Text, parameters);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    return Convert.ToInt32(dt.Rows[0]["Income"]);
                }
            }

            return 0;
        }

        public static DataTable GetUpcomingRidesDriver(int driverId)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {  
                new SqlParameter("@PassengerId", driverId),            
            };

            string query = @"select r.StartDate, r.EndDate, u.FullName, r.Description 
                            , DATEDIFF(HOUR, CURRENT_TIMESTAMP, r.StartDate) AS HourLeft
                            from Rides as r
                            left outer join Users as u on u.Id = r.PassengerId
                            where r.DriverId = @PassengerId and DATEDIFF(HOUR, CURRENT_TIMESTAMP, r.StartDate) > 0
                            order by r.StartDate";

            DataAccess dbAcess = new DataAccess();

            return dbAcess.ExecuteParamerizedSelectCommand(query, CommandType.Text, parameters);
        }
    }
}