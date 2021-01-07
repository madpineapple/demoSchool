using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace schoolDataMngmt
{
    public class StaffDataAccess
    {

        public static List<staffModel> LoadStaff()
        {
            using (IDbConnection cnn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=rockBottomHigh_DB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                var output = cnn.Query<staffModel>("select* from staff ", new DynamicParameters());
                return output.ToList();
            }

        }
        public static List<staffModel> SelectStaff(int id)
        {
            using (IDbConnection cnn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=rockBottomHigh_DB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                var output = cnn.Query<staffModel>("select* from staff where StaffId=" + id + "");
                return output.ToList();
            }

        }

        public static void CreateNewStaff(staffModel staff)
        {
            using (IDbConnection cnn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=rockBottomHigh_DB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                cnn.Query<staffModel>("insert into staff (fname, lname,age, dateOfHire,jobTitle) values(@fname, @lname, @age, @dateOfHire, @jobTitle)", staff);
            }
        }
        public static void UpdateStaff(staffModel staff)
        {
            using (IDbConnection cnn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=rockBottomHigh_DB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                cnn.Query<staffModel>("update staff set fname=(@fname), lname=(@lname), age=(@age), dateOfHire=(@dateOfHire), jobTitle=(@jobTitle) where StaffId=(@StaffId)", staff);

            }
        }
        public static void DeleteStaff(int i)
        {
            using (IDbConnection cnn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=rockBottomHigh_DB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                cnn.Execute("delete from staff where StaffId = " + i + "");

            }
        }

    }
}

