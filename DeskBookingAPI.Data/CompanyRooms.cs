using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskBookingAPI.Data
{
    public class CompanyRooms
    {
        public int ID { get; set; } 
        public string Name { get; set; }    
        public string Floor { get; set; }  
        public string  Number { get; set; }
        public int CompanyId { get; set; }  
        public Company Company { get; set; }    
        public int DeskId { get; set; } 

    }
}
