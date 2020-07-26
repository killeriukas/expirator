using System;
using System.ComponentModel.DataAnnotations;

namespace Expirator.Dtos {
    public class EventDataCreateDto {

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime ExpirationTime { get; set; }

    }
}
