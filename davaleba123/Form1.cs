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

        void Add(string name, string lastname, string id,string Class,string password)
        {
            if (checkBox2.Checked == true)
            {




                SQlcommun.addStudent(name+" "+lastname,Class,password);
                /*
                XmlNode Student = School.CreateElement("Student");
                XmlNode name_ = School.CreateElement("Name");
                XmlNode lastname_ = School.CreateElement("Lastname");
                XmlNode id_= School.CreateElement("Id");
                XmlNode password_ = School.CreateElement("Password");
                XmlNode Classes_ = School.CreateElement("Class");
                XmlNode exclusiveDb = School.CreateElement("DataBaseAdress");
                name_.InnerText = name;
                lastname_.InnerText = lastname;
                id_.InnerText = id;
                password_.InnerText = password;
                Classes_.InnerText = Class;
                
                

                Student.AppendChild(name_);
                Student.AppendChild(lastname_);
                Student.AppendChild(id_);
                Student.AppendChild(password_);
                Student.AppendChild(Classes_) ;
                School.GetElementsByTagName("Students")[0].AppendChild(Student);
                School.Save("C://Users//User//source//repos//davaleba123//davaleba123//School.xml");
                School.Load("C://Users//User//source//repos//davaleba123//davaleba123//School.xml");
                XmlDocument x = new XmlDocument();
                x.Load("C://Users//User//source//repos//davaleba123//davaleba123//IdAddress.xml");
                XmlNode Student_ = x.CreateElement("student");
                XmlNode iid = x.CreateElement("id");
                XmlNode andress = x.CreateElement("address");
                iid.InnerText = id;
                andress.InnerText = "";
                Student_.AppendChild(iid);
                Student_.AppendChild(andress);
                //x.SelectSingleNode("Students").AppendChild(Student_);
                Alert("Succes_R*S");
                */
            }
            if (checkBox1.Checked == true)
            {
                SQlcommun.addStudent(name + " " + lastname, Class, password);
                /*
                XmlNode Teacher = School.CreateElement("Teacher");
                XmlNode name_ = School.CreateElement("Name");
                XmlNode lastname_ = School.CreateElement("Lastname");
                XmlNode id_ = School.CreateElement("Id");
                XmlNode password_ = School.CreateElement("Password");
                XmlNode Classes_ = School.CreateElement("Class");
                
                name_.InnerText = name;
                lastname_.InnerText = lastname;
                id_.InnerText = id;
                password_.InnerText = password;
                Classes_.InnerText = Class;
                Teacher.AppendChild(name_);
                Teacher.AppendChild(lastname_);
                Teacher.AppendChild(id_);
                Teacher.AppendChild(password_);
                Teacher.AppendChild(Classes_);
                School.GetElementsByTagName("Teachers")[0].AppendChild(Teacher);
                School.Save("C://Users//User//source//repos//davaleba123//davaleba123//School.xml");
                School.Load("C://Users//User//source//repos//davaleba123//davaleba123//School.xml");
                XmlDocument x = new XmlDocument();
                x.Load("C://Users//User//source//repos//davaleba123//davaleba123//IdAddress.xml");
                XmlNode Student_ = x.CreateElement("teacher");
                XmlNode iid = x.CreateElement("id");
                XmlNode andress = x.CreateElement("address");
                iid.InnerText = id;
                andress.InnerText = "";
                Student_.AppendChild(iid);
                Student_.AppendChild(andress);
                //x.SelectSingleNode("Teachers").AppendChild(Student_);
                Alert("Succes_R*T");
                */
            }

        }

        bool Scheck(string name ,string lastname)
        {
           
            foreach (XmlNode x in School.SelectSingleNode("/School/Students").ChildNodes)
                {
                    if (x.SelectSingleNode("Name").InnerText == name && x.SelectSingleNode("Lastname").InnerText == lastname)
                    {
                        return false;
                    }

                }
                textBox8.Text = "e";
                return true;

            
        }
        bool Scheck(string name, string lastname , string password)
        {
            foreach (XmlNode x in School.SelectSingleNode("/School/Students").ChildNodes)
            {
               
                if (x.SelectSingleNode("Name").InnerText == name && x.SelectSingleNode("Lastname").InnerText == lastname && x.SelectSingleNode("Password").InnerText == password)
                {
                    
                    Alert("Taken_N*S");
                    return false;

                }
            }
            textBox8.Text = "e";
            return true;

        }
        bool Tcheck(string name, string lastname, string password)
        {


            foreach (XmlNode x in School.SelectNodes("/School/Teachers/Teacher"))
            {
                

                if (x.SelectSingleNode("Name").InnerText == name && x.SelectSingleNode("Lastname").InnerText == lastname&& x.SelectSingleNode("Password").InnerText == password)
                {

                        Alert("Taken_N_T");
                        textBox8.Text = "e";
                     
                        return false;
                    
                }
            }
            textBox8.Text = "e";
            return true;
        }
        bool Tcheck(string name,string lastname)
        {
   
            foreach (XmlNode x in School.SelectNodes("/School/Teachers/Teacher"))
            {
              

                if (x.SelectSingleNode("Name").InnerText == name && x.SelectSingleNode("Lastname").InnerText == lastname)
                {
                    Alert("Taken_N");
                    textBox8.Text = "I";
                    return false;
                    
                }
            }
            textBox8.Text = "e";
            return true;
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
           
            foreach (XmlNode x in School.SelectNodes("Student"))
            {
                
            }
            if (textBox4.Text==textBox6.Text) {
                
                if (checkBox1.Checked == true)
                {
                   
                    if (Tcheck(textBox5.Text, textBox3.Text) == true)
                    {
                        Generator = new Random();
                        string id = " ";
                        for (int i = 0; i < 10; i++)
                        {
                            id = id + Generator.Next(0, 9).ToString();
                        }
                        Class = comboBox1.SelectedItem as string;
                        
                        Add(textBox5.Text, textBox3.Text, id,Class, textBox4.Text);
                 
                    }

                } else if (checkBox2.Checked == true)
                {

                    if (Scheck(textBox5.Text, textBox3.Text) == true)
                    {
                        
                        Generator = new Random();
                        string id = " ";
                        for (int i = 0; i < 10; i++)
                        {
                            id = id + Generator.Next(0, 9).ToString();
                        }
                        Class = comboBox1.SelectedItem as string;
                        
                        Add(textBox5.Text, textBox3.Text,id,Class, textBox4.Text);
              
                    }

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
            if (Scheck(textBox1.Text,textBox7.Text,textBox2.Text)==false )
            {
                foreach (XmlNode x in School.SelectSingleNode("/School/Students").ChildNodes)
                {

                    if (x.SelectSingleNode("Name").InnerText == textBox1.Text && x.SelectSingleNode("Lastname").InnerText == textBox7.Text && x.SelectSingleNode("Password").InnerText == textBox2.Text)
                    {
                        UInfo = new List<string>() { };
                        UInfo.Add(x.SelectSingleNode("Name").InnerText);
                       UInfo.Add(x.SelectSingleNode("Lastname").InnerText);
                      UInfo.Add(x.SelectSingleNode("Password").InnerText);
                       UInfo.Add( x.SelectSingleNode("Id").InnerText);
                        UInfo.Add(x.SelectSingleNode("Class").InnerText);
                        UInfo.Add("Student");
                        Xload(UInfo);
                        this.Hide();
                        textBox8.Text=x.SelectSingleNode("Id").InnerText;
                       
                    }
                }
              
            }else if (Tcheck(textBox1.Text, textBox7.Text, textBox2.Text) == false)
            {
                foreach (XmlNode x in School.SelectSingleNode("/School/Teachers").ChildNodes)
                {
                    if (x.SelectSingleNode("Name").InnerText == textBox1.Text && x.SelectSingleNode("Lastname").InnerText == textBox7.Text && x.SelectSingleNode("Password").InnerText == textBox2.Text)
                    {
                        UInfo = new List<string>() { };
                        UInfo.Add(x.SelectSingleNode("Name").InnerText);
                        UInfo.Add(x.SelectSingleNode("Lastname").InnerText);
                        UInfo.Add(x.SelectSingleNode("Password").InnerText);
                        UInfo.Add(x.SelectSingleNode("Id").InnerText);
                        UInfo.Add(x.SelectSingleNode("Class").InnerText);
                        UInfo.Add("Teacher");
                        Xload(UInfo);
                        this.Hide();
                        textBox8.Text = x.SelectSingleNode("Id").InnerText;
                        
                    }
                }

            }
            Alert("Not_R");
           
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
