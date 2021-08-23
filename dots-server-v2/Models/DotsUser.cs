using System.Collections.Generic;

namespace dots_server_v2.Models
{
    public class DotsUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public List<Package> Packages { get; set; }
    }
}