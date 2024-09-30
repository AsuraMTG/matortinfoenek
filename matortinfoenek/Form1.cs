using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace matortinfoenek
{
    public partial class Form1 : Form
    {




        public string[] vezetekNev = { "Tóth", "Szabó", "Lakatos", "Hegedűs", "Fehér", "Tarhonyási"};
        public string[] keresztNev = { "Viktor", "Sándor", "Dávid", "Endre", "Gyula", "Bence"};
        
        public Random rnd = new Random();

        public struct tanulo
        {
            public string vezetekNevList;
            public string keresztNevList;
            public int[] matek;
            public int[] tortenelem;
            public int[] informatika;
            public int[] enek;
        }



        public struct teljesNevekList
        {
            public string vezetekNevList;
            public string keresztNevList;
        }

        public teljesNevekList teljesNevekListFeltoltese = new teljesNevekList();
        public List<teljesNevekList> teljesNevek = new List<teljesNevekList>();

        public tanulo tanuloFeltoltese = new tanulo();
        public List<tanulo> tanulok = new List<tanulo>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < vezetekNev.Length; i++)
            {
                for (int j = 0; j < keresztNev.Length; j++)
                {
                    teljesNevekListFeltoltese.vezetekNevList = vezetekNev[i];
                    teljesNevekListFeltoltese.keresztNevList = keresztNev[j];
                    teljesNevek.Add(teljesNevekListFeltoltese);
                }
            }
            for (int i = 0; i < 150; i++)
            {

                int a = rnd.Next(0, 36);
                int b = rnd.Next(0, 36);

                teljesNevekList s = teljesNevek[a];
                teljesNevek[a] = teljesNevek[b];
                teljesNevek[b] = s;
            }

            int[] osztalyzatok = new int[5];

            int[] matekOsztalyzatok = new int[5];
            int[] tortenelemOsztalyzatok = new int[5];
            int[] informatikaOsztalyzatok = new int[5];
            int[] enekOsztalyzatok = new int[5];
            for (int i = 0; i < 36; i++)
            {
                tanuloFeltoltese.vezetekNevList = teljesNevek[i].vezetekNevList;
                tanuloFeltoltese.keresztNevList = teljesNevek[i].keresztNevList;
                
                for (int j = 0; j < osztalyzatok.Length; j++)
                {
                    matekOsztalyzatok[j] = rnd.Next(1, 6);
                    tortenelemOsztalyzatok[j] = rnd.Next(1, 6);
                    informatikaOsztalyzatok[j] = rnd.Next(1, 6);
                    enekOsztalyzatok[j] = rnd.Next(1, 6);
                }
                tanuloFeltoltese.matek = matekOsztalyzatok;
                tanuloFeltoltese.tortenelem = tortenelemOsztalyzatok;
                tanuloFeltoltese.informatika = informatikaOsztalyzatok;
                tanuloFeltoltese.enek = enekOsztalyzatok;
                tanulok.Add(tanuloFeltoltese);
            }

            for (int i = 0; i < 20; i++)
            {
                label1.Text += $"{i + 1}. {tanulok[i].vezetekNevList} {tanulok[i].keresztNevList}";
                label1.Text +=
                    $"\n\t Matek: {tanulok[i].matek[0]},{tanulok[i].matek[1]},{tanulok[i].matek[2]},{tanulok[i].matek[3]},{tanulok[i].matek[4]}" +
                    $"\n\t Törtenelem:  {tanulok[i].tortenelem[0]},{tanulok[i].tortenelem[1]},{tanulok[i].tortenelem[2]},{tanulok[i].tortenelem[3]},{tanulok[i].tortenelem[4]}" +
                    $"\n\t Informatika:  {tanulok[i].informatika[0]},{tanulok[i].informatika[1]},{tanulok[i].informatika[2]},{tanulok[i].informatika[3]},{tanulok[i].informatika[4]}" +
                    $"\n\t Ének:  {tanulok[i].enek[0]},{tanulok[i].enek[1]},{tanulok[i].enek[2]},{tanulok[i].enek[3]},{tanulok[i].enek[4]}\n";
            }
            // ki bukott meg?
            int matek = 0;
            int tori = 0;
            int info = 0;
            int enek = 0;

            for (int i = 0; i < tanulok.Count; i++)
            {
                for (int j = 0; j < osztalyzatok.Length; j++)
                {
                    matek += tanulok[i].matek[j];
                    tori += tanulok[i].tortenelem[j];
                    info += tanulok[i].informatika[j];
                    enek += tanulok[i].enek[j];
                }
                matek = matek / osztalyzatok.Length;
                tori = tori / osztalyzatok.Length;
                info = info / osztalyzatok.Length;
                enek = enek / osztalyzatok.Length;

                if (matek < 2 || tori < 2 || info < 2 || enek < 2)
                {
                    label2.Text += $" {tanulok[i].vezetekNevList} {tanulok[i].keresztNevList}";
                }
            }
        }
    }
}
