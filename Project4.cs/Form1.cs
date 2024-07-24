using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Project4.cs
{
    public partial class Form1 : Form
    {
        XmlDocument xmlDocument;

        string pathName = Directory.GetCurrentDirectory() + "\\dateData.xml";
        public Form1()
        {
            InitializeComponent();

            CleanAllControls();

            xmlDocument = new XmlDocument();

            if (File.Exists(pathName))
            {
                try
                {
                    xmlDocument.Load(pathName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loadin XML file; " + ex.Message);
                }
            }

            else
            {
                XmlNode root = xmlDocument.CreateElement("Queries");

                xmlDocument.AppendChild(root);
                xmlDocument.Save(pathName);

            }
            showAllQueries();

        }

        private bool CreataDate(XmlNode root)
        {
            try
            {
                XmlNode query = xmlDocument.CreateElement("query");

                query.AppendChild(xmlDocument.CreateElement("day")).InnerText = cmbDay.Text;

                query.AppendChild(xmlDocument.CreateElement("dayMonth")).InnerText = cmbDayMonth.Text;

                query.AppendChild(xmlDocument.CreateElement("month")).InnerText = cmbMonth.Text;

                query.AppendChild(xmlDocument.CreateElement("year")).InnerText = cmbYear.Text;

                query.AppendChild(xmlDocument.CreateElement("result")).InnerText = txtResult.Text;



                root.AppendChild(query);


            }
            catch (Exception)
            {

                throw;
            }
            return true;
        }






        private void CleanAllControls()
        {
            foreach (Control ctr in Controls)
            {
                if (ctr is TextBox) ctr.Text = "";
                if (ctr is ComboBox) ctr.Text = "";
            }
        }

        private void showAllQueries()
        {

            foreach (XmlNode query in xmlDocument.FirstChild.ChildNodes)
            {
                string day = "", dayMonth = "", month = "", year = "", result = "";
                foreach (XmlNode node in query.ChildNodes)
                {
                    switch (node.Name)
                    {
                        case "day":
                            day = node.InnerText;
                            break;

                        case "dayMonth":
                            dayMonth = node.InnerText;
                            break;

                        case "month":
                            month = node.InnerText;
                            break;

                        case "year":
                            year = node.InnerText;
                            break;

                        case "result":
                            result = node.InnerText;
                            break;

                    }
                }
            }
        }

        private void CheckDays()
        {
           switch (cmbDay.Text)
            {
                case "ראשון":
                cmbDay.Text = "באחד";
                    break;

                case "שני":
                    cmbDay.Text = "בשני";
                    break;

                case "שלישי":
                    cmbDay.Text = "בשלישי";
                    break;

                case "רביעי":
                    cmbDay.Text = "ברביעי";
                    break;

                case "חמישי":
                    cmbDay.Text = "בחמישי";
                    break;

                case "שישי":
                    cmbDay.Text = "בששי";
                    break;


            }


        }

        private void CheckDayMonth()
        {
            switch (cmbDayMonth.Text)
            {
                case "1":
                    cmbDay.Text = "יום אחד לירח";
                    break;

                case "2":
                    cmbDay.Text = "שני ימים לירח";
                    break;

                case "3":
                    cmbDay.Text = "שלשה ימים";
                    break;

                case "4":
                    cmbDay.Text = "ארבעה ימים";
                    break;

                case "5":
                    cmbDay.Text = "חמשה ימים";
                    break;

                case "6":
                    cmbDay.Text = "ששה ימים";
                    break;

                case "7":
                    cmbDay.Text = "שבעה ימים";
                    break;

                case "8":
                    cmbDay.Text = "שמנה ימים";
                    break;

                case "9":
                    cmbDay.Text = "תשעה ימים";
                    break;

                case "10":
                    cmbDay.Text = "עשרה ימים";
                    break;

                case "11":
                    cmbDay.Text = "אחד עשר יום";
                    break;

                case "12":
                    cmbDay.Text = "שנים עשר יום";
                    break;

                case "13":
                    cmbDay.Text = "שלושה עשר יום";
                    break;

                case "14":
                    cmbDay.Text = "ארבעה עשר יום";
                    break;




            }


        }




        private void btnResult_Click(object sender, EventArgs e)
            {


                CreataDate(xmlDocument.FirstChild);

                xmlDocument.Save(pathName);

                CleanAllControls();

                showAllQueries();

            }



        }
    }




