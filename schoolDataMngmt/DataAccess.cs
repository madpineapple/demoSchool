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
    class DataAccess
    {

        public static List<teacherModel> LoadTeachers()
        {
            using (IDbConnection cnn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=rockBottomHigh_DB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                var output = cnn.Query<teacherModel>("select* from teachers ", new DynamicParameters());
                return output.ToList();
            }

        }
        public static List<teacherModel> SelectTeacher(int id)
        {
            using (IDbConnection cnn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=rockBottomHigh_DB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                var output = cnn.Query<teacherModel>("select* from teachers where TeacherId=" + id + "");
                return output.ToList();
            }

        }

        public static void CreateNew(teacherModel teacher)
        {
            using (IDbConnection cnn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=rockBottomHigh_DB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                cnn.Query<teacherModel>("insert into teachers (fname, lname, expertise, age, dateOfHire) values(@fname, @lname, @expertise, @age, @dateOfHire)", teacher);

            }
        }
        public static void Update(teacherModel teacher)
        {
            using (IDbConnection cnn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=rockBottomHigh_DB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                cnn.Query<teacherModel>("update teachers set fname=(@fname), lname=(@lname), expertise=(@expertise), age=(@age), dateOfHire=(@dateOfHire) where TeacherId=(@TeacherId)", teacher);

            }
        }
        public static void Delete(int i)
        {
            using (IDbConnection cnn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=rockBottomHigh_DB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                cnn.Execute("delete from teachers where TeacherId = " + i + "");

            }
        }

    }
}
