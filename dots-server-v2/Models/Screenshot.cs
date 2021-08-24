using System;
using System.ComponentModel.DataAnnotations;

namespace dots_server_v2.Models
{
    public class Screenshot
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }

        
        public Package Package { get; set; }
    }
}