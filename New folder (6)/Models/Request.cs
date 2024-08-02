using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HorasExtra.Models
{
    public class Request
    {
        [Key]
        public int ID_request { get; set; }
        public string Operation { get; set; }
        public string Department { get; set; }
        public string WorkSchedule { get; set; }
        public string ManagerSignature { get; set; }
        public string SupervisorSignature { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public List<Employees> Employees { get; set; }
    }
}