using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schoolDataMngmt
{
    public class studentModel
    {
        public int StudentId { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public int age { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? dateOfEnrollment { get; set; }
        public int grade { get; set; }
        public bool passing { get; set; }
    }
}
