using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Models
{
    public class Question
    {
        public string ID { get; set; }
        public string question { get; set; }
        public double option1 { get; set; }
        public double option2 { get; set; }
        public double option3 { get; set; }
        public double answer { get; set; }
    }
}
