using System;
using System.ComponentModel.DataAnnotations;

namespace dots_server_v2.Models
{
    public class Screenshot
    {
        [Key]
        public Guid Name { get; set; }
        public string ImagePath { get; set; }

        public int PackageId { get; set; }
        public Package Package { get; set; }
    }
}