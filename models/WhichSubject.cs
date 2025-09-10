namespace WebApplication1.models
{
    public class whichsubject
    {
        public int subjectID { get; set; }
        public int studentID { get; set; }
        public Student student { get; set; }
        public Subject Subject { get; set; }
    }
}
