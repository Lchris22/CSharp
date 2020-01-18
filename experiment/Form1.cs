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
    public partial class Form1 : Form
    {
        
        public static bool autosave = false;
        public static System.String actFile;
        public static System.String actFileName;
        public Form1()
        {
            InitializeComponent();
            refresh_list();
            deleteButton.Hide();
            richTextBox1.Hide();

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            save_data();
        }
        private void save_data()
        {
            if (autosave == true)
            {
                using (TextWriter writer = File.CreateText(actFile))
                {
                    writer.WriteLine(richTextBox1.Text);
                }
                Console.WriteLine("saved");
                //rename_file();
            }
            refresh_list();
        }
        private void openButton_Click(object sender, EventArgs e)
        {
            open_file();
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            //using (TextWriter writer = File.CreateText("c:\\Test\\" + actFile + ".txt"))
            //{
            //    writer.WriteLine(richTextBox1.Text);
            //}
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (listBox1.SelectedIndex >= 0)
            {
                actFile = "c:\\Test\\" + listBox1.Items[listBox1.SelectedIndex].ToString() + ".txt";
                actFileName = listBox1.Items[listBox1.SelectedIndex].ToString() + ".txt";
                open_file();
                deleteButton.Show();
                richTextBox1.Show();
            }
            else
            {
                // No item selected, handle that or return
            }
        }
        private void listBox1_Click(object sender, EventArgs e)
        {
            //Console.WriteLine("listbox_click");
            //actFile = "c:\\Test\\" + listBox1.Items[listBox1.SelectedIndex].ToString() + ".txt";
            //actFileName = listBox1.Items[listBox1.SelectedIndex].ToString() + ".txt";
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        public void rename_file()
        {
            //to get first line of file
            string[] lines = File.ReadAllLines(actFile);
            Console.Write(lines[0]);

            //to get original file name
            DirectoryInfo d = new DirectoryInfo(@"C:\Test");
            FileInfo[] infos = d.GetFiles();
            foreach (FileInfo f in infos)
            {
                Console.WriteLine("Actfilename="+actFileName);
                Console.WriteLine("f.fullname=" + f.FullName);
                File.Move(f.FullName, f.FullName.Replace(actFileName,lines[0]));

            }
            actFileName = lines[0];
            actFile= "c:\\Test\\" + actFileName+ ".txt";

        }
        public  void refresh_list()
        {
            listBox1.Items.Clear();
            string[] fileList;
            fileList = new string[20];
            ListViewItem list1 = new ListViewItem();
            DirectoryInfo d = new DirectoryInfo(@"c:\\Test");//Assuming Test is your Folder
            FileInfo[] Files = d.GetFiles("*.txt"); //Getting Text files
            foreach (FileInfo file in Files)
            {
                int i = 0;
                fileList[i] = file.Name;
                listBox1.Items.Add(Path.GetFileNameWithoutExtension(file.Name));
                i++;
            }
        }
        
        public  void open_file()
        {

            
            
            autosave = false;
            Console.WriteLine("open_click");
            //string path = "c:\\Test\\" +actFile+".txt";
            using (TextReader tr = File.OpenText(actFile))
            {
                //Console.WriteLine(tr.ReadToEnd());
                richTextBox1.Text = (tr.ReadToEnd());
            }
            Console.WriteLine("open_click_end");
            fileName.Text = actFileName;
            autosave = true;
        }
        public void popup_form2()
        {
            Form2 frm = new Form2();
            frm.ShowDialog();
        }


        private void newButton_Click(object sender, EventArgs e)
        { 
            popup_form2();
            
            open_file();
            refresh_list();
            richTextBox1.Show();

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            File.Delete(actFile);
            actFile = null;
            actFileName = null;
            refresh_list();
            deleteButton.Hide();
            richTextBox1.Hide();
            fileName.Text = null;
        }
    }
}
