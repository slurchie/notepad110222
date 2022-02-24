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

namespace notePad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            saveFileDialog1.Filter = "Text File(*.txt)|*.txt";
           
        }
        bool tbChange = false;
        string docPath = "";


        private void Form1_Load(object sender, EventArgs e)
        {

            this.Width = Properties.Settings.Default.formWidth;
            this.Height = Properties.Settings.Default.formHeight;
            richTextBox1.Clear();
            openFileDialog1.FileName = @"data\Text2.txt";
            openFileDialog1.Filter ="Текстовые файлы (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.Filter = "Текстовые файлы (*.txt)|*.txt|All files (*.*)|*.*";
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;
            File.WriteAllText(filename,richTextBox1.Text);
            MessageBox.Show("Файл сохранён");
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var Писатель = new System.IO.StreamWriter(
                    saveFileDialog1.FileName, false,
                                        System.Text.Encoding.GetEncoding(1251));
                    Писатель.Write(richTextBox1.Text);
                    Писатель.Close();
                }
                catch (Exception Ситуация)
                { // отчет о других ошибках
                    MessageBox.Show(Ситуация.Message,
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            saveFileDialog1.FileName = openFileDialog1.FileName;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var Писатель = new System.IO.StreamWriter(saveFileDialog1.FileName, false,System.Text.Encoding.GetEncoding(1251));
                    Писатель.Write(richTextBox1.Text);
                    Писатель.Close();
                }
                catch (Exception Ситуация)
                { // отчет о других ошибках
                    MessageBox.Show(Ситуация.Message,
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;
            string fileText = File.ReadAllText(filename);
            richTextBox1.Text = fileText;
            MessageBox.Show("Файл открыт!");
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName == String.Empty) return;
            // Чтение текстового файла
            try
            {
                var Читатель = new System.IO.StreamReader(
                openFileDialog1.FileName, Encoding.GetEncoding(1251));
                richTextBox1.Text = Читатель.ReadToEnd();
                Читатель.Close();
            }
            catch (System.IO.FileNotFoundException Ситуация)
            {
                MessageBox.Show(Ситуация.Message + "\nНет такого файла",
                         "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception Ситуация)
            { // отчет о других ошибках
                MessageBox.Show(Ситуация.Message,
                     "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
                richTextBox1.Copy();
        }

        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
                richTextBox1.Paste();
        }

        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
                richTextBox1.Cut();
        }

        private void НастройкиШрифтаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            richTextBox1.Font = fontDialog1.Font;

        }

        private void настройкиФонаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            richTextBox1.BackColor = colorDialog1.Color;
        }

        private void выделитьВсёToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
                richTextBox1.SelectAll();
        
        }

        private void richTextBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button==MouseButtons.Right)
            {
                richTextBox1.ContextMenuStrip = contextMenuStrip2;
            }
        }

        private void копироватьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
                richTextBox1.Copy();
        }

        private void вырезатьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
                richTextBox1.Cut();
        }

        private void вставитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
                richTextBox1.Paste();
        }

        private void выделитьВсёToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
                richTextBox1.SelectAll();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.Show();
        }

        private void переносПоСловамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mFormatTransfer.CheckState == CheckState.Checked)
            {
                richTextBox1.WordWrap = true;
                richTextBox1.ScrollBars = RichTextBoxScrollBars.Vertical;
                mEditGo.Enabled = false;
                statusLab1.Visible = false;
                statusLab1.Visible = false;
            }
            else
            {
                richTextBox1.WordWrap = false;
                richTextBox1.ScrollBars = RichTextBoxScrollBars.Both;
                mEditGo.Enabled = true;
                statusLab1.Visible = true;
                statusLab1.Visible = true;
            }
        }
    }
   
}
