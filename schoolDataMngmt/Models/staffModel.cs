using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schoolDataMngmt
{
    public class staffModel
    {
        public int StaffId { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public int age { get; set; }
        public DateTime? dateOfHire { get; set; }
        public string jobTitle { get; set; }
    }
}
