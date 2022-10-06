using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MenschKlasse
{
    public partial class Form1 : Form
    {
        List<Mensch> Liste { get; set; }
        //List<TextBox> textBoxes { get; set; }

        public Form1()
        {
            InitializeComponent();

            ListeLaden();

            //Schleifen Üben
            // Anfang----
            for (int i = 0; i < Liste.Count; i++)
            {
                Mensch mensch = Liste[i];
                Console.WriteLine(mensch.Vorname);
            }


            int n = 0;
            while (n < Liste.Count)
            {
                Mensch mensch = Liste[n];
                Console.WriteLine(mensch.Vorname);
                n++;
            }

            foreach (Mensch mensch1 in Liste)
            {
                Console.WriteLine(mensch1.Vorname);
            }
            //Ende----

            foreach (Mensch mensch2 in Liste)
            {
                if (!mensch2.HatteUnfall)
                {
                    Console.WriteLine(mensch2.Vorname);
                }
            }


            btnSpeichern.Visible = false;
            btnAbbrechen.Visible = false;

            NurZumLesen();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //Patient suchen
            DatenLeren();

            string sucheingabe = txtSucheingabe.Text;
            bool menschGefunden = false;

            foreach (Mensch mensch in Liste)
            {
                if (mensch.Nachname == sucheingabe)
                {
                    DatenFüllen(mensch);
                    NurZumLesen();
                    menschGefunden = true;

                    break;
                }
                else
                {
                    if (mensch.Vorname == sucheingabe)
                    {
                        DatenFüllen(mensch);
                        NurZumLesen();
                        menschGefunden = true;

                        break;
                    }

                }

            }

            if (menschGefunden == false)
            {
                MessageBox.Show("Patient nicht gefunden!");
            }

        }

        public void ListeLaden()
        {
            Liste = new List<Mensch>();

            // Datenbank verknüpfung
            string connectionString = "Data Source=NBSB-0018\\SQLEXPRESS;Initial Catalog=PatientenDB;User ID=sa;Password=manusDB;";
            SqlConnection con = new SqlConnection(connectionString);

            con.Open();

            SqlCommand sqlCommand = new SqlCommand("select * from Mensch", con);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);

            //sqlCommand.ExecuteNonQuery(); --> für update, insert & delete

            DataTable menschen = new DataTable();
            adapter.Fill(menschen);

            con.Close();

            foreach (DataRow row in menschen.Rows)
            {
                Mensch mensch = new Mensch(row);
                Liste.Add(mensch);
            }


            //Mensch peter = new Mensch("Peter", "Hard", 43, 90, 1.80, "Saarbrücken", 1, 2, "Autounfall");
            //Mensch gustav = new Mensch("Gustav", "Schmit", 80, 85, 1.70, "Hannover", 2, 2, "Gefallen von Leiter");
            //Mensch holger = new Mensch("Holger", "Büchner", 75, 114, 1.70, "München", 2, 2, "Ausgerutscht");
            //Mensch medin = new Mensch("Medin", "Krupic", 20, 70, 1.87, "Saarbrücken", 2, 2, "kein");
            //Mensch florian = new Mensch("Florian", "Fischer", 27, 83, 1.77, "Dortmund", 2, 2, "Beinbruch Fußball");
            //Mensch steven = new Mensch("Steven", "Gauß", 32, 85, 1.83, "Völklingen", 2, 2, "Kein");


            //Liste.Add(peter);
            //Liste.Add(gustav);
            //Liste.Add(holger);
            //Liste.Add(medin);
            //Liste.Add(florian);
            //Liste.Add(steven);

            ListBoxMenschen.Items.Clear();

            foreach (Mensch mensch in Liste)
            {
                ListBoxMenschen.Items.Add(mensch);
            }
        }

        public void DatenFüllen(Mensch mensch)
        {
            txtNachname.Text = mensch.Nachname;
            txtVorname.Text = mensch.Vorname;
            txtAlter.Text = mensch.Alter.ToString();
            txtGewicht.Text = mensch.GewichtInKG.ToString();
            txtGroesse.Text = mensch.GroesseInM.ToString();
            txtWohnort.Text = mensch.Wohnort;
            txtAnzahlBeine.Text = mensch.AnzahlBeine.ToString();
            txtAnzahlArme.Text = mensch.AnzahlArme.ToString();
            txtUnfallHergang.Text = mensch.UnfallHergang;
        }

        public void DatenLeren()
        {
            txtNachname.Text = "";
            txtVorname.Text = "";
            txtAlter.Text = "";
            txtGewicht.Text = "";
            txtGroesse.Text = "";
            txtWohnort.Text = "";
            txtAnzahlBeine.Text = "";
            txtAnzahlArme.Text = "";
            txtUnfallHergang.Text = "";
        }

        public void NurZumLesen()
        {
            txtNachname.ReadOnly = true;
            txtVorname.ReadOnly = true;
            txtAlter.ReadOnly = true;
            txtGewicht.ReadOnly = true;
            txtGroesse.ReadOnly = true;
            txtWohnort.ReadOnly = true;
            txtAnzahlBeine.ReadOnly = true;
            txtAnzahlArme.ReadOnly = true;
            txtUnfallHergang.ReadOnly = true;
        }

        public void NurZumBearbeiten()
        {
            txtNachname.ReadOnly = false;
            txtVorname.ReadOnly = false;
            txtAlter.ReadOnly = false;
            txtGewicht.ReadOnly = false;
            txtGroesse.ReadOnly = false;
            txtWohnort.ReadOnly = false;
            txtAnzahlBeine.ReadOnly = false;
            txtAnzahlArme.ReadOnly = false;
            txtUnfallHergang.ReadOnly = false;
        }

        private void TxtSucheingabe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.button1.PerformClick();
            }
        }

        //private void TxtPatientenListe_Click(object sender, EventArgs e)
        //{
        //    foreach (Mensch mensch in Liste)
        //    {
        //        txtSucheingabe.Text = Liste[0].Vorname;
        //    }
        //}

        int y = 220;
        int p = 1;
        
        private void Button2_Click(object sender, EventArgs e)
        {
            //Label label = new Label();
            //label.Location = new Point(1000, y);
            //y += 48;
            //Controls.Add(label);
            //label.Name = "newLabel" + p;
            //p++;
            //label.Font = new Font("Microsoft Sans Serif", 10.0f);
            //label.Size = new Size(100, 27);
            //label.Text = "Erweiterung" + p;
            //label.BringToFront();

            //p = 1;
            TextBox textbox = new TextBox();
            textbox.Location = new Point(1050, y);
            y += 48;
            Controls.Add(textbox);
            textbox.Name = "newTextBox" + p;
            p++;
            textbox.Font = new Font("Microsoft Sans Serif", 13.0f);
            textbox.Size = new Size(160, 27);
            textbox.BringToFront();

            if (textbox.Name == "newTextBox8")
            {
                textbox.Size = new Size(250, 122);
                textbox.Multiline = true;
                button2.Enabled = false;
            }

        }

        private void BtnHinzufügen_Click(object sender, EventArgs e)
        {
            DatenLeren();
            btnSpeichern.Visible = true;
            btnAbbrechen.Visible = true;
            NurZumBearbeiten();
            txtSucheingabe.ReadOnly = true;
        }

        private void BtnAbbrechen_Click(object sender, EventArgs e)
        {
            btnSpeichern.Visible = false;
            btnAbbrechen.Visible = false;
            DatenLeren();
            NurZumLesen();
            txtSucheingabe.ReadOnly = false;
        }

        private void BtnSpeichern_Click(object sender, EventArgs e)
        {

            //List<TextBox> alleTextBoxen = groupBox1.Controls.OfType<TextBox>().ToList();
            //bool istEineTextboxLeer = alleTextBoxen.Any(textbox => textbox.Text == "");
            //if (istEineTextboxLeer == true)

            if (txtVorname.Text == "" || txtNachname.Text == "" || txtAlter.Text == "" || txtGewicht.Text == "" || txtGroesse.Text == "" || txtWohnort.Text == "" || txtAnzahlBeine.Text == "" || txtAnzahlArme.Text == "" || txtUnfallHergang.Text == "")
            {
                MessageBox.Show("Bitte fülle alle datensätze!");
                return;
            }

            Mensch neuerMensch = new Mensch();
            neuerMensch.Vorname = txtVorname.Text;
            neuerMensch.Nachname = txtNachname.Text;
            neuerMensch.Alter = int.Parse(txtAlter.Text);
            neuerMensch.GewichtInKG = int.Parse(txtGewicht.Text);

            if (txtGroesse.Text.Contains("."))
            {
                txtGroesse.Text = txtGroesse.Text.Replace(".", ",");
            }

            neuerMensch.GroesseInM = Convert.ToDouble(txtGroesse.Text);
            neuerMensch.Wohnort = txtWohnort.Text;
            neuerMensch.AnzahlBeine = int.Parse(txtAnzahlBeine.Text);
            neuerMensch.AnzahlArme = int.Parse(txtAnzahlArme.Text);
            neuerMensch.UnfallHergang = txtUnfallHergang.Text;



            //In die Datenbank hinzufügen
            string connectionString = "Data Source=NBSB-0018\\SQLEXPRESS;Initial Catalog=PatientenDB;User ID=sa;Password=manusDB;";
            SqlConnection con = new SqlConnection(connectionString);

            con.Open();

            string insert = "insert into Mensch (Vorname, Nachname, [Alter], GewichtInKG, GroesseInM, Wohnort, AnzahlBeine, AnzahlArme, UnfallHergang) values ('"+neuerMensch.Vorname+"', '"+neuerMensch.Nachname+"', "+neuerMensch.Alter.ToString()+", "+neuerMensch.GewichtInKG.ToString()+", "+neuerMensch.GroesseInM.ToString().Replace("," , ".") +", '"+neuerMensch.Wohnort+"', "+neuerMensch.AnzahlBeine.ToString()+", "+neuerMensch.AnzahlArme.ToString()+", '"+neuerMensch.UnfallHergang+"')";
            SqlCommand sqlCommandInsert = new SqlCommand(insert, con);
            sqlCommandInsert.ExecuteNonQuery();

            con.Close();


            Liste.Add(neuerMensch);
            ListBoxMenschen.Items.Add(neuerMensch);

            btnSpeichern.Visible = false;
            btnAbbrechen.Visible = false;
            DatenLeren();
            NurZumLesen();
            txtSucheingabe.ReadOnly = false;
        }


        private void ListBoxMenschen_SelectedIndexChanged(object sender, EventArgs e)
        {
            object selektiertesItem = ListBoxMenschen.SelectedItem;

            if (selektiertesItem is Mensch)
            {
                Mensch selektierterMensch = selektiertesItem as Mensch;

                //selektierterMensch.Nachname = "BlaBla";
                txtSucheingabe.Text = selektierterMensch.Vorname;
            }

        }

        private void BtnLoeschen_Click(object sender, EventArgs e)
        {
            object selektiertesItem = ListBoxMenschen.SelectedItem;

            if (selektiertesItem is Mensch)
            {
                Mensch selektierterMensch = selektiertesItem as Mensch;

                string connectionString = "Data Source=NBSB-0018\\SQLEXPRESS;Initial Catalog=PatientenDB;User ID=sa;Password=manusDB;";
                SqlConnection con = new SqlConnection(connectionString);

                con.Open();

                string delete = "delete from Mensch where Vorname = '"+selektierterMensch.Vorname+"' and Nachname = '"+selektierterMensch.Nachname+"' ";
                SqlCommand command = new SqlCommand(delete, con);
                command.ExecuteNonQuery();
                
                con.Close();

                ListeLaden();
                DatenLeren();
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {

            //textbox.Clear();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }

}
