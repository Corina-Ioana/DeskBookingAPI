using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DeskBookingAPI.Data
{
    public class Company
    {
        
        public int ID { get; set; }
        public string? Name { get; set; }
        public   string Address { get; set; }
        [JsonIgnore]
        public List<Employee>? Employees { get; set; }
        [JsonIgnore]
        public List<CompanyRooms>? CompanyRooms { get; set; }

    }
}
