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

namespace Directory_Work
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            //Create File comboBox
            comboBox1.Items.AddRange(drives);
            //Copy File comboBoxes
            comboBox4.Items.AddRange(drives);
            comboBox6.Items.AddRange(drives);
            //Delete File comboBox
            comboBox12.Items.AddRange(drives);
            //Move File comboBoxes
            comboBox8.Items.AddRange(drives);
            comboBox10.Items.AddRange(drives);
            //Streaming Tools comboBoxes
            comboBox14.Items.AddRange(drives);
            comboBox16.Items.AddRange(drives);
            //FileStream comboBoxes
            comboBox20.Items.AddRange(drives);
            comboBox18.Items.AddRange(drives);
            //Directory Tools comboBox
            comboBox26.Items.AddRange(drives);
            comboBox32.Items.AddRange(drives);
            
        }
        
        #region "Create File Section"
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo(comboBox1.Text);
            DirectoryInfo[] Folder = dir.GetDirectories();
            comboBox2.DataSource = Folder;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = comboBox1.Text + comboBox2.Text + "\\" + textBox3.Text + "." + textBox4.Text;
            if (!File.Exists(path))
            {
                if (textBox4.Text == "txt")
                {
                    File.Create(path);
                    MessageBox.Show("File Created Successfully!");
                }
                else
                    MessageBox.Show("Please write txt in extension, it is created to support only txt format");
            }
            else
                MessageBox.Show("File Already Exists, Please Rename it!");
        }
        #endregion
        #region "Delete File Section"
        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo(comboBox12.Text);
            DirectoryInfo[] Folder = dir.GetDirectories();
            comboBox11.DataSource = Folder;
        }
            private void button4_Click(object sender, EventArgs e)
        {
            string path = comboBox12.Text + comboBox11.Text + "\\" + textBox6.Text + "." + textBox5.Text;
            if (File.Exists(path))
            {
                File.Delete(path);
                MessageBox.Show("File Deleted Successfully!");
            }
            else
                MessageBox.Show("File Does Not Exist!");
        }
        #endregion
        #region "Copy File Section"
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo(comboBox4.Text);
            DirectoryInfo[] Folder = dir.GetDirectories();
            comboBox3.DataSource = Folder;
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo(comboBox6.Text);
            DirectoryInfo[] Folder = dir.GetDirectories();
            comboBox5.DataSource = Folder;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string path = comboBox4.Text + comboBox3.Text + "\\" + textBox2.Text;
            string path1 = comboBox6.Text + comboBox5.Text + "\\" + textBox2.Text;
            if (File.Exists(path))
            {
                if (!File.Exists(path1))
                {
                    File.Copy(path, path1);
                    MessageBox.Show("File Copied Successfully!");
                }
                else
                MessageBox.Show("File Already Existed!");
            }
            else
                MessageBox.Show("File Does Not Exist!");
        }
        #endregion
        #region "Move File Section"
        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo(comboBox10.Text);
            DirectoryInfo[] Folder = dir.GetDirectories();
            comboBox9.DataSource = Folder;
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo(comboBox8.Text);
            DirectoryInfo[] Folder = dir.GetDirectories();
            comboBox7.DataSource = Folder;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string path = comboBox10.Text + comboBox9.Text + "\\" + textBox1.Text;
            string path1 = comboBox8.Text + comboBox7.Text + "\\" + textBox1.Text;
            if (File.Exists(path))
            {
                if (!File.Exists(path1))
                {
                    File.Move(path, path1);
                    MessageBox.Show("File Moved Successfully!");
                }
                else
                    MessageBox.Show("File Already Existed!");
            }
            else
                MessageBox.Show("File Does Not Exist!");
        }
        #endregion
        #region "Stream Writer Section"
        private void comboBox14_SelectedIndexChanged(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo(comboBox14.Text);
            DirectoryInfo[] Folder = dir.GetDirectories();
            comboBox13.DataSource = Folder;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            string path = comboBox14.Text + comboBox13.Text + "\\" + textBox8.Text+"."+textBox7.Text;
            if (File.Exists(path))
            {
                StreamWriter sw = new StreamWriter(path, true);
                sw.WriteLine(richTextBox1.Text);
                sw.Close();
                MessageBox.Show("File Edited.");
            }
            else
                MessageBox.Show("File not found.");
        }
        #endregion
        #region "Stream Reader Section"
        private void comboBox16_SelectedIndexChanged(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo(comboBox16.Text);
            DirectoryInfo[] Folder = dir.GetDirectories();
            comboBox15.DataSource = Folder;
        }
            private void button6_Click(object sender, EventArgs e)
        {
            string path = comboBox16.Text + comboBox15.Text + "\\" + textBox10.Text + "." + textBox9.Text;
            if (File.Exists(path))
            {
                StreamReader sr = new StreamReader(path);
                string text = sr.ReadToEnd();
                richTextBox2.Text = text;
                sr.Close();
            }
            else
                MessageBox.Show("File not found.");
        }
        #endregion
        #region "File Stream Writer"
            private void comboBox20_SelectedIndexChanged(object sender, EventArgs e)
            {
                DirectoryInfo dir = new DirectoryInfo(comboBox20.Text);
                DirectoryInfo[] Folder = dir.GetDirectories();
                comboBox19.DataSource = Folder;
            }
                private void button8_Click(object sender, EventArgs e)
            {
            string path = comboBox20.Text + comboBox19.Text + "\\" + textBox14.Text + "." + textBox13.Text;
            if (File.Exists(path))
            {
                byte[] b = new byte[100];
                char[] c = new char[100];
                FileStream fs = new FileStream(path, FileMode.Append);
                c = richTextBox4.Text.ToCharArray();
                Encoder en = Encoding.UTF8.GetEncoder();
                en.GetBytes(c,0,c.Length,b,0,true);
                fs.Write(b,0,b.Length);
                fs.Close();
                MessageBox.Show("File Edited!");
            }
            else
                MessageBox.Show("File not found.");
        }
        #endregion
        #region "File Stream Reader"
            private void comboBox18_SelectedIndexChanged(object sender, EventArgs e)
            {
                DirectoryInfo dir = new DirectoryInfo(comboBox18.Text);
                DirectoryInfo[] Folder = dir.GetDirectories();
                comboBox17.DataSource = Folder;
            }
                private void button7_Click(object sender, EventArgs e)
            {
                string path = comboBox18.Text + comboBox17.Text + "\\" + textBox12.Text + "." + textBox11.Text;
                if (File.Exists(path))
                {
                    byte[] b = new byte[100];
                    char[] c = new char[100];
                    FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                    fs.Seek(0, SeekOrigin.Begin);
                    fs.Read(b, 0, b.Length);
                    Decoder d = Encoding.UTF8.GetDecoder();
                    d.GetChars(b, 0, b.Length, c, 0, true);
                    string s = new string(c);
                    richTextBox3.Text = s;
                    fs.Close();
                }
                else
                    MessageBox.Show("File not found.");
            }
            #endregion
        #region "Create Directory Section"
        private void button10_Click(object sender, EventArgs e)
        {
            string path = comboBox26.Text + "\\" + textBox16.Text;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                MessageBox.Show("Directory Created Successfully!");
            }
            else
                MessageBox.Show("Directory Already Existed, Please Rename it!");
        }
        #endregion
        #region "Delete Directory Section"
        private void comboBox32_SelectedIndexChanged(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo(comboBox32.Text);
            DirectoryInfo[] Folder = dir.GetDirectories();
            comboBox31.DataSource = Folder;
        }
        private void button12_Click(object sender, EventArgs e)
        {
            string path = comboBox32.Text + comboBox31.Text;
            if (Directory.Exists(path))
            {
                Directory.Delete(path);
                MessageBox.Show("Directory Deleted Successfully!");
            }
            else
                MessageBox.Show("Directory Does Not Exist!");
        }
        #endregion
        

    }
}