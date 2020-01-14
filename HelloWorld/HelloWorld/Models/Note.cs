using System;

namespace HelloWorld.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }
        public DateTime DatePickerDemo { get; set; }
        public bool CheckBoxDemo { get; set; }
        public bool SwitchDemo { get; set; }
        public TimeSpan TimeDemo { get; set; }
        public int StepperDemo { get; set; }
        public int SliderDemo { get; set; }
    }
}
