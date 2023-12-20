namespace TaskMangement.Models
{
    public class DoList
    {
        
        public int ID { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime dueDate { get; set; }
        public string ?status { get; set; }
    }
}
