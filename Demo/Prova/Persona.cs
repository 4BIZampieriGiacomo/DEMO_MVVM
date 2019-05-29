using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Prova
{
    class Persona
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Telefono { get; set; }

        public string Serializza()
        {
            string serializza = $"Nome: {Nome}\r\n" +
                                $"Cognome: {Cognome}\r\n" +
                                $"Telefono: {Telefono}";
            return serializza;
        }
        public void Salva()
        {
            
        }
    }
}
