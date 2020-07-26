using System;
using System.ComponentModel.DataAnnotations;

namespace Shared.Dtos {
    public class EventDataUpdateDto {

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime ExpirationTime { get; set; }

    }
}
