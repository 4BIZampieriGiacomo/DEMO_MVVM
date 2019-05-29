# DEMO_MVVM




public void SalvaXML(Garage g)
        {
            StreamWriter file = new StreamWriter("garage.xml");
            XmlSerializer serializer = new XmlSerializer(typeof(Garage));
            serializer.Serialize(file, g);
            file.Close();
        }

        public void CaricaXML(Garage g1)
        {
            if (File.Exists("garage.xml"))
            {
                Garage g = new Garage();
                StreamReader file = new StreamReader("garage.xml");
                XmlSerializer serializer = new XmlSerializer(typeof(Garage));
                g = (Garage)serializer.Deserialize(file);
                TariffaAuto = g.TariffaAuto;
                TariffaFurgoni = g.TariffaFurgoni;
                TariffaMoto = g.TariffaMoto;
                arrVeicoli = g.arrVeicoli;
                nVeicoli = g.nVeicoli;
                g1 = g;
                file.Close();
            }
        }
