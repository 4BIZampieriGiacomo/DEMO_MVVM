﻿using Microsoft.Win32;
using System.IO;
using System.Windows.Input;
using DevExpress.Mvvm;

namespace Prova
{
    class PersonaViewModel : ViewModelBase
    {
        public PersonaViewModel()
        {
            this.TestCommand = new RelayCommand(Test);
            _persona = new Persona();
        }

        private Persona _persona;

        public string Nome
        {
            get { return GetProperty(() => Nome); }
            set { SetProperty(() => Nome, value, UpdateNome); }
        }
        void UpdateNome()
        {
            RaisePropertyChanged(() => Nome);
        }
        
        public string Cognome
        {
            get { return GetProperty(() => Cognome); }
            set { SetProperty(() => Cognome, value, UpdateCognome); }
        }
        void UpdateCognome()
        {
            RaisePropertyChanged(() => Cognome);
        }

        public string Telefono
        {
            get { return GetProperty(() => Telefono); }
            set { SetProperty(() => Telefono, value, UpdateTelefono); }
        }
        void UpdateTelefono()
        {
            RaisePropertyChanged(() => Telefono);
        }

        public ICommand TestCommand { get; set; }
        private void Test(object obj)
        {
            SaveFileDialog sf = new SaveFileDialog
            {
                Filter = "Text files (*.txt)|*.txt",
                Title = "Salva persona"
            };
            if ((bool)sf.ShowDialog())
            {
                StreamWriter sw = new StreamWriter(sf.OpenFile());
                sw.Write(_persona.Serializza());

                sw.Close();
            }
        }

        #region deserialize group of methods
        private string GetName(string file)
        {
            string nome = file.Substring(file.IndexOf(':') + 2);
            return nome;
        }

        private string GetCognome(string file)
        {
            string cognome = file.Substring(file.IndexOf(':') + 2);
            return cognome;
        }

        private string GetTelefono(string file)
        {
            string telefono = file.Substring(file.IndexOf(':') + 2);
            return telefono;
        }
        #endregion
        public void Deserializza(StreamReader file)
        {
            Nome = GetName(file.ReadLine());
            Cognome = GetCognome(file.ReadLine());
            Telefono = GetTelefono(file.ReadLine());
        }
    }
}