namespace WebApplication1.models
{
    public class School
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<whichschoolcs> whichschoolcs { get; set; }

    }
}
