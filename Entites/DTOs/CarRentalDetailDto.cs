using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
   public class CarRentalDetailDto:IDto
    {
        public string CustomerName { get; set; }
        public string Description { get; set; }
        public DateTime RentTime  { get; set; }
        public DateTime ReturnTime { get; set; }
    }
}
