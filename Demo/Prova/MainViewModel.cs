using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows.Input;
using DevExpress.Mvvm;

namespace Prova
{
    class MainViewModel : ViewModelBase
    {

        public MainViewModel()
        {
            Persone = new ObservableCollection<PersonaViewModel>();
            Persone.Add(new PersonaViewModel() { Nome = "Luca", Cognome = "Giacometti", Telefono = "535355" });
            Persone.Add(new PersonaViewModel() { Nome = "Sasa", Cognome = "Bozic", Telefono = "537557" });
            Persone.Add(new PersonaViewModel() { Nome = "Sebastiano", Cognome = "Lena", Telefono = "372042" });

            PersonaSelezionata = new PersonaViewModel();
            AddCommand = new RelayCommand(Add);
            ImportCommand = new RelayCommand(Import);
        }

        public ObservableCollection<PersonaViewModel> Persone { get; set; }

        public PersonaViewModel PersonaSelezionata
        {
            get { return GetProperty(() => PersonaSelezionata); }
            set { SetProperty(() => PersonaSelezionata, value, UpdatePersonaSelezionata); }
        }
        void UpdatePersonaSelezionata()
        {
            RaisePropertyChanged(() => PersonaSelezionata);
        }


        public ICommand AddCommand { get; set; }
        private void Add(object obj)
        {
            PersonaViewModel persona = new PersonaViewModel()
            {
                Nome = "--",
                Cognome = "--",
                Telefono = "--"
            };
            Persone.Add(persona);
            PersonaSelezionata = persona;
        }


        public ICommand ImportCommand { get; set; }
        private void Import(object obj)
        {
            PersonaViewModel persona = new PersonaViewModel();
            OpenFileDialog openFile = new OpenFileDialog
            {
                Filter = "Text files (*.txt)|*.txt",
                Title = "Importa persona"
            };
            if ((bool)openFile.ShowDialog())
            {
                using (StreamReader stream = new StreamReader(openFile.FileName))
                {
                    persona.Deserializza(stream);
                }
            }
            Persone.Add(persona);
            PersonaSelezionata = persona;
        }
    }
}
