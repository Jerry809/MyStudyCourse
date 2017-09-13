using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Data.SqlClient;

namespace ThreadCourse
{
    class Program
    {
        static void Main(string[] args)
        {
            //var oper = new Oper();
            var tasks = new List<Task>();
            //for (int i = 0; i < 100; i++)
            //{
            //    var task = Task.Run(()=> {
            //        oper.Add(1);
            //    });
            //    tasks.Add(task);
            //}
            //Task.WaitAll(tasks.ToArray());

            for (int i = 0; i < 10; i++)
            {
                var a =  new db().Write(i.ToString());
            }
            //Task.WaitAll(tasks.ToArray());

            //db.Write("123");
            //Console.WriteLine($"income = {oper.GetIncome()}");
            Console.ReadLine();
        }
    }

    public class db
    {
        private static string connString = "Data Source=3192F30058\\SQLEXPRESS;Initial Catalog=VW; Persist Security Info = True; User ID = sa; Password = Abc12341234";

        public async Task Write(string message)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "insert into message (message) values(@message)";
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddRange(sqlParameterList.ToArray());
                    try
                    {
                        conn.Open();
                        cmd.Parameters.AddWithValue("@message", message);
                        await cmd.ExecuteNonQueryAsync();
                    }
                    catch (InvalidOperationException ex)
                    {
                        throw ex;
                    }
                }
            }
        }

    }



    public class Oper
    {
        private int _income = 0;

        public int Add(int value)
        {
            lock (this)
            {
                return _income += value;
            }
        }

        public int GetIncome()
        {
            return _income;
        }
    }
}

//https://dotblogs.com.tw/mantou1201/2013/10/26/125704

//CREATE TABLE[dbo].[ActionLog](
//	[LogId]
//[bigint] IDENTITY(0,1) NOT NULL,

//[Operator] [varchar](10) NOT NULL,

//[Refer] [varchar](300) NULL,
//	[Destination]
//[varchar](300) NOT NULL,

//[Method] [varchar](5) NULL,
//	[MobleDevices]
//[bit]
//NOT NULL,

//    [IPAddress] [varchar](40) NULL,
//	[RequestTime]
//[datetime2](7) NOT NULL,
//CONSTRAINT[PK_ActionLog_1] PRIMARY KEY CLUSTERED
//(
//[LogId] ASC
//)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]
//) ON[PRIMARY]