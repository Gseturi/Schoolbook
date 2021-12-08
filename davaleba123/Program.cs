using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Xml;
using System.Data.SqlClient;    
namespace davaleba123
{
    public static class Program
    {
      
        public static int Decider = 1;
        static XmlDocument hub;
        static XmlDocument School;
        static XmlDocument app;
        public static Thread MessegeSender;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {

            
            hub = new XmlDocument();
            School = new XmlDocument();

            MessegeSender = new Thread(Sender);
            MessegeSender.Start();
            app = new XmlDocument();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());


        }
       
        static void Sender()
        {

            while (true)
            {
                if (Decider == 3)
                {
                    hub.Load("C://Users//User//source//repos//davaleba123//davaleba123//hub.xml");
                    //app.Load(x.SelectSingleNode("Sender").InnerText);
                    app.Load("C://Users//User//source//repos//davaleba123//davaleba123//tempstudent.xml");
                    foreach (XmlNode x in hub.SelectNodes("hub/messege"))
                    {
            
                       
                            if (x.SelectSingleNode("Topic") == null || x.SelectSingleNode("Topic").InnerText==null)
                            {
                            }
                            else if (x.SelectSingleNode("Topic").InnerText != null)
                            {
                                if (x.SelectSingleNode("Topic").InnerText == "Messege")
                                {

                                    XmlNode Messege = app.CreateElement("Messege");
                                    XmlNode Text = app.CreateElement("Text");
                                    XmlNode type = app.CreateElement("Type");
                                    XmlNode From = app.CreateElement("Teacher");

                                    Text.InnerText = x.SelectSingleNode("messege_").InnerText;
                                    type.InnerText = x.SelectSingleNode("Topic").InnerText;
                                    From.InnerText = x.SelectSingleNode("Type").InnerText;

                                    Messege.AppendChild(Text);
                                    Messege.AppendChild(type);
                                    Messege.AppendChild(From);
                                    app.SelectSingleNode("Messeges").AppendChild(Messege);
                                    app.SelectSingleNode("Messeges").AppendChild(Messege);

                                    app.Save("C://Users//User//source//repos//davaleba123//davaleba123//tempstudent.xml");
                                    x.RemoveAll();
                                    hub.Save("C://Users//User//source//repos//davaleba123//davaleba123//hub.xml");

                                }

                                if (x.SelectSingleNode("Topic").InnerText == "HomeWork")
                                {

                                    XmlNode Messege = app.CreateElement("HomeWork");
                                    XmlNode Text = app.CreateElement("Text");
                                    XmlNode type = app.CreateElement("Type");
                                    XmlNode From = app.CreateElement("Teacher");
                                     XmlNode header = app.CreateElement("titel");
                                    Text.InnerText = x.SelectSingleNode("messege_").InnerText;
                                    type.InnerText = x.SelectSingleNode("Topic").InnerText;
                                    From.InnerText = x.SelectSingleNode("Type").InnerText;
                                    header.InnerText = x.SelectSingleNode("Header").InnerText;
                                    Messege.AppendChild(Text);
                                    Messege.AppendChild(type);
                                    Messege.AppendChild(From);
                                     Messege.AppendChild(header);
                                    app.SelectSingleNode("Messeges").AppendChild(Messege);
                                    app.SelectSingleNode("Messeges").AppendChild(Messege);

                                    app.Save("C://Users//User//source//repos//davaleba123//davaleba123//tempstudent.xml");
                                    x.RemoveAll();
                                    hub.Save("C://Users//User//source//repos//davaleba123//davaleba123//hub.xml");

                                }



                               /* if (x.SelectSingleNode("Topic").InnerText == "grade")
                                {

                                    XmlNode Messege = app.CreateElement("Grade");
                                    XmlNode Text = app.CreateElement("Text");
                                    XmlNode type = app.CreateElement("Type");
                                    XmlNode From = app.CreateElement("Teacher");

                                    Text.InnerText = x.SelectSingleNode("messege_").InnerText;
                                    type.InnerText = x.SelectSingleNode("Topic").InnerText;
                                    From.InnerText = x.SelectSingleNode("Type").InnerText;

                                    Messege.AppendChild(Text);
                                    Messege.AppendChild(type);
                                    Messege.AppendChild(From);
                                    app.SelectSingleNode("Messeges").AppendChild(Messege);
                                    app.SelectSingleNode("Messeges").AppendChild(Messege);

                                    app.Save("C://Users//User//source//repos//davaleba123//davaleba123//tempstudent.xml");
                                    x.RemoveAll();
                                    hub.Save("C://Users//User//source//repos//davaleba123//davaleba123//hub.xml");

                                }*/
                            }
                        }

                        Thread.Sleep(1);

                    }
                }
            }
        }
    }

