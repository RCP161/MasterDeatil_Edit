using Catel.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M1Vm2.Models
{
    public class Main : ModelBase
    {
        public Main()
        {
            Persons = new ObservableCollection<Person>();

            Person p = new Person(1);
            p.Name = "Person 1";
            Persons.Add(p);

            p = new Person(2);
            p.Name = "Person 2";
            Persons.Add(p);

            p = new Person(3);
            p.Name = "Person 3";
            Persons.Add(p);

            System.Diagnostics.Trace.WriteLine("Ino - M: End Main Konstruktor");
        }

        public ObservableCollection<Person> Persons
        {
            get { return GetValue<ObservableCollection<Person>>(PersonsProperty); }
            set { SetValue(PersonsProperty, value); }
        }
        public static readonly PropertyData PersonsProperty = RegisterProperty(nameof(Persons), typeof(ObservableCollection<Person>));

    }
}
