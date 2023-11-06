using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Exam
    {
        public Student Student { get; set; }
        public string Subject { get; set; }
        public byte Point { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set;}
    }
}
