using System;
using System.ComponentModel;
using HelloWorld.Notes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorld
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoteDetailPage : ContentPage
    {
        private NotesService _noteService = new NotesService();
        public NoteDetailPage(int id)
        {
            InitializeComponent();
            BindingContext = _noteService.GetById(id);
        }

        private void SavedClicked(object sender, EventArgs e)
        {
            // The BindingContext now has all the new values
        }
    }
}