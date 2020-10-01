﻿using System.Collections.ObjectModel;

namespace TestAutomat.AutoTester
{
    public class ConfigDa
    {
        public ObservableCollection<DaEinstellungen> DigitaleAusgaenge { get; set; } = new ObservableCollection<DaEinstellungen>();
    }

    public class DaEinstellungen
    {
        public DaEinstellungen()
        {
            LaufendeNr = 0;
            StartByte = 0;
            StartBit = 0;
            AnzahlBit = 0;
            Type = "";
            Bezeichnung = "";
            Kommentar = "";
        }

        public int LaufendeNr { get; set; }
        public int StartByte { get; set; }
        public int StartBit { get; set; }
        public int AnzahlBit { get; set; }
        public string Type { get; set; }
        public string Bezeichnung { get; set; }
        public string Kommentar { get; set; }
    }
}