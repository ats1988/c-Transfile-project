using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace WindowsFormsApplication17
{
    public partial class Transfile : Form
    {

        const string path = null;
        const string target = null;
        

        public Transfile()
        {
            InitializeComponent();
            label2.Text = null;
            pictureBox1.Hide();
            label4.Text = null;
            label5.Text = "";
            label6.Text = "file search box in folder Library";
            label7.Text = "";
            pictureBox2.Hide();

            listBox1.Items.Clear();
            listBox1.SelectionMode = SelectionMode.MultiExtended;
            listBox2.SelectionMode = SelectionMode.MultiExtended;
            listBox2.Font = new Font("Microsoft Sans Serif", 8.0F);


            //Path.GetDirectoryName(Application.ExecutablePath).Replace(@"C:\Library", string.Empty);

            //string appath = Path.GetDirectoryName(Application.ExecutablePath);

            try
            {
                string path = Directory.GetCurrentDirectory();
                string target = @"C:\Library";
                if (!Directory.Exists(target))
                {
                    Directory.CreateDirectory(target);
                }
                Environment.CurrentDirectory = (target);
                if (path.Equals(Directory.GetCurrentDirectory()))
                    MessageBox.Show("you are in the temp directory");
                //else
                //{ //MessageBox.Show("you r not in the temp directory");
                
                //}
            }
            catch (Exception e)
            {
                MessageBox.Show("The process failed: {}", e.ToString());
            }

        }

        string for_ME = null;

        public void Copy(string source,string targy)
        {
            try
            {
                if (File.Exists(targy))
                {
                    File.Delete(targy);
                
                }
                File.Copy(source,targy);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        
        }




        public static void MoveWithReplace(string sourceFileName, string destFileName)
        {
              //first, delete target file if exists, as File.Move() does not support overwrite
            if (File.Exists(destFileName))
            {
                File.Delete(sourceFileName);
            }
            File.Move(sourceFileName, destFileName);
        }

        public void fadeWAY(PictureBox pic)
        {
            this.Opacity = 1;
            for (double cont = 1; cont >= 0; cont -= 0.1)
            {
                
                this.Opacity = cont;
                this.Refresh();
                System.Threading.Thread.Sleep(15);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            // label6.Text = "";
            try
            {
                string pathname = @"C:\Library\";
                //if (!Directory.Exists(pathname))
                //{
                    DirectoryInfo di = new DirectoryInfo(pathname);
                    FileInfo[] fi = di.GetFiles("*",SearchOption.AllDirectories);

                    foreach (FileInfo f in fi)
                    {
                        listBox2.Items.Add(f.Name);
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void הוראותשימושToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Instructions f2 = new Instructions();
            f2.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About ab1 = new About();
            ab1.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        // Create folder Button
        private void button1_Click(object sender, EventArgs e)
        {
            for_ME = "successfully created"; //string newFileName = @"C:\Library";
            
            
            if (textBox1.Text == null || textBox1.Text == "")
            { pictureBox1.Hide(); label2.ForeColor = Color.Red; label2.Text = "you select nothing"; }
            else 
            {
                Directory.Exists(textBox1.Text);
                Directory.CreateDirectory(textBox1.Text);
                //    System.IO.File.Copy(filename, newFileName, true);
                label2.Text = for_ME;
                pictureBox1.Show();
                label2.ForeColor = Color.Black;
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            label4.Text = "";
            
            try
            {
                OpenFileDialog folderPicker = new OpenFileDialog(); string filename = "";
                if(folderPicker.ShowDialog() == DialogResult.OK)
                {
                    string files = folderPicker.FileName;
                    filename = System.IO.Path.GetFileName(files);
                    //**
                    listBox1.Items.Add(filename);
                    pictureBox2.Show();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Blue;
            int selected = listBox1.SelectedItems.Count;
            try
            {
            if(selected == 0)
            {
                MessageBox.Show("no item selected in this content box");
                label4.Text = "";
            }
            if (selected != -1)
            {
                for (int i = selected - 1; i >= 0; i--)
                {
                    listBox1.Items.Remove(listBox1.SelectedItems[i]);
                    pictureBox2.Hide();
                    label4.Text = "Item remove succsusfuly";
                }
            }
            
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label4.Text = "";
            try
            {
                FolderBrowserDialog folderPicker = new FolderBrowserDialog(); //string filename;
                if (folderPicker.ShowDialog() == DialogResult.OK)
                {
                    string foldername = folderPicker.SelectedPath;
                    foreach (string f in Directory.GetFiles(foldername))
                        this.listBox1.Items.Add(Path.GetFileName(f));    
                    
                    pictureBox2.Show();
                    
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            pictureBox1.Hide();
            label2.Text = "";
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }


        FolderBrowserDialog folder_Picker = new FolderBrowserDialog();
        const string foldername = null;
        const string folderStorage = null;
        

        private void button7_Click(object sender, EventArgs e)
        {
            label5.Text = ""; label5.ForeColor = Color.Blue;
            try
            {
                if (folder_Picker.ShowDialog() == DialogResult.OK)
                {
                    string foldername = folder_Picker.SelectedPath ;
                    //string folderStorage = folder_Picker.RootFolder;
                    label5.Text = Path.GetFullPath(foldername);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Blue;
            try
            {


                int selected = listBox1.Items.Count;
                if (selected == 0)
                {
                    label4.Text = "";
                    MessageBox.Show("no item selected in this content box");
                }


                //if (selected != -1)
                //{
                //    for (int i = selected - 1; i >= 0; i--)
                //    {

                //string from = listBox1.SelectedItems.Count.ToString();
                //string to = path;

                //DirectoryInfo dicopufrom = new DirectoryInfo(from);
                //FileInfo fidiskfiles = new FileInfo();
                if (selected != -1)
                {
                    foreach (string curfile in listBox1.Items)
                    {
                        
                        string path11 = curfile;
                        string path22 = /*@"C:\Library\A"*/folder_Picker.SelectedPath + @"\" + path11;


                        if (!File.Exists(path11))
                        {

                            using (FileStream fs = File.Create(path11)) { }
                            label4.Text = "Item transferd";
                        }
                        else
                        {

                            MessageBox.Show("the item is already exists");
                        }

                        //path22=  System.IO.Directory.GetCurrentDirectory();

                        File.Move(path11, path22);

                        listBox1.Items.Remove(curfile);



                    }
                    pictureBox2.Hide();
                     
                }
            }
            catch
            {

            }

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }
        
        private void button8_Click(object sender, EventArgs e)
        {

            listBox2.SelectedItems.Clear();
            for (int i= listBox2.Items.Count-1; i >= 0;i-- )
            {
                if (listBox2.Items[i].ToString().ToLower().Contains(textBox2.Text))
                {
                    listBox2.SetSelected(i,true);
                }
               
            }
            label7.Text = listBox2.SelectedItems.Count.ToString() + " items found";

        }
        /*
        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
         */

        //**


        private void delete_file_Click(object sender, EventArgs e)
        {
            try
            {

                string path_name = @"C:\Library\";
                DirectoryInfo dii = new DirectoryInfo(path_name);
                FileInfo[] fil = dii.GetFiles("*",SearchOption.AllDirectories);

                foreach (FileInfo fi in fil)
                {
                    listBox2.SelectedItem = fi;
                    
                    
                        if (listBox2.SelectedItem.ToString() == fi.Name)
                        {
                           // File.Delete(fi.ToString());
                           // listBox2.Items.Remove(listBox2.SelectedItem);
                            fi.Delete(); listBox2.Items.Remove(fi.Name);
                        }
                        
                }
                
            }
            catch 
            {

            }

        }

        private void Font_Click(object sender, EventArgs e)
        {
                listBox2.Font = new Font("Tahoma", 12.0F);
        }

        private void diffrent_color_Click(object sender, EventArgs e)
        {
            if (listBox2.ForeColor != Color.Indigo)
            {
                listBox2.ForeColor = Color.Indigo;
                listBox2.BackColor = Color.SlateGray;
            }
            else
            {
                listBox2.ForeColor = Color.Black;
                listBox2.BackColor = Color.White;
            }
        }

        

        



        

       
        
    }
}
