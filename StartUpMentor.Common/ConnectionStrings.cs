using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartUpMentor.Common
{
    public static class ConnectionStrings
    {
        public const string CONNECTION = "StartUpMentorContext";
        public const string TEST_DB_CONNECTION = "Data Source=.\\SQLEXPRESS;Initial Catalog=TestStartUpMentorContext;Integrated Security=True;MultipleActiveResultSets=True";
    }
}
