namespace M1Vm2.ViewModels
{
    using Catel.Data;
    using Catel.MVVM;
    using M1Vm2.Models;
    using System;
    using System.ComponentModel;
    using System.Threading.Tasks;

    public class PersonTreeViewModel : ViewModelBase
    {
        public PersonTreeViewModel(Person model)
        {
            Model = model;
            System.Diagnostics.Trace.WriteLine(String.Format("Ino - TVM: Konstruktor Person ({0} - {1})", Id, GetHashCode()));
            System.Diagnostics.Trace.WriteLine(String.Format("Ino - TVM: Konstruktor Model ({0} - {1})", Id, Model.GetHashCode()));
            Comment = String.Format("VM: {0} - M: {1}", GetHashCode(), Model.GetHashCode());
        }

        [Model]
        public Person Model
        {
            get { return GetValue<Person>(ModelProperty); }
            private set { SetValue(ModelProperty, value); }
        }
        public static readonly PropertyData ModelProperty = RegisterProperty(nameof(Model), typeof(Person));


        [ViewModelToModel]
        public int Id
        {
            get { return GetValue<int>(IdProperty); }
            set { SetValue(IdProperty, value); }
        }
        public static readonly PropertyData IdProperty = RegisterProperty(nameof(Id), typeof(int));

        [ViewModelToModel]
        public string Name
        {
            get { return GetValue<string>(NameProperty); }
            set
            {
                SetValue(NameProperty, value);
                System.Diagnostics.Trace.WriteLine(String.Format("Ino - TVM: Name set to {0} ({1} - {2})", value, Id, GetHashCode()));
                System.Diagnostics.Trace.WriteLine(String.Format("Ino - M: Name set to {0} ({1} - {2})", Model.Name, Model.Id, Model.GetHashCode()));
            }
        }

        public static readonly PropertyData NameProperty = RegisterProperty(nameof(Name), typeof(string));


        [ViewModelToModel]
        public string Comment
        {
            get { return GetValue<string>(CommentProperty); }
            set { SetValue(CommentProperty, value); }
        }

        public static readonly PropertyData CommentProperty = RegisterProperty(nameof(Comment), typeof(string));



        protected override void OnBeginEdit(BeginEditEventArgs e)
        {
            //System.Diagnostics.Trace.WriteLine(String.Format("Ino - TVM: Start BeginEdit ({0} - {1})", Id, GetHashCode()));
            base.OnBeginEdit(e);
            System.Diagnostics.Trace.WriteLine(String.Format("Ino - TVM: End BeginEdit ({0} - {1})", Id, GetHashCode()));
        }

        protected override void OnEndEdit(EditEventArgs e)
        {
            //System.Diagnostics.Trace.WriteLine(String.Format("Ino - TVM: Start EndEdit ({0} - {1})", Id, GetHashCode()));
            base.OnEndEdit(e);
            System.Diagnostics.Trace.WriteLine(String.Format("Ino - TVM: End EndEdit ({0} - {1})", Id, GetHashCode()));
        }

        protected override void OnCancelEdit(EditEventArgs e)
        {
            //System.Diagnostics.Trace.WriteLine(String.Format("Ino - TVM: Start EndEdit ({0} - {1})", Id GetHashCode()));
            base.OnCancelEdit(e);
            System.Diagnostics.Trace.WriteLine(String.Format("Ino - TVM: End EndEdit ({0} - {1})", Id, GetHashCode()));
        }

        protected override Task<bool> SaveAsync()
        {
            System.Diagnostics.Trace.WriteLine(String.Format("Ino - TVM: Start SaveAsync ({0} - {1})", Id, GetHashCode()));
            return base.SaveAsync();
        }

        protected override Task<bool> CancelAsync()
        {
            System.Diagnostics.Trace.WriteLine(String.Format("Ino - TVM: Start CancelAsync ({0} - {1})", Id, GetHashCode()));
            return base.CancelAsync();
        }
    }
}
