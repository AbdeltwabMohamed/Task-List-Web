using System.ComponentModel.DataAnnotations;
using TaskMangement.Constants;

namespace TaskMangement.ViewModels
{
    public class TaskViewModel
    {
        public int ID { get; set; }

        public string? UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        //[] Create Validation attribute here to handle that time must be not less than now
        public DateTime dueDate { get; set; }
        public string ?status { get; set; }
        public List<string> consts { get; set; }=new List<string>() { $"{StatusConsts.notStarted}", 
            $"{StatusConsts.Finished}",$"{StatusConsts.InProgress}" };
    }
}
