using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schoolDataMngmt
{
    public class StudentDataAccess
    {

        public static List<studentModel> LoadStudents()
        {
            using (IDbConnection cnn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=rockBottomHigh_DB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                var output = cnn.Query<studentModel>("select* from students ", new DynamicParameters());
                return output.ToList();
            }

        }

        public static List<studentModel> LoadStudentName()
        {
            using (IDbConnection cnn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=rockBottomHigh_DB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                var output = cnn.Query<studentModel>("select fname from students where grade=9; ", new DynamicParameters());
                return output.ToList();
            }

        }
        public static List<studentModel> SelectStudent(int id)
        {
            using (IDbConnection cnn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=rockBottomHigh_DB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                var output = cnn.Query<studentModel>("select* from students where StudentId=" + id + "");
                return output.ToList();
            }

        }

        public static void CreateNew(studentModel student)
        {
            using (IDbConnection cnn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=rockBottomHigh_DB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                cnn.Query<studentModel>("insert into students (fname, lname, dateOfEnrollment, age, grade, GPA) values(@fname, @lname, @dateOfEnrollment, @age, @grade, @GPA)", student);

            }
        }
        public static void Update(studentModel student)
        {
            using (IDbConnection cnn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=rockBottomHigh_DB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                cnn.Query<studentModel>("update students set fname=(@fname), lname=(@lname), dateOfEnrollment=(@dateOfEnrollment), age=(@age), grade=(@grade), GPA=(@GPA) where StudentId=(@StudentId)", student);

            }
        }
        public static void Delete(int i)
        {
            using (IDbConnection cnn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=rockBottomHigh_DB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                cnn.Execute("delete from students where StudentId = " + i + "");

            }
        }

    }
}
