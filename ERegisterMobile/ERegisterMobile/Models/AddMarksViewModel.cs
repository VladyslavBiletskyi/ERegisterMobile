using System.Collections.Generic;

namespace ERegisterMobile.Models
{
    public class AddMarksViewModel
    {
        public int LessonId { get; set; }
        public List<MarkViewModel> Marks { get; set; }
    }
}