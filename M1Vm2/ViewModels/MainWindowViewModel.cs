namespace M1Vm2.ViewModels
{
    using Catel.Data;
    using Catel.Linq;
    using Catel.MVVM;
    using M1Vm2.Models;
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Threading.Tasks;

    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            Model = new Main();

            IsInEditMode = false;
            EditCommand = new Command(Edit, () => true);
            RevertCommand = new Command(Revert, () => true);
            SaveCommand = new Command(Save, () => true);
            ModifyModelCommand = new Command(ModifyModel, () => true);

            //Model.PropertyChanged += Model_PropertyChanged;
            //PropertyChanged += CustomerVm_PropertyChanged;

            System.Diagnostics.Trace.WriteLine("Ino - VM: Start Konstruktor");

        }

        //private void CustomerVm_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        //{
        //    System.Diagnostics.Trace.WriteLine(String.Format("Ino - VM: Property changed: {0}", e.PropertyName));
        //}

        //private void Model_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        //{
        //    System.Diagnostics.Trace.WriteLine(String.Format("Ino- M: Property changed:  {0}", e.PropertyName));
        //}


        [Model]
        public Main Model
        {
            get { return GetValue<Main>(ModelProperty); }
            private set { SetValue(ModelProperty, value); }
        }
        public static readonly PropertyData ModelProperty = RegisterProperty(nameof(Model), typeof(Main));


        [ViewModelToModel]
        public ObservableCollection<Person> Persons
        {
            get { return GetValue<ObservableCollection<Person>>(PersonsProperty); }
            set { SetValue(PersonsProperty, value); }
        }
        public static readonly PropertyData PersonsProperty = RegisterProperty(nameof(Persons), typeof(ObservableCollection<Person>));


        public Person SelectedPerson
        {
            get { return GetValue<Person>(SelectedPersonProperty); }
            set { SetValue(SelectedPersonProperty, value); }
        }
        public static readonly PropertyData SelectedPersonProperty = RegisterProperty(nameof(SelectedPerson), typeof(Person));


        public bool IsInEditMode
        {
            get { return GetValue<bool>(IsInEditModeProperty); }
            set { SetValue(IsInEditModeProperty, value); }
        }
        public static readonly PropertyData IsInEditModeProperty = RegisterProperty(nameof(IsInEditMode), typeof(bool));

        public Command EditCommand { get; private set; }
        public Command RevertCommand { get; private set; }
        public Command SaveCommand { get; private set; }
        public Command ModifyModelCommand { get; private set; }


        public void Save()
        {
            IsInEditMode = false;
            SaveViewModelAsync();
        }

        public void Revert()
        {
            IsInEditMode = false;
            CancelViewModelAsync();

        }

        public void Edit()
        {
            IsInEditMode = true;
        }

        public void ModifyModel()
        {
            SelectedPerson.Name = SelectedPerson.Name + "X";
        }
    }
}
