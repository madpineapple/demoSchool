using Dapper;
using schoolDataMngmt;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schoolDataMngmt
{
   public class ClassDataAccess
    {
        public static void CreateNew(classModel klass)
        {
            using (IDbConnection cnn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=rockBottomHigh_DB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                cnn.Query<classModel>("insert into Class(TeacherId, topic, grade) values(@TeacherId, @topic, @grade)", klass);

            }
        }
    }
}
