using System;
using System.Collections;

namespace SortedListExample
{

    public class NoteCollection
    {
        private SortedList notes;


        public NoteCollection()
        {
            notes = new SortedList();
        }


        public void AddNotes(int count)
        {
            for (int i = 0; i < count; i++)
            {
                string noteName = $"Нота {i + 1}";
                notes.Add(noteName, noteName);
            }
        }


        public void DisplayNotesForward()
        {
            Console.WriteLine("Ноти в прямому порядку:");
            foreach (var note in notes.Values)
            {
                Console.WriteLine(note);
            }
        }


        public void DisplayNotesReverse()
        {
            Console.WriteLine("Ноти у зворотному порядку:");
            for (int i = notes.Count - 1; i >= 0; i--)
            {
                Console.WriteLine(notes.GetByIndex(i));
            }
        }


        public int GetNoteCount()
        {
            return notes.Count;
        }


        public void ClearNotes()
        {
            notes.Clear();
        }
    }

    public class Program
    {
        public static void Main()
        {

            var noteCollection = new NoteCollection();


            noteCollection.AddNotes(4);


            noteCollection.DisplayNotesForward();

            noteCollection.DisplayNotesReverse();


            int noteCount = noteCollection.GetNoteCount();
            Console.WriteLine($"Кількість нот {noteCount}");


            noteCollection.ClearNotes();


            noteCollection.DisplayNotesForward();
        }
    }
}