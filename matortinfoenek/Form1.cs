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
        public int actual = 0;

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

        public int[] osztalyzatok = new int[5];
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


            int[] matekOsztalyzatok = new int[5];
            int[] tortenelemOsztalyzatok = new int[5];
            int[] informatikaOsztalyzatok = new int[5];
            int[] enekOsztalyzatok = new int[5];

            for (int i = 0; i < 36; i++)
            {
                tanuloFeltoltese.vezetekNevList = teljesNevek[i].vezetekNevList;
                tanuloFeltoltese.keresztNevList = teljesNevek[i].keresztNevList;
                matekOsztalyzatok = new int[5];
                tortenelemOsztalyzatok = new int[5];
                informatikaOsztalyzatok = new int[5];
                enekOsztalyzatok = new int[5];
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
            /*
            for (int i = 0; i < 20; i++)
            {
                label1.Text += $"{i + 1}. {tanulok[i].vezetekNevList} {tanulok[i].keresztNevList}";
                label1.Text +=
                    $"\n\t Matek: {tanulok[i].matek[0]},{tanulok[i].matek[1]},{tanulok[i].matek[2]},{tanulok[i].matek[3]},{tanulok[i].matek[4]}" +
                    $"\n\t Törtenelem:  {tanulok[i].tortenelem[0]},{tanulok[i].tortenelem[1]},{tanulok[i].tortenelem[2]},{tanulok[i].tortenelem[3]},{tanulok[i].tortenelem[4]}" +
                    $"\n\t Informatika:  {tanulok[i].informatika[0]},{tanulok[i].informatika[1]},{tanulok[i].informatika[2]},{tanulok[i].informatika[3]},{tanulok[i].informatika[4]}" +
                    $"\n\t Ének:  {tanulok[i].enek[0]},{tanulok[i].enek[1]},{tanulok[i].enek[2]},{tanulok[i].enek[3]},{tanulok[i].enek[4]}\n";
            }
            */
            // ki bukott meg?
            double matek = 0;
            double tori = 0;
            double info = 0;
            double enek = 0;

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < osztalyzatok.Length; j++)
                {
                    matek += tanulok[i].matek[j];
                    tori += tanulok[i].tortenelem[j];
                    info += tanulok[i].informatika[j];
                    enek += tanulok[i].enek[j];
                }

                if ((matek % osztalyzatok.Length) < 2)
                {
                    label2.Text += $" {tanulok[i].vezetekNevList} {tanulok[i].keresztNevList}\n";
                }
                else if ((tori % osztalyzatok.Length) < 2)
                {
                    label2.Text += $" {tanulok[i].vezetekNevList} {tanulok[i].keresztNevList}\n";
                }
                else if ((info % osztalyzatok.Length) < 2)
                {
                    label2.Text += $" {tanulok[i].vezetekNevList} {tanulok[i].keresztNevList}\n";
                }
                else if ((enek % osztalyzatok.Length) < 2)
                {
                    label2.Text += $" {tanulok[i].vezetekNevList} {tanulok[i].keresztNevList}\n";
                }
            }

            label1.Text = $"{actual + 1}. {tanulok[actual].vezetekNevList} {tanulok[actual].keresztNevList}";
            label1.Text +=
                $"\n\t Matek: {tanulok[actual].matek[0]},{tanulok[actual].matek[1]},{tanulok[actual].matek[2]},{tanulok[actual].matek[3]},{tanulok[actual].matek[4]}" +
                $"\n\t Törtenelem:  {tanulok[actual].tortenelem[0]},{tanulok[actual].tortenelem[1]},{tanulok[actual].tortenelem[2]},{tanulok[actual].tortenelem[3]},{tanulok[actual].tortenelem[4]}" +
                $"\n\t Informatika:  {tanulok[actual].informatika[0]},{tanulok[actual].informatika[1]},{tanulok[actual].informatika[2]},{tanulok[actual].informatika[3]},{tanulok[actual].informatika[4]}" +
                $"\n\t Ének:  {tanulok[actual].enek[0]},{tanulok[actual].enek[1]},{tanulok[actual].enek[2]},{tanulok[actual].enek[3]},{tanulok[actual].enek[4]}\n";

        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            actual--;
            if (actual < 20 && actual != -1)
            {
                
                label1.Text = $"{actual + 1}. {tanulok[actual].vezetekNevList} {tanulok[actual].keresztNevList}";
                label1.Text +=
                    $"\n\t Matek: {tanulok[actual].matek[0]},{tanulok[actual].matek[1]},{tanulok[actual].matek[2]},{tanulok[actual].matek[3]},{tanulok[actual].matek[4]}" +
                    $"\n\t Törtenelem:  {tanulok[actual].tortenelem[0]},{tanulok[actual].tortenelem[1]},{tanulok[actual].tortenelem[2]},{tanulok[actual].tortenelem[3]},{tanulok[actual].tortenelem[4]}" +
                    $"\n\t Informatika:  {tanulok[actual].informatika[0]},{tanulok[actual].informatika[1]},{tanulok[actual].informatika[2]},{tanulok[actual].informatika[3]},{tanulok[actual].informatika[4]}" +
                    $"\n\t Ének:  {tanulok[actual].enek[0]},{tanulok[actual].enek[1]},{tanulok[actual].enek[2]},{tanulok[actual].enek[3]},{tanulok[actual].enek[4]}\n";

            }
            else
            {
                actual = 0;
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            actual++;
            if (actual <= 19 && actual != -1)
            {
                
                label1.Text = $"{actual + 1}. {tanulok[actual].vezetekNevList} {tanulok[actual].keresztNevList}";
                label1.Text +=
                    $"\n\t Matek: {tanulok[actual].matek[0]},{tanulok[actual].matek[1]},{tanulok[actual].matek[2]},{tanulok[actual].matek[3]},{tanulok[actual].matek[4]}" +
                    $"\n\t Törtenelem:  {tanulok[actual].tortenelem[0]},{tanulok[actual].tortenelem[1]},{tanulok[actual].tortenelem[2]},{tanulok[actual].tortenelem[3]},{tanulok[actual].tortenelem[4]}" +
                    $"\n\t Informatika:  {tanulok[actual].informatika[0]},{tanulok[actual].informatika[1]},{tanulok[actual].informatika[2]},{tanulok[actual].informatika[3]},{tanulok[actual].informatika[4]}" +
                    $"\n\t Ének:  {tanulok[actual].enek[0]},{tanulok[actual].enek[1]},{tanulok[actual].enek[2]},{tanulok[actual].enek[3]},{tanulok[actual].enek[4]}\n";

            }
            else if (actual == 0)
            {
                actual = 0;
                label1.Text += $"{actual + 1}. {tanulok[actual].vezetekNevList} {tanulok[actual].keresztNevList}";
                label1.Text =
                    $"\n\t Matek: {tanulok[actual].matek[0]},{tanulok[actual].matek[1]},{tanulok[actual].matek[2]},{tanulok[actual].matek[3]},{tanulok[actual].matek[4]}" +
                    $"\n\t Törtenelem:  {tanulok[actual].tortenelem[0]},{tanulok[actual].tortenelem[1]},{tanulok[actual].tortenelem[2]},{tanulok[actual].tortenelem[3]},{tanulok[actual].tortenelem[4]}" +
                    $"\n\t Informatika:  {tanulok[actual].informatika[0]},{tanulok[actual].informatika[1]},{tanulok[actual].informatika[2]},{tanulok[actual].informatika[3]},{tanulok[actual].informatika[4]}" +
                    $"\n\t Ének:  {tanulok[actual].enek[0]},{tanulok[actual].enek[1]},{tanulok[actual].enek[2]},{tanulok[actual].enek[3]},{tanulok[actual].enek[4]}\n";


            }
            else
            {
                actual = 19;
            }
        }
    }
}
