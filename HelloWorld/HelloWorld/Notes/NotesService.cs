using System.Collections.Generic;
using HelloWorld.Models;
using System.Linq;
using System;

namespace HelloWorld.Notes
{
    public class NotesService
    {
        private Note[] listNotes = new Note[]
        {
            new Note { Id=1, Title = "Note 1", Text = "Lorem Ipsum 1", CheckBoxDemo = false, DatePickerDemo = DateTime.Today.AddDays(-4), SliderDemo=27, StepperDemo = 20, SwitchDemo = true, TimeDemo = new TimeSpan(6,0,0) },
            new Note { Id=2, Title = "Note 2", Text = "Lorem Ipsum 2", CheckBoxDemo = true, DatePickerDemo = DateTime.Today.AddDays(-3), SliderDemo=30, StepperDemo = 30, SwitchDemo = false, TimeDemo = new TimeSpan(8,0,0) },
            new Note { Id=3, Title = "Note 3", Text = "Lorem Ipsum 3", CheckBoxDemo = false, DatePickerDemo = DateTime.Today.AddDays(-2), SliderDemo=14, StepperDemo = 50, SwitchDemo = true, TimeDemo = new TimeSpan(12,0,0) },
            new Note { Id=4, Title = "Note 4", Text = "Lorem Ipsum 4", CheckBoxDemo = true, DatePickerDemo = DateTime.Today.AddDays(-1), SliderDemo=47, StepperDemo = 80, SwitchDemo = false, TimeDemo = new TimeSpan(16,0,0) }
        };

        public Note GetById(int i)
        {
            return listNotes.First(n => n.Id == i);
        }

        public IEnumerable<Note> GetAllNodes()
        {
            return listNotes;
        }
    }
}
