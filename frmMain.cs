using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CovidReg
{
    public partial class frmMain : Form
    {
        public IWebDriver driver;

        public frmMain()
        {
            InitializeComponent();
            driver = new FirefoxDriver();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                driver.Close();
                driver.Quit();
            } catch(Exception)
            {
                //
            }
        }

        private void btnGetStarted_Click(object sender, EventArgs e)
        {
            driver.Url = "https://test-for-coronavirus.service.gov.uk/register-kit/registering-for";
            driver.Navigate();

            doTestingFor();
            btnGetStarted.Visible = false;
            grpStudent.Visible = true;

            MessageBox.Show("Please scan the barcode then return to this form");
        }

        private void doTestingFor()
        {
            var chkOther = driver.FindElement(By.Id("testing-self-2"));
            chkOther.Click();

            clickSubmit();
        }

        private void btnStudentID_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtStudentID.Text))
            {
                MessageBox.Show("Please enter a student ID");
                return;
            }

            if(driver.Url != "https://test-for-coronavirus.service.gov.uk/register-kit/test-site-code")
            {
                MessageBox.Show("Sorry, you're not on the right page.");
                return;
            }

            var stud = LoadStudentDetails();

            if(stud == null)
            {
                MessageBox.Show("No student was found with this ID number. Please try again");
                return;
            }

            doTestID();
            confirmTestSite();
            doTestPilot();
            doTestDate();

            doStudentName(stud.firstName, stud.lastName);
            doDOB(stud.dob);
            doGender(stud.isMale);

            while (driver.Url == "https://test-for-coronavirus.service.gov.uk/register-kit/ethnicity-group")
            {
                MessageBox.Show("Please enter the student's ethnicity information then return to this form");
            }

            doEducation();

            while(driver.Url == "https://test-for-coronavirus.service.gov.uk/register-kit/condition" || driver.Url == "https://test-for-coronavirus.service.gov.uk/register-kit/travelled-overseas" || driver.Url == "https://test-for-coronavirus.service.gov.uk/register-kit/positive-tested" || driver.Url == "https://test-for-coronavirus.service.gov.uk/register-kit/vaccination-status")
            {
                MessageBox.Show("Please answer the questions for this student then return to this form");
            }

            doAddress(stud.firstLine, stud.postCode);
            doContact(stud.email, stud.mobile);

            MessageBox.Show("Please confirm the details, complete the captcha then click the start button");

            grpStudent.Visible = false;
            btnGetStarted.Visible = true;
        }

        private Student LoadStudentDetails()
        {
            Student s = null;

            //TODO: GET YOUR STUDENT DETAILS HERE

            return s;
        }

        private void clickSubmit()
        {
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            Thread.Sleep(1000);
        }

        private void doTestID()
        {
            var siteID = driver.FindElement(By.Id("testSiteCode"));
            siteID.SendKeys("BOEE");
            clickSubmit();
        }

        private void confirmTestSite()
        {
            driver.FindElement(By.Id("confirm-test-site")).Click();
            clickSubmit();
        }

        private void doTestPilot()
        {
            driver.FindElement(By.Id("serialTesting-2")).Click();
            clickSubmit();
        }

        private void doTestDate()
        {
            driver.FindElement(By.Id("testDateRadioOption")).Click();
            var hour = driver.FindElement(By.Id("testTimeHour"));

            bool isAfternoon = false;
            int hourTime = 0;

            if(DateTime.Now.Hour > 12)
            {
                isAfternoon = true;
                hourTime = DateTime.Now.Hour - 12;
            } else if(DateTime.Now.Hour == 12)
            {
                isAfternoon = true;
                hourTime = 12;
            }
            else
            {
                hourTime = DateTime.Now.Hour;
            }

            hour.SendKeys(hourTime.ToString());

            if (isAfternoon)
            {
                driver.FindElement(By.Id("testTimeStamp-2")).Click();
            } else
            {
                driver.FindElement(By.Id("testTimeStamp")).Click();
            }

            clickSubmit();
        }

        private void doStudentName(string fName, string lName)
        {
            var firstName = driver.FindElement(By.Id("first-name"));
            firstName.SendKeys(fName);

            var lastName = driver.FindElement(By.Id("last-name"));
            lastName.SendKeys(lName);

            clickSubmit();
        }

        private void doDOB(DateTime dob)
        {
            var d = driver.FindElement(By.Id("date-of-birth-day"));
            d.SendKeys(dob.Day.ToString());

            var m = driver.FindElement(By.Id("date-of-birth-month"));
            m.SendKeys(dob.Month.ToString());

            var y = driver.FindElement(By.Id("date-of-birth-year"));
            y.SendKeys(dob.Year.ToString());

            clickSubmit();
        }

        private void doGender(bool isMale)
        {
            if (isMale)
            {
                driver.FindElement(By.Id("gender")).Click();
            } else
            {
                driver.FindElement(By.Id("gender-2")).Click();
            }

            clickSubmit();
        }

        private void doEducation()
        {
            driver.FindElement(By.Id("currently-working-2")).Click();
            clickSubmit();

            driver.FindElement(By.Id("grade-4")).Click();
            clickSubmit();

            var college = driver.FindElement(By.Id("institution-name"));
            college.SendKeys("Bury College");

            var town = driver.FindElement(By.Id("institution-town"));
            town.SendKeys("Bury");

            clickSubmit();
        }

        private void doAddress(string line1, string postCode)
        {
            driver.FindElement(By.Id("country")).Click();
            clickSubmit();

            var addr = driver.FindElement(By.Id("address-line-1"));
            addr.SendKeys(line1);

            var pCode = driver.FindElement(By.Id("postcode"));
            pCode.SendKeys(postCode);

            clickSubmit();
        }

        private void doContact(string email, string mobile)
        {
            driver.FindElement(By.Id("email-available")).Click();
            Thread.Sleep(100);

            var e = driver.FindElement(By.Id("email"));
            e.SendKeys(email);

            var e1 = driver.FindElement(By.Id("email-confirmation"));
            e1.SendKeys(email);

            clickSubmit();

            var m = driver.FindElement(By.Id("mobile"));
            m.SendKeys(mobile);

            var m1 = driver.FindElement(By.Id("mobile-confirmation"));
            m1.SendKeys(mobile);

            clickSubmit();

            driver.FindElement(By.Id("landline-available-2")).Click();
            clickSubmit();

            driver.FindElement(By.Id("nhs-number-option-2")).Click();
            clickSubmit();
        }
    }
}
