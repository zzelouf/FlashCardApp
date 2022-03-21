using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flashcardApp.Models
{
    public class Card
    {
        public int CardId { get; set; }
        public string Term { get; set; }
        public string Definition { get; set; }
        public string CodeExample { get; set; }
        public string InterviewQs { get; set; }
        public int UnitId { get; set; }


    }
}
