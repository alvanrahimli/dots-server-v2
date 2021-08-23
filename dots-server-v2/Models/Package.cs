using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using dots_server_v2.Models.Enums;

namespace dots_server_v2.Models
{
    public class Package
    {
        [Key]
        public string Name { get; set; }
        public string Version { get; set; }
        
        public DateTime Timestamp { get; set; }
        public Visibility Visibility { get; set; }

        public int Rating { get; set; }
        public int InstallCount { get; set; }

        public int UserId { get; set; }
        public DotsUser User { get; set; }

        public List<AppPackage> AppsPackages { get; set; }
        public List<Screenshot> Screenshots { get; set; }
    }
}