using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using System.Xml.Serialization;
using System.Collections.ObjectModel;

namespace MVVMStage
{
    [Serializable]

    public class PersonaViewModel : ViewModelBase
    {
        public PersonaViewModel()
        {
            _Persona = new Persona();
        }

        [XmlIgnore]
        public Persona _Persona { get; set; }

        public string Nome
        {
            get { return _Persona.Nome; }
            set { _Persona.Nome = value; RaisePropertyChanged(); }
        }

        public string Cognome
        {
            get { return _Persona.Cognome; }
            set { _Persona.Cognome = value; RaisePropertyChanged(); }
        }

        public string Telefono
        {
            get { return _Persona.Telefono; }
            set { _Persona.Telefono = value; RaisePropertyChanged(); }
        }

        


        //public void CaricaXML(Garage g1)
        //{
        //    if (File.Exists("garage.xml"))
        //    {
        //        Garage g = new Garage();
        //        StreamReader file = new StreamReader("garage.xml");
        //        XmlSerializer serializer = new XmlSerializer(typeof(Garage));
        //        g = (Garage)serializer.Deserialize(file);
        //        TariffaAuto = g.TariffaAuto;
        //        TariffaFurgoni = g.TariffaFurgoni;
        //        TariffaMoto = g.TariffaMoto;
        //        arrVeicoli = g.arrVeicoli;
        //        nVeicoli = g.nVeicoli;
        //        g1 = g;
        //        file.Close();
        //    }
        //}



        public void Deserializza(string s)
        {
            if (s.Contains("Nome"))
            {
                Nome = s.Substring(s.IndexOf(": ") + 2);
                //Nome = Regex.Split(s, ": ")[1];
            }

            if (s.Contains("Cognome"))
            {
                Cognome = s.Substring(s.IndexOf(": ") + 2);
                //Cognome = Regex.Split(s, ": ")[1];
            }

            if (s.Contains("Telefono"))
            {
                Telefono = s.Substring(s.IndexOf(": ") + 2);
                //Telefono = Regex.Split(s, ": ")[1];
            }
        }
    }
}
