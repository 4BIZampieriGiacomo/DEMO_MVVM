using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.ComponentModel;
using Microsoft.Win32;
using System.IO;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using System.Xml.Serialization;

namespace MVVMStage
{
    class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            Persone = new ObservableCollection<PersonaViewModel>();
            this.Persone.Add(new PersonaViewModel() { Nome = "Marco", Cognome = "a", Telefono = "1234"});
            this.Persone.Add(new PersonaViewModel() { Nome = "Mattia", Cognome = "b", Telefono = "4321" });
            this.Persone.Add(new PersonaViewModel() { Nome = "Sasa", Cognome = "c", Telefono = "1111" });
            this.Apri = new RelayCommand(Open, x => PossoEseguire);
            //this.Aggiungi = new RelayCommand(Add);
            //DelegateCommand Aggiungi = new DelegateCommand(Add);

        }

        public ObservableCollection<PersonaViewModel> Persone { get; set; }

        private PersonaViewModel personaSelezionata;
        public PersonaViewModel PersonaSelezionata
        {
            get { return personaSelezionata; }
            set { personaSelezionata = value; RaisePropertyChanged();Save(); }
        }

        public bool PossoEseguire { get; set; } = true;




        //-------ICOMMAND SOSTITUITO-------//
        DelegateCommand<PersonaViewModel> aggiungi;
        public DelegateCommand<PersonaViewModel> Aggiungi
        {
            get
            {
                return aggiungi ??
                    (aggiungi = new DelegateCommand<PersonaViewModel>(Add));
            }
        }
        //public ICommand Aggiungi { get; set; }
        void Add(object obj)
        {
            PersonaViewModel p;
            if (obj == null)
            {
                p = new PersonaViewModel() { Nome = "Name", Cognome = "Surname", Telefono = "Phone Number" };
                Persone.Add(p);
                PersonaSelezionata = (PersonaViewModel)obj;
            }
            else
            {
                this.Persone.Add((PersonaViewModel)obj);
                PersonaSelezionata = (PersonaViewModel)obj;
            }
        }
        //-------ICOMMAND SOSTITUITO-------//


        public ICommand Apri { get; set; }
        private void Open(object obj)
        {
            PossoEseguire = false;
            OpenFileDialog of = new OpenFileDialog();
            PersonaViewModel nuovaPersona = new PersonaViewModel();
            if ((bool)of.ShowDialog())
            {
                foreach (string s in File.ReadAllLines(of.FileName))
                {
                    nuovaPersona.Deserializza(s);
                }
                Task.Delay(1000).Wait();

                this.Aggiungi.Execute(nuovaPersona);
            }
            PossoEseguire = true;
        }

        private void Save()
        {
            using (StreamWriter file = new StreamWriter("C:\\Users\\utente\\Desktop\\Contacts.xml",false))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<PersonaViewModel>));
                serializer.Serialize(file, Persone);
                file.Close();
            }
        }
    }
}
