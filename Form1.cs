using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vizsgagyakorlas
{
    public partial class Form1 : Form
    {
        List<Sorsolas> sorsolasok = new List<Sorsolas>();
        List<Szam> szamok = new List<Szam>();
        public Form1()
        {
            InitializeComponent();
            List<Sorsolas> szamok_lista = new List<Sorsolas>();
            string[] lines = File.ReadAllLines("sorsolas.txt");
            foreach (var item in lines)
            {
                string[] values = item.Split(';');
                Sorsolas sorsolas_object = new Sorsolas(values[0], values[1], values[2], values[3], values[4], values[5]);
                sorsolasok.Add(sorsolas_object);
            }
            // Legkevesebbszer kihúzva
            int db = 0;
            for (int i = 1; i < 91; i++)
            {
                foreach (var item in sorsolasok)
                {
                    if (i == item.szam1 || i == item.szam2 || i == item.szam3 || i == item.szam4 || i == item.szam5)
                        db++;
                }
                Szam szam_object = new Szam(i, db);
                szamok.Add(szam_object);
                db = 0;
            }

            int max_db = int.MinValue;
            int max_szam = 0;

            // Páros számok

            int paros = 0;
            foreach (var item in sorsolasok)
            {
                if (item.szam1 % 2 == 0) paros++;
                if (item.szam2 % 2 == 0) paros++;
                if (item.szam3 % 2 == 0) paros++;
                if (item.szam4 % 2 == 0) paros++;
                if (item.szam5 % 2 == 0) paros++;

            }
            label3.Text = "4. Feladat Páros számok: " + paros.ToString() + " db.";


            foreach (var item in szamok)
            {
                if (item.db > max_db)
                {
                    max_db = item.db;
                    max_szam = item.szam;
                }




                // 4-ösök száma
                if (item.szam == 4)
                    label4.Text = $"5. feladat 4-es: {item.db} db";
                // 73
                if (item.szam == 73)
                    label5.Text = $"6.feladat 73-as: {item.db} db";

                label2.Text = $"Feladat3 Legtöbbször kihúzva: {max_szam}: {max_db}";
            }

            //az összes szám

            foreach (var item in szamok)
                dataGridView1.Rows.Add(item.szam, item.db);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var item in sorsolasok)
                if (numericUpDown1.Value == item.hat)
                    label1.Text = $"Feladat2: {item.hat}. hét: {item.szam1},{item.szam2},{item.szam3},{item.szam4},{item.szam5}";
        }
    }
}

