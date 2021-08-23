using System.Collections.Generic;

namespace dots_server_v2.Models
{
    public class App
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }

        public List<AppPackage> AppPackages { get; set; }
    }
}