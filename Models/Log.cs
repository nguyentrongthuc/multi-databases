using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoggingService.Models
{
    public class Log
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid LogId { get; set; }
        public Guid LogTypeId { get; set; }
        [MaxLength(240)]
        public string Code { get; set; }
        public string Comment { get; set; }
        public Guid UserId { get; set; }
        [MaxLength(250)]
        public string Username { get; set; }
        [MaxLength(50)]
        public string UserType { get; set; }
        [MaxLength(250)]
        public string DeviceType { get; set; }
        [MaxLength(100)]
        public string IP { get; set; }
        public string OS { get; set; }
        public Guid CampusId { get; set; }
        [MaxLength(50)]
        public string Action { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Logs { get; set; }
    }
}