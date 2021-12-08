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
    public partial class Teachers_School_book : Form
    {
        XmlDocument Uinfo;
        XmlDocument School;
        XmlDocument Sender_;
        List<User> StudentList;
        public Teachers_School_book()
        {
            Uinfo = new XmlDocument();
            School = new XmlDocument();
            Sender_ = new XmlDocument();
            InitializeComponent();
 
            StudentList = new List<User>();
            
            Uinfo.Load("C://Users//User//source//repos//davaleba123//davaleba123//YourInfo.xml");
            School.Load("C://Users//User//source//repos//davaleba123//davaleba123//School.xml");
            Sender_.Load("C://Users//User//source//repos//davaleba123//davaleba123//hub.xml");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Program.Decider = 0;
            checkedListBox1.Items.Clear();
            Sender_.Load("C://Users//User//source//repos//davaleba123//davaleba123//hub.xml");
            foreach (XmlNode x in School.SelectNodes("School/Students/Student"))
            {
                if (x.SelectSingleNode("Class")!=null && Uinfo.SelectSingleNode("UInfo/Class/STudent")!=null) {
                    if (x.SelectSingleNode("Class").InnerText == Uinfo.SelectSingleNode("UInfo/Class/STudent").InnerText) {

                        StudentList.Add(new User(x.SelectSingleNode("Name").InnerText + " " + x.SelectSingleNode("Lastname").InnerText, x.SelectSingleNode("Id").InnerText, "  "));
                        checkedListBox1.Items.Add(x.SelectSingleNode("Name").InnerText + " " + x.SelectSingleNode("Lastname").InnerText);


                    } else if (x.SelectSingleNode("Class") == null || Uinfo.SelectSingleNode("UInfo/Class/STudent") == null || x.SelectSingleNode("Class").InnerText == null || Uinfo.SelectSingleNode("UInfo/Class/STudent").InnerText == null)
                    {

                    }
                }
            }
            Program.Decider = 1;
        }
       string GetAddressByid(int id)
        {
            Sender_.Load("C://Users//User//source//repos//davaleba123//davaleba123//hub.xml");
            XmlDocument b = new XmlDocument();
            b.Load("C://Users//User//source//repos//davaleba123//davaleba123//IdAddress.xml");
            foreach (XmlNode x in b.SelectNodes("student"))
            {
                if (id == int.Parse(x.SelectSingleNode("id").InnerText))
                {
                    return x.SelectSingleNode("address").InnerText;
                }
            }
            return null;
        }
        private void button4_Click(object sender, EventArgs e)
        {

            Program.Decider = 0;
            
            Sender_.Load("C://Users//User//source//repos//davaleba123//davaleba123//hub.xml");
            XmlNode messegeee = Sender_.CreateElement("messege");
            XmlNode messege_ = Sender_.CreateElement("messege_");
            XmlNode Id = Sender_.CreateElement("id");
            XmlNode Sender = Sender_.CreateElement("Sender");
            XmlNode Topic = Sender_.CreateElement("Topic");
            XmlNode type = Sender_.CreateElement("Type");
         

            foreach (string x in checkedListBox1.CheckedItems) {

                for (int i = 0; i < StudentList.Count ;i++)
                {
                    
                        if (x == StudentList[i].fullname)
                        {
                            Sender.InnerText = StudentList[i].address;
                            Id.InnerText = StudentList[i].id;
                            messege_.InnerText = textBox3.Text;
                            Topic.InnerText = "grade";
                            type.InnerText = "Teacher_M" + " " + StudentList[i].fullname;

                            messegeee.AppendChild(Id);
                            messegeee.AppendChild(messege_);
                            messegeee.AppendChild(Sender);
                            messegeee.AppendChild(Topic);
                            messegeee.AppendChild(type);
                            Sender_.SelectSingleNode("hub").AppendChild(messegeee);

                        Sender_.Save("C://Users//User//source//repos//davaleba123//davaleba123//hub.xml");
                        Sender_.Load("C://Users//User//source//repos//davaleba123//davaleba123//hub.xml");

                    }

                }
            }

            Sender_.Save("C://Users//User//source//repos//davaleba123//davaleba123//hub.xml");
            Sender_.Load("C://Users//User//source//repos//davaleba123//davaleba123//hub.xml");

            Program.Decider = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.Decider = 0;
            Sender_.Load("C://Users//User//source//repos//davaleba123//davaleba123//hub.xml");
            Uinfo.Load("C://Users//User//source//repos//davaleba123//davaleba123//YourInfo.xml");
            if (comboBox1.SelectedItem!=null)
            {
                

                foreach(User x in StudentList) {
                    XmlNode messege = Sender_.CreateElement("messege");
                    XmlNode messege_ = Sender_.CreateElement("messege_");
                    XmlNode id = Sender_.CreateElement("id");
                    XmlNode Sender = Sender_.CreateElement("Sender");
                    XmlNode Topic= Sender_.CreateElement("Topic");
                    XmlNode type = Sender_.CreateElement("Type");
                    XmlNode Text = Sender_.CreateElement("Header");
                    messege_.InnerText = richTextBox1.Text;
                    Sender.InnerText = x.address;
                    Topic.InnerText = "HomeWork";
                    type.InnerText = Uinfo.SelectSingleNode("UInfo/Name").InnerText+" "+Uinfo.SelectSingleNode("UInfo/Lastname").InnerText;
                    id.InnerText = x.id;
                    Text.InnerText = textBox1.Text;
                   
                    messege.AppendChild(messege_);
                    messege.AppendChild(Text);
                    messege.AppendChild(Sender);
                    messege.AppendChild(Topic);
                    messege.AppendChild(type);
                    messege.AppendChild(id);
                    Sender_.SelectSingleNode("hub").AppendChild(messege);
            
                }
                
            }
            else if (comboBox1.SelectedItem == null)
            {
                alert("Class is not selected");
            }
            Sender_.Save("C://Users//User//source//repos//davaleba123//davaleba123//hub.xml");
            Program.Decider = 1;
        }
        void alert(string varn)
        {

        }
        private void button5_Click(object sender, EventArgs e)
        {   
            Program.Decider = 0;
            Sender_.Load("C://Users//User//source//repos//davaleba123//davaleba123//hub.xml");
            XmlNode messegeee = Sender_.CreateElement("messege");
            XmlNode messege_ = Sender_.CreateElement("messege_");
            XmlNode Id = Sender_.CreateElement("id");
            XmlNode Sender = Sender_.CreateElement("Sender");
            XmlNode Topic = Sender_.CreateElement("Topic");
            XmlNode type = Sender_.CreateElement("Type");
            foreach (string x in checkedListBox1.CheckedItems)
            {
                for(int i = 0; i< checkedListBox1.Items.Count; i++)
                {
                    if (x==StudentList[i].fullname)
                    {
                        Sender.InnerText = StudentList[i].address;
                        Id.InnerText = StudentList[i].id;
                        messege_.InnerText = textBox3.Text;
                        Topic.InnerText = "Messege";
                        type.InnerText = "Teacher_M";

                        messegeee.AppendChild(Id);
                        messegeee.AppendChild(messege_);
                        messegeee.AppendChild(Sender);
                        messegeee.AppendChild(Topic);
                        messegeee.AppendChild(type);
                        Sender_.SelectSingleNode("hub").AppendChild(messegeee);
                        Sender_.Save("C://Users//User//source//repos//davaleba123//davaleba123//hub.xml");
                        
                    }
                }
                
            }
            Program.Decider = 1;
        }

        private void Teachers_School_book_Load(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.Decider = 0;
           
            Uinfo.Load("C://Users//User//source//repos//davaleba123//davaleba123//YourInfo.xml");
            School.Load("C://Users//User//source//repos//davaleba123//davaleba123//School.xml");
            Sender_.Load("C://Users//User//source//repos//davaleba123//davaleba123//hub.xml");
            


            foreach (XmlNode x in School.SelectNodes("School/Students/Student"))
            {
                if (x.SelectSingleNode("Class").InnerText == Uinfo.SelectSingleNode("UInfo/Class/STudent").InnerText)
                {

                    StudentList.Add(new User(x.SelectSingleNode("Name").InnerText + " " + x.SelectSingleNode("Lastname").InnerText, x.SelectSingleNode("Id").InnerText, "  "));
                    comboBox1.Items.Add(x.SelectSingleNode("Name").InnerText + " " + x.SelectSingleNode("Lastname").InnerText);
                }

            }


            Program.Decider = 1;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
