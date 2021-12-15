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
using System.Threading;
using davaleba123;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace davaleba123
{
    public partial class Form1 : Form
    {
       
        public List<string> UInfo;
        string Class;
        Random Generator;
        XmlDocument School;
        public XmlDocument Exdatabase;
        //XmlDocument School;

        void Add(string name, string lastname,string Class,string password)
        {
            if (checkBox2.Checked == true)
            {




                SQlcommun.addStudent(name+" "+lastname,Class,password);
                
            }
            if (checkBox1.Checked == true)
            {
                SQlcommun.addStudent(name + " " + lastname, Class, password);
              
            }

        }

        
        public Form1()
        {
            InitializeComponent();
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        void Alert(string type)
        {
            if (type== "PassWord_Not")
            {

                label10.ForeColor = Color.Red;
                label10.Text = "PassWord Does not Match";
                label10.Visible = true;
            }
            if (type== "Succes_R*S")
            {
                label10.ForeColor = Color.Green;
                label10.Text = "Registerd!";
                label10.Visible = true;
            }
            if (type == "Succes_R*T")
            {
                label10.ForeColor = Color.Green;
                label10.Text = "Registerd!";
                label10.Visible = true;
            }
            if (type== "Taken_N*S")
            {
                label11.ForeColor = Color.Green;
                label11.Text = "Found!";
                label11.Visible = true;
            }
            if (type== "Taken_N_T")
            {
                label11.ForeColor = Color.Red;
                label11.Text = "Found!";
                label11.Visible = true;
            }
            if (type== "Taken_N")
            {
                label10.ForeColor = Color.Red;
                label10.Text = "Taken!";
                label10.Visible = true;
            }
         
        }
      

        private void button2_Click(object sender, EventArgs e)
        {
            School.Load("C://Users//User//source//repos//davaleba123//davaleba123//School.xml");
           
            if (textBox4.Text==textBox6.Text) {
                
                if (checkBox1.Checked == true)
                {
                   
                 
                        
                        Add(textBox5.Text, textBox3.Text,comboBox1.SelectedItem.ToString(), textBox4.Text);
                 
                    

                } else if (checkBox2.Checked == true)
                {

                   
                        Add(textBox5.Text, textBox3.Text, comboBox1.SelectedItem.ToString(), textBox4.Text);
              
                    

                }
            }
            else
            {
                Alert("PassWord_Not");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox2.Checked = false;
            comboBox1.Items.Add("C#");
            comboBox1.Items.Add("C++");

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            comboBox1.Items.Add("C#");
            comboBox1.Items.Add("C++");
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            School = new XmlDocument();
            
            School.Load("C://Users//User//source//repos//davaleba123//davaleba123//School.xml");
            label10.Visible = false;
            label11.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (SQlcommun.getStudent(textBox1.Text + " " + textBox7.Text) == true)
            {
                UInfo = new List<string>() { };

                string x;
                DataTable tb = SQlcommun.get_Student(textBox1.Text + " " + textBox7.Text);
                DataRow[] y = tb.Select();
                for(int i = 0; i< 5; i++)
                {
                    x = y[0][i].ToString();
                    UInfo.Add(x);
                }

               
                UInfo.Add("Student");
                Xload(UInfo);
                this.Hide();
                
            }
            else if (SQlcommun.getTeaecher(textBox1.Text + " " + textBox7.Text)==true)
            {
                DataTable tb = SQlcommun.get_Student(textBox1.Text + " " + textBox7.Text);
                DataRow[] y = tb.Select();
                string x;
                for (int i = 0; i< 5; i++)
                {
                    x = y[0][i].ToString();
                    UInfo.Add(x);
                }
                
               
               
                UInfo.Add("Teacher");
                Xload(UInfo);
                this.Hide();

            }
           
        }
        public  void Xload(List<string> x)
        {
            XmlDocument Uinfo =new XmlDocument();
            Uinfo.Load("C://Users//User//source//repos//davaleba123//davaleba123//YourInfo.xml");
            if (x[x.Count-1]=="Teacher")
            {

                // Application.Run(new Teachers_School_book());
                Teachers_School_book b = new Teachers_School_book();
                if (Uinfo.SelectSingleNode("UInfo/Name").InnerText==x[0] || Uinfo.SelectSingleNode("UInfo/Name").InnerText == null)
                {

                }
                else
                {
                    Uinfo.SelectSingleNode("UInfo/Name").InnerText=x[0];
                    Uinfo.SelectSingleNode("UInfo/Lastname").InnerText = x[1];
                    Uinfo.SelectSingleNode("UInfo/ID").InnerText = x[3];
                    Uinfo.SelectSingleNode("UInfo/Class").InnerText = x[4];
                    XmlNode Teach = Uinfo.CreateElement("STudent");
                    XmlNode cxriliG = Uinfo.CreateElement("CxriliT");
                   
                        x.Remove("STeacher");
                        x.Remove("CxriliS");

                    Teach.InnerText = x[4];
                    Uinfo.SelectSingleNode("UInfo/Class").AppendChild(Teach);
                    Uinfo.SelectSingleNode("UInfo/Class").AppendChild(cxriliG);
                    Uinfo.Save("C://Users//User//source//repos//davaleba123//davaleba123//YourInfo.xml");
                    Uinfo.Load("C://Users//User//source//repos//davaleba123//davaleba123//YourInfo.xml");

                }
                b.ShowDialog();
            }
            else if(x[x.Count-1]== "Student")
            {
                //Application.Run(new StudentsBook());
                StudentsBook b = new StudentsBook();
                if (Uinfo.SelectSingleNode("UInfo/Name").InnerText == x[0] || Uinfo.SelectSingleNode("UInfo/Name").InnerText == null)
                {

                }
                else
                {   
                    Uinfo.SelectSingleNode("UInfo/Name").InnerText = x[0];
                    Uinfo.SelectSingleNode("UInfo/Lastname").InnerText = x[1];
                    Uinfo.SelectSingleNode("UInfo/ID").InnerText = x[3];
                    Uinfo.SelectSingleNode("UInfo/Class").InnerText = x[4];

                    x.Remove("STudent");
                    x.Remove("CxriliT");
                    XmlNode Teach = Uinfo.CreateElement("STeacher");
                    XmlNode cxriliG = Uinfo.CreateElement("CxriliS");
                   
                    Teach.InnerText= x[4];
                    Uinfo.SelectSingleNode("UInfo/Class").AppendChild(Teach);
                    Uinfo.SelectSingleNode("UInfo/Class").AppendChild(cxriliG);
                    Uinfo.Save("C://Users//User//source//repos//davaleba123//davaleba123//YourInfo.xml");
                    Uinfo.Load("C://Users//User//source//repos//davaleba123//davaleba123//YourInfo.xml");
                    

                }
                
                b.ShowDialog();

            }


        }
      
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
            
        }
    }
}
