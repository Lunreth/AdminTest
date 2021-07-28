using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Domain;
using Dapper;

namespace DAL
{
    public class UsersDAL
    {
        public static Users CheckLogin(Users obj)
        {
            string sqlQuery = "SELECT Username, Password FROM users_table WHERE (Username = @Username) AND (Password = @Password)";

            using (var con = ConnectionUtil.GetConnection())
            {
                return con.Query<Users>(sqlQuery, obj).FirstOrDefault();
            }
        }

        public static bool Insert(Users user)
        {
            string sql_string = "INSERT INTO users_table (Username, Password, Firstname, Lastname) VALUES (@Username, @Password, @Firstname, @Lastname)";

            using (var con = ConnectionUtil.GetConnection())
            {
                return con.Execute(sql_string, user) > 0;
            }
        }

        public static List<Users> FetchList()
        {
            string sql_string = "SELECT Id, Username, Firstname, Lastname FROM users_table";
            using (var con = ConnectionUtil.GetConnection())
            {
                return con.Query<Users>(sql_string).ToList();
            }
        }
    }
}
