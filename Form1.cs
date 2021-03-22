using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace desafio_indigo_rpa
{
    public partial class Form1 : Form
    {
      

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
 
         
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                IWebDriver driver;
                driver = new ChromeDriver();

                try
                {
                   

                    driver.Navigate().GoToUrl("https://www.correios.com.br/");

                    //Maximiza tela
                    driver.Manage().Window.Maximize();
                    var text = driver.FindElement(By.XPath("/html/body/main/div[2]/div/main/div/div[2]/div/form[2]/div[2]/input[1]"));
                    text.Click();
                    string cep = textBox1.Text;
                    text.SendKeys(cep);
                    Thread.Sleep(5000);
                    var search = driver.FindElement(By.XPath("/html/body/main/div[2]/div/main/div/div[2]/div/form[2]/div[2]/button/i"));
                    search.Click();

                    Thread.Sleep(8000);


                    var logradouro = driver.FindElement(By.XPath("/html/body/main/form/div[1]/div[2]/div/div[3]/table/tbody/tr/td[1]")).Text;
                    var bairro = driver.FindElement(By.XPath("/html/body/main/form/div[1]/div[2]/div/div[3]/table/tbody/tr/td[2]")).Text;
                    var localidade = driver.FindElement(By.XPath("/html/body/main/form/div[1]/div[2]/div/div[3]/table/tbody/tr/td[3]")).Text;
                    var cepResult = driver.FindElement(By.XPath("/html/body/main/form/div[1]/div[2]/div/div[3]/table/tbody/tr/td[4]")).Text;





                    dataGridView1.Rows.Add();

                    dataGridView1.Rows[0].Cells[0].Value = logradouro;
                    dataGridView1.Rows[0].Cells[1].Value = bairro;
                    dataGridView1.Rows[0].Cells[2].Value = localidade;
                    dataGridView1.Rows[0].Cells[3].Value = cepResult;


                    dataGridView1.Visible = true;

                }
                finally
                {
                    driver.Quit();
                    MessageBox.Show("Processo finalizado");
                }

            }
            catch (Exception)
            {


                MessageBox.Show("Ocorreu um erro no RPA ");
            }
        }
    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
    
        
        }
    }
}
