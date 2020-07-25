using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Expirator.Dtos {
    public class EventDataCreateDto {

        public string Name { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime ExpirationTime { get; set; }

    }
}
