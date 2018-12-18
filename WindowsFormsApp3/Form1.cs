using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<string> list = new List<string>();

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "текстовые файлы|*.txt"; //только файлы с расширением «.txt»

            if (fd.ShowDialog() == DialogResult.OK)
            {
                Stopwatch t = new Stopwatch();
                t.Start();

                string text = File.ReadAllText(fd.FileName); //чтение файла в виде строки

                char[] separators = new char[] { ' ', '.', ',', '!', '?', '/', '\t', '\n' }; //разделительные символы для чтения из файла
                string[] textArray = text.Split(separators);
                foreach (string strTemp in textArray) //дубликаты слов не записываются
                {
                    string str = strTemp.Trim();
                    if (!list.Contains(str)) list.Add(str);
                }

                t.Stop();
                this.textBox2.Text = t.Elapsed.ToString(); // вывод времени в поле textBox2
            }
            else
            {
                MessageBox.Show("Выберете файл!");
            }
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string word = this.textBox1.Text.Trim();

            if (!string.IsNullOrWhiteSpace(word) && list.Count > 0) //если не пусто
            {

                string wordUpper = word.ToUpper(); //поиск в верхнем регистре

                List<string> tempList = new List<string>();
                Stopwatch t = new Stopwatch();
                t.Start();
                foreach (string str in list)
                {
                    if (str.ToUpper().Contains(wordUpper))
                    {
                        tempList.Add(str);
                    }
                }
                t.Stop();
                this.textBox3.Text = t.Elapsed.ToString(); //вывод времени
                this.listBox1.BeginUpdate();

                this.listBox1.Items.Clear();

                foreach (string str in tempList) // вывод результатов в список listBox1
                {
                    this.listBox1.Items.Add(str);
                }
                this.listBox1.EndUpdate();
            }
            else
            {
                MessageBox.Show("Выберете файл и введите слово, которые необходимо найти!");
            }

        }
    }
}