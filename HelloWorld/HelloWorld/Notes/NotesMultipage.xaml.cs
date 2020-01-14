using HelloWorld.Notes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HelloWorld.Models;
using System;
using System.Collections.ObjectModel;

namespace HelloWorld
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotesMultipage : ContentPage
    {
        private NotesService _noteService = new NotesService();
        private ObservableCollection<Note> notes => new ObservableCollection<Note>(_noteService.GetAllNodes());
        public NotesMultipage()
        {
            InitializeComponent();
            BindingContext = notes;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private void listView_ViewNote(object sender, SelectedItemChangedEventArgs e)
        {
            var p = new NoteDetailPage(((Note)((CollectionView)sender).SelectedItem).Id);
            p.Disappearing += OnDisapearing;
            Navigation.PushAsync(p);
        }

        private void OnDisapearing(object sender, EventArgs e)
        {
            _ = BindingContext;
        }
    }
}