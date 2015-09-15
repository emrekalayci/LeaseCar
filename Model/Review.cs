using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace TermProject.Model
{
    public class Review
    {
        public int Id { get; set; }
        public int RideId { get; set; }
        public string Comment { get; set; }
        public int Vote { get; set; }      
    }

    public class ReviewDb
    {
        public static bool Save(Review rev)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {  
                new SqlParameter("@RideId", rev.RideId),
                new SqlParameter("@Comment", rev.Comment),
                new SqlParameter("@Vote",rev.Vote)
            };

            string query = "INSERT INTO Reviews VALUES(@RideId, @Comment, @Vote)";

            DataAccess dbAcess = new DataAccess();

            return dbAcess.ExecuteNonQuery(query, CommandType.Text, parameters);
        }

        public static bool Update(Review rev)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {  
                new SqlParameter("@Id",rev.Id),
                new SqlParameter("@Comment", rev.Comment),
                new SqlParameter("@Vote",rev.Vote)    
            };

            string query = "UPDATE Reviews SET Comment = @Comment, Vote = @Vote WHERE Id = @Id";

            DataAccess dbAcess = new DataAccess();

            return dbAcess.ExecuteNonQuery(query, CommandType.Text, parameters);
        }

        public static Review GetReviewByRideId(int rideId)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {  
                new SqlParameter("@RideId", rideId)
            };

            string query = "SELECT * FROM Reviews WHERE RideId = @RideId";

            DataAccess dbAcess = new DataAccess();
            DataTable dt = dbAcess.ExecuteParamerizedSelectCommand(query, CommandType.Text, parameters);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    Review rev = new Review();
                    rev.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                    rev.RideId = Convert.ToInt32(dt.Rows[0]["RideId"]);
                    rev.Comment = dt.Rows[0]["Comment"].ToString();
                    rev.Vote = Convert.ToInt32(dt.Rows[0]["Vote"]);
                    return rev;
                }
            }

            return null;
        }

    }
}