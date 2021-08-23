namespace dots_server_v2.Models
{
    public class AppPackage
    {
        public int AppId { get; set; }
        public App App { get; set; }

        public int PackageId { get; set; }
        public Package Package { get; set; }
    }
}