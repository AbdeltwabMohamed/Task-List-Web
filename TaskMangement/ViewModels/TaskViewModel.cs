using TaskMangement.Constants;

namespace TaskMangement.ViewModels
{
    public class TaskViewModel
    {
        public int ID { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime dueDate { get; set; }
        public string ?status { get; set; }
        public List<string> consts { get; set; }=new List<string>() { $"{StatusConsts.notStarted}", 
            $"{StatusConsts.Finished}",$"{StatusConsts.InProgress}" };
    }
}
