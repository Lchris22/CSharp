using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace experiment
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            createButton.Hide();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        public void validateUserEntry()
        {
            // Checks the value of the text.
            if (textBox1.Text.Length == 0)
            {
                createButton.Hide();

            }
            else
                createButton.Show();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            
            Form1.actFile= "c:\\Test\\" + textBox1.Text + ".txt";
            Form1.actFileName= textBox1.Text + ".txt";
            var fileStream = File.Create(Form1.actFile);
            fileStream.Close();
            this.Close();


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            validateUserEntry();
        }

        
    }
}
