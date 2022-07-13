using DeskBookingAPI.Data.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskBookingAPI.Data
{
    public class Desk
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public Boolean IsStanding;

        public int CompanyRoomsId {get; set;}
       public CompanyRooms CompanyRooms { get; set; }  

    }
}
