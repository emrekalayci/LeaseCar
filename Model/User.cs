using System;
using System.Data;
using System.Data.SqlClient;

namespace TermProject.Model
{
    public class Userr
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string BirthDay { get; set; }
        public string PhoneNumber { get; set; }
        public int UserType { get; set; }
        public string RegistrationDate { get; set; }
        //public bool Confirmation { get; set; }
        //public int ConfirmationNumber { get; set; }
    }

    public class UserDb
    {
        public static bool Save(Userr u)
        { 
            SqlParameter[] parameters = new SqlParameter[]
            {  
                new SqlParameter("@FullName", u.FullName),
                new SqlParameter("@Password", u.Password),
                new SqlParameter("@UserName", u.Username),
                new SqlParameter("@Email", u.Email),
                new SqlParameter("@PhoneNumber", u.PhoneNumber),
                new SqlParameter("@BirthDay", u.BirthDay),
                new SqlParameter("@UserType",u.UserType),
                new SqlParameter("@RegistrationDate", u.RegistrationDate)
            };

            string insertCommand = "INSERT INTO Users VALUES(@Email, @Password, @UserName, @FullName, @PhoneNumber, @BirthDay, @UserType, @RegistrationDate)";

            DataAccess dbAcess = new DataAccess();
            bool executeResult = dbAcess.ExecuteNonQuery(insertCommand, CommandType.Text, parameters);

            return executeResult;  
        }

        public static Userr GetUser(Userr u)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {  
                new SqlParameter("@UserName", u.Username),
                new SqlParameter("@Password", u.Password)
            };

            string query = "SELECT * FROM Users WHERE UserName = @UserName AND Password = @Password";

            DataAccess dbAcess = new DataAccess();
            DataTable dt = dbAcess.ExecuteParamerizedSelectCommand(query, CommandType.Text, parameters);

            if(dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    Userr user = new Userr();
                    user.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                    user.Username = dt.Rows[0]["UserName"].ToString();
                    user.Email = dt.Rows[0]["Email"].ToString();
                    user.PhoneNumber = dt.Rows[0]["PhoneNumber"].ToString();
                    user.BirthDay = dt.Rows[0]["Birthday"].ToString();
                    user.UserType = Convert.ToInt32(dt.Rows[0]["UserType"]);
                    user.RegistrationDate = dt.Rows[0]["RegistrationDate"].ToString();
                    return user;
                }
            }

            return null;
        }

        public static Userr GetUserById(object sessionId)
        {
            int id = Convert.ToInt32(sessionId);

            SqlParameter[] parameters = new SqlParameter[]
            {  
                new SqlParameter("@Id", id)
            };

            string query = "SELECT * FROM Users WHERE Id = @Id";

            DataAccess dbAcess = new DataAccess();
            DataTable dt = dbAcess.ExecuteParamerizedSelectCommand(query, CommandType.Text, parameters);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    Userr user = new Userr();
                    user.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                    user.Username = dt.Rows[0]["UserName"].ToString();
                    user.Email = dt.Rows[0]["Email"].ToString();
                    user.FullName = dt.Rows[0]["FullName"].ToString();
                    user.PhoneNumber = dt.Rows[0]["PhoneNumber"].ToString();
                    user.BirthDay = dt.Rows[0]["Birthday"].ToString();
                    user.UserType = Convert.ToInt32(dt.Rows[0]["UserType"]);
                    user.RegistrationDate = dt.Rows[0]["RegistrationDate"].ToString();
                    return user;
                }
            }

            return null;
        }

        public static Userr GetUserById(int id)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {  
                new SqlParameter("@Id", id)
            };

            string query = "SELECT * FROM Users WHERE Id = @Id";

            DataAccess dbAcess = new DataAccess();
            DataTable dt = dbAcess.ExecuteParamerizedSelectCommand(query, CommandType.Text, parameters);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    Userr user = new Userr();
                    user.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                    user.Username = dt.Rows[0]["UserName"].ToString();
                    user.FullName = dt.Rows[0]["FullName"].ToString();
                    user.Email = dt.Rows[0]["Email"].ToString();
                    user.PhoneNumber = dt.Rows[0]["PhoneNumber"].ToString();
                    user.BirthDay = dt.Rows[0]["Birthday"].ToString();
                    user.UserType = Convert.ToInt32(dt.Rows[0]["UserType"]);
                    user.RegistrationDate = dt.Rows[0]["RegistrationDate"].ToString();
                    return user;
                }
            }

            return null;
        }

        public static bool Update(Userr u)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {  
                new SqlParameter("@Id", u.Id),
                new SqlParameter("@FullName", u.FullName),
                new SqlParameter("@Email", u.Email),
                new SqlParameter("@PhoneNumber", u.PhoneNumber),
            };

            string query = "UPDATE Users SET FullName = @FullName, Email = @Email, PhoneNumber = @PhoneNumber WHERE Id = @Id";

            DataAccess dbAcess = new DataAccess();

            return dbAcess.ExecuteNonQuery(query, CommandType.Text, parameters);
        }


    }


}