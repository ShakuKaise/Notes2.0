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
using static System.Net.Mime.MediaTypeNames;

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

            notes[Viewer.SelectedIndex].name = Name.Text;
            notes[Viewer.SelectedIndex].description = Description.Text;

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
            notes.RemoveAt(Viewer.SelectedIndex);
            ViewNotes();
            try
            {
                
            }
            catch
            {
                ViewNotes();
            }
            Serializer.Serialize(notes);
            notes = Serializer.Deserialize();

            ViewNotes();
        }

        private void ViewNotes() // я чёт вообще туплю, не могу понять как нормально привязать значения записок к столбцам.
        {
            
            List<Note> notes = Serializer.Deserialize();
            Viewer.Items.Clear();
            foreach (Note note in notes)
            {
                if (note.date == Date.SelectedDate)
                {
                    Viewer.Items.Add(note.name);
                }

            }
        }

        private void ChangedDate(object sender, SelectionChangedEventArgs e)
        {
            ViewNotes();
        }

        private void Viewer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                List<Note> notes = Serializer.Deserialize();
                Name.Text = notes[Viewer.SelectedIndex].name.ToString();
                Description.Text = notes[Viewer.SelectedIndex].description.ToString();
            }
            catch
            {
                
            }
        }
    }
}
