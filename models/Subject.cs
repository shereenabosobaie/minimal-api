namespace WebApplication1.models
{
    public class Subject
    {
        public int id { get; set; }
        public string name { get; set; }
        public int grade { get; set; }
        public ICollection<whichsubject> whichsubject { get; set; }

    }
}
