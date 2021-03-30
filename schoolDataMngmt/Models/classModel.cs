using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schoolDataMngmt
{
    public class classModel
    {
        public int ClassId { get; set; }
        public int TeacherId { get; set; }

        public string topic { get; set; }
        public int grade { get; set; }
    }
}
