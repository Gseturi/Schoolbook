using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
namespace davaleba123
{
    public partial class StudentsBook : Form
    {

        XmlDocument mailbox;
        List<int>x;
        List<string> teachername = new List<string>();
        public StudentsBook()
        {
            mailbox = new XmlDocument();
            mailbox.Load("C://Users//User//source//repos//davaleba123//davaleba123//tempstudent.xml");
            x = new List<int>();
            InitializeComponent();
        }

        private void StudentsBook_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (XmlNode x in mailbox.SelectSingleNode("Messeges").ChildNodes)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

           
            Program.Decider = 0;
             mailbox.Load("C://Users//User//source//repos//davaleba123//davaleba123//tempstudent.xml");
            foreach (XmlNode x in mailbox.SelectSingleNode("Messeges").ChildNodes)
            {
                if (x.SelectSingleNode("Text")!=null) {
                    if (x.Name == "Grade")
                    {
                        int num;
                        if (int.TryParse(x.SelectSingleNode("Text").InnerText, out int _))
                        {

                            num = int.Parse(x.SelectSingleNode("Text").InnerText);
                            this.x.Add(num);

                        } else if (x.SelectSingleNode("Text") == null || x.SelectSingleNode("Text").InnerText == null) {

                        }

                        x.RemoveAll();
                        mailbox.Save("C://Users//User//source//repos//davaleba123//davaleba123//tempstudent.xml");

                    }
                }
            }
           
            mailbox.Save("C://Users//User//source//repos//davaleba123//davaleba123//tempstudent.xml");
            mailbox.Load("C://Users//User//source//repos//davaleba123//davaleba123//tempstudent.xml");

            if (mailbox.SelectNodes("Messeges/nishani").Count!=0) {
                int temp = 0;
                for (int i = 0; i < this.x.Count; i++)
                {
                    temp = temp + x[i];
                }
                XmlNode nishani = mailbox.CreateElement("nishani");
                nishani.InnerText = ((double)temp / this.x.Count).ToString() + " " + this.x.Count;
                mailbox.SelectSingleNode("Messeges").AppendChild(nishani);

                double temp_ = 0;
                mailbox.Save("C://Users//User//source//repos//davaleba123//davaleba123//tempstudent.xml");
                mailbox.Load("C://Users//User//source//repos//davaleba123//davaleba123//tempstudent.xml");


                foreach (XmlNode b in mailbox.SelectSingleNode("Messeges").ChildNodes)
                {
                    if (b.Name== "nishani") {
                        string[] subs = b.InnerText.Split(' ');
                        temp_ = temp_ + (int.Parse(subs[0]) * int.Parse(subs[1]));
                        temp = temp + int.Parse(subs[1]);
                        textBox1.Text = b.InnerText;

                        //b.RemoveAll();
                    }
                }
                XmlNode nishani_ = mailbox.CreateElement("nishani");
                nishani_.InnerText = ((double)temp_ / temp).ToString() + " " + temp;
                mailbox.SelectSingleNode("Messeges").AppendChild(nishani_);
                textBox1.Text = (((double)temp_ / this.x.Count)).ToString();
            }
            Program.Decider = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Program.Decider = 0;
            foreach (XmlNode x in mailbox.SelectSingleNode("Messeges").ChildNodes)
            {
                if (x.Name== "HomeWork")
                {
                    
                              teachername.Add(x.SelectSingleNode("Teacher").InnerText);
                    teachername.Add(x.SelectSingleNode("Text").InnerText);
                    teachername.Add(x.SelectSingleNode("Header").InnerText);
                    comboBox1.Items.Add(x.SelectSingleNode("Teacher").InnerText);

                }
            }
            Program.Decider = 0;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            for(int i = 0; i < teachername.Count; i++)
            {
                if (teachername[i]== comboBox1.SelectedItem.ToString())
                {
                    textBox2.Text = teachername[i + 2];
                    richTextBox1.Text = teachername[i + 1];
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
