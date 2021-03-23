using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab1.Arr;

namespace Lab1
{
    public partial class Form1 : Form
    {
        Arr.Mat arr = new Arr.Mat();
        Arr.Mat arrSource = new Arr.Mat();
        private int count = 0;

        public Form1()
        {
            InitializeComponent();
            EnterElement.Enabled = false;
            RandomGen.Enabled = false;
            numericUpDown2.Enabled = false;
            StartSort.Enabled = false;
        }

        private void EnterSize_Click(object sender, EventArgs e)
        {   
            arrSource.Size = Convert.ToInt32(numericUpDown1.Value);
            arrSource.Arr = new int[arrSource.Size];
            inputFromFileToolStripMenuItem.Enabled = false;
            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = true;
            EnterSize.Enabled = false;
            EnterElement.Enabled = true;
            RandomGen.Enabled = true;
            textBox1.Clear();
        }

        private void RandomGen_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            arrSource.RandomGenerate();
            for (int i = 0; i < arrSource.Size; i++)
            {              
                textBox1.Text += arrSource.Arr[i].ToString() + "  ";
            }
            StartSort.Enabled = true;
            EnterElement.Enabled = false;
            numericUpDown2.Enabled = false;
            count = arrSource.Size;
        }

        private void StartSort_Click(object sender, EventArgs e)
        {
            
            textBox2.Clear();
            if (arrSource.Size == 0)
            {
                MessageBox.Show("Enter Elements!");               
            }
            else if (arrSource.Size != count)
            {
                MessageBox.Show("Enter Elements!");
            }
            else
            {
                arr.Arr = new int[arrSource.Size];
                arr.Size = arrSource.Size;
                Array.Copy(arrSource.Arr, arr.Arr, arrSource.Size);
                //Array.Sort(arr.Arr, arr.Size - arr.Size, arr.Size);
                arr.Arr = Mat.Sort(arr.Arr);
                for (int i = 0; i < arr.Size; i++)
                {
                    textBox2.Text += arr.Arr[i].ToString() + "  ";
                }
                numericUpDown1.Enabled = true;
                EnterSize.Enabled = true;
                RandomGen.Enabled = false;
                EnterElement.Enabled = false;
                numericUpDown2.Enabled = false;
                inputFromFileToolStripMenuItem.Enabled = true;
                count = 0;
            }            
        }

        private void EnterElement_Click(object sender, EventArgs e)
        {
            RandomGen.Enabled = false;
            if (count < arrSource.Size)
            {
                arrSource.Arr[count] = Convert.ToInt32(numericUpDown2.Value);
                textBox1.Text += arrSource.Arr[count].ToString() + "  ";
                count++;
            }
            else
            {
                MessageBox.Show("Enough Elements!");
            }
            StartSort.Enabled = true;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            
        }

    

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            
        }

        

       

     

        private void inputFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                
                try
                {
                    arrSource.Arr = sr.ReadToEnd().Split(' ', '\n', '\r', '\t').Select(int.Parse).ToArray();
                    textBox1.Clear();
                    arrSource.Size = arrSource.Arr.Length;
                    for (int i = 0; i < arrSource.Size; i++)
                    {
                        textBox1.Text += arrSource.Arr[i].ToString() + "  ";
                    }
                    StartSort.Enabled = true;
                    EnterSize.Enabled = false;
                    numericUpDown1.Enabled = false;
                    count = arrSource.Size;
                    sr.Close();
                }
                catch
                {
                    MessageBox.Show("Invalid file");
                }
                
            }
        }

        private void saveResultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sr = new StreamWriter(saveFileDialog1.FileName);
                for (int i = 0; i < arrSource.Size; i++)
                {
                    if (i == 0)
                    {
                        sr.Write(arrSource.Arr[i]);
                    }
                    else
                    {
                        sr.Write(" " + arrSource.Arr[i]);
                    }
                }
                sr.Close();
            }
        }

        private void saveSourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sr = new StreamWriter(saveFileDialog1.FileName);
                for (int i = 0; i < arr.Size; i++)
                {
                    if (i == 0)
                    {
                        sr.Write(arr.Arr[i]);
                    }
                    else
                    {
                        sr.Write(" " + arr.Arr[i]);
                    }
                }
                sr.Close();
            }
        }

        private void aboutProgrammToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Автор: Нерадовский Артемий, 494 группа. \nПрограмма позволяет сортировать одномерный массив по возрастанию.",
                "About Programm",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Information);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
