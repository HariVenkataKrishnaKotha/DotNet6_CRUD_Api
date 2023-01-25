namespace DotNetAPI.Models
{
    public class Team
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public int Championships { get; set; }
        public long Fanbase { get; set;}
    }
}
