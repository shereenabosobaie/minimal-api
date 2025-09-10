namespace WebApplication1.models
{
    public class Student
    {
        public int id { get; set; }
        public string name { get; set; }
        public ICollection<whichschoolcs> whichschoolcs { get; set; }
        public ICollection<whichsubject> whichsubject { get; set; }

    }
}
