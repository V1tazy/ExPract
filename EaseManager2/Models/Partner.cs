using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaseManager2.Models
{
    public class Partner
    {
        public int Id { get; set; }
        public string PartnerType { get; set; }
        public string Name { get; set; }
        public string Director { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Inn { get; set; }
        public int Rating { get; set; }
    }
}
