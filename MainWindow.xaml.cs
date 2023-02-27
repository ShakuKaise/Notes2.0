using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Notes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<Note> notes = Serializer.Deserialize();
            if (notes == null)
            {
                notes = new List<Note>();
            }
            Date.SelectedDate = DateTime.Now;
            Serializer.Serialize(notes);
            ViewNotes();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            List<Note> notes = Serializer.Deserialize();
            foreach (Note note in notes)
            {
                if (Viewer.SelectedItem == note)
                {
                    notes.Remove(note);
                }
            }

            Serializer.Serialize(notes);
            ViewNotes();
        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            List<Note> notes = Serializer.Deserialize();
            if (notes == null)
            {
                notes = new List<Note>();
            }
            Note note = new Note();

            note.name = Name.Text;
            note.description = Description.Text;
            note.date = DateTime.Parse(Date.Text);

            notes.Add(note);
            Serializer.Serialize(notes);
            
            ViewNotes();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            List<Note> notes = Serializer.Deserialize();
            foreach (Note note in notes)
            {
                if (Viewer.SelectedItem == note)
                {
                    notes.Remove(note);
                }
            }

            Serializer.Serialize(notes);
            ViewNotes();
        }

        private void ViewNotes()
        {
            List<Note> notes = Serializer.Deserialize();
            List<Note> CheckedNotes = new List<Note>();
            foreach (Note note in notes)
            {
                if (note.date == Date.SelectedDate)
                {
                    CheckedNotes.Add(note);
                }
            }
            Viewer.ItemsSource = CheckedNotes;
        }
    }
}
