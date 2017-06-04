using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace WpfApplication7
{
    public class StudentProgram
    {
        public StudentProgram() {
            // Opfer initialisieren...
            studentPartners = new ObservableCollection<Person>();
            //studentPartners.Add(new Person() { Name = "Jan Molnar", WrittenLinesOfCode = 121930 });
            studentPartners.Add(new Person() { Name = "Tobias Grass", WrittenLinesOfCode = 21798 });
            studentPartners.Add(new Person() { Name = "Dennis Zielke", WrittenLinesOfCode = 921831 });
            studentPartners.Add(new Person() { Name = "Dennis Paulenz", WrittenLinesOfCode = 81293 });
            //studentPartners.Add(new Person() { Name = "Andreas Maier", WrittenLinesOfCode = 81293 });
            //studentPartners.Add(new Person() { Name = "Immo Landweh", WrittenLinesOfCode = 81293 });
            studentPartners.Add(new Person() { Name = "Alex Bierhaus", WrittenLinesOfCode = 911239 });
            studentPartners.Add(new Person() { Name = "Felix Leitner", WrittenLinesOfCode = 12390 });
        }

        private ObservableCollection<Person> studentPartners;

        public ObservableCollection<Person> StudentPartners {
            get { return studentPartners; }
        }

        public int Budget { get; set; }
    }
}
