using Catel.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M1Vm2.Models
{
    public class Person : ModelBase
    {
        public Person(int id)
        {
            Id = id;
            System.Diagnostics.Trace.WriteLine(String.Format("Ino - M: Konstruktor Person ({0} - {1})", id, GetHashCode()));
        }

        public int Id
        {
            get { return GetValue<int>(IdProperty); }
            set { SetValue(IdProperty, value); }
        }
        public static readonly PropertyData IdProperty = RegisterProperty(nameof(Id), typeof(int));

        public string Name
        {
            get { return GetValue<string>(NameProperty); }
            set { SetValue(NameProperty, value); }
        }
        public static readonly PropertyData NameProperty = RegisterProperty(nameof(Name), typeof(string));


        public string Comment
        {
            get { return GetValue<string>(CommentProperty); }
            set{SetValue(CommentProperty, value);}
        }
        public static readonly PropertyData CommentProperty = RegisterProperty(nameof(Comment), typeof(string));



        protected override void OnBeginEdit(BeginEditEventArgs e)
        {
            //System.Diagnostics.Trace.WriteLine(String.Format("Ino - M: Start BeginEdit ({0} - {1})", Id, GetHashCode()));
            base.OnBeginEdit(e);
            System.Diagnostics.Trace.WriteLine(String.Format("Ino - M: End BeginEdit ({0} - {1})", Id, GetHashCode()));
        }

        protected override void OnEndEdit(EditEventArgs e)
        {
            //System.Diagnostics.Trace.WriteLine(String.Format("Ino - M: Start EndEdit ({0} - {1})", Id, GetHashCode()));
            base.OnEndEdit(e);
            System.Diagnostics.Trace.WriteLine(String.Format("Ino - M: End EndEdit ({0} - {1})", Id, GetHashCode()));
        }

        protected override void OnCancelEdit(EditEventArgs e)
        {
            //System.Diagnostics.Trace.WriteLine(String.Format("Ino - M: Start EndEdit ({0} - {1})", Id GetHashCode()));
            base.OnCancelEdit(e);
            System.Diagnostics.Trace.WriteLine(String.Format("Ino - M: End EndEdit ({0} - {1})", Id, GetHashCode()));
        }

        protected override void OnPropertyChanged(AdvancedPropertyChangedEventArgs e)
        {
            System.Diagnostics.Trace.WriteLine(String.Format("Ino- M: Property changed:  {0}", e.PropertyName));
            base.OnPropertyChanged(e);
        }
    }
}
