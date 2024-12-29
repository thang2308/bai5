using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab03_02
{
    public partial class Lab03_02 : Form
    {
        public Lab03_02()
        {
            InitializeComponent();
        }
        int size = 14;
        string font = "Tahoma";
            private void AddFontInCMB()
        {
            foreach (FontFamily font in new InstalledFontCollection().Families) 
            {

                cbmFonts.Items.Add(font.Name);
            }
        }
        private void AddSizeInCMB()
        {
            int[] sizes = { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 50, 72 };

            foreach (int size in sizes)
            {
                cmbSizes.Items.Add(size);
            }
        }
        private void hệToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void địnhDạngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog();

            fontDlg.ShowColor = true;  
            fontDlg.ShowApply = true; 
            fontDlg.ShowEffects = true;  
            fontDlg.ShowHelp = true;  

            if (fontDlg.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.ForeColor = fontDlg.Color;
                richTextBox1.Font = fontDlg.Font;
            }
        }

        private void LamMoiRich()
        {
            richTextBox1.Clear();
            richTextBox1.Font = new Font("Tahoma", 14, FontStyle.Regular);
            cbmFonts.SelectedItem = "Tahoma";
            cmbSizes.SelectedItem = 14;
        }
        private void Lab03_02_Load(object sender, EventArgs e)
        {
            AddFontInCMB();
            AddSizeInCMB();
            LamMoiRich();
        }

        private void cmbSizes_SelectedIndexChanged(object sender, EventArgs e)
        {
            size = Int32.Parse(cmbSizes.Text);
            richTextBox1.Font = new Font(Font.FontFamily, size, FontStyle.Regular);   
        }

        private void cbmFonts_SelectedIndexChanged(object sender, EventArgs e)
        {
            font = cbmFonts.Text;
            richTextBox1.Font = new Font(font,size);
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tạoVănBảnMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LamMoiRich();
        }

        private void mởTậpTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text Files (*.txt)|*.txt|Rich Text Format (*.rtf)|*.rtf";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = ofd.FileName;

                if (selectedFileName.EndsWith(".txt"))
                {
                    richTextBox1.LoadFile(selectedFileName, RichTextBoxStreamType.PlainText);
                }
                else if (selectedFileName.EndsWith(".rtf"))
                {
                    richTextBox1.LoadFile(selectedFileName, RichTextBoxStreamType.RichText);
                }
            }
        }

        private void Lab03_02_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
            {
                LamMoiRich();  
                e.Handled = true;  
                return;  
            }

           
            if (e.Control && e.KeyCode == Keys.O)
            {
                mởTậpTinToolStripMenuItem_Click(this, e);  
                e.Handled = true;  
                return;  
            }

            
            if (e.Control && e.KeyCode == Keys.S)
            {
                toolStripButton2_Click(this, e);  
                e.Handled = true;  
                return;  
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.CheckPathExists = true;  
            saveFileDialog.Title = "Save Text File";  
            saveFileDialog.DefaultExt = "rtf";  
            saveFileDialog.Filter = "RichText Files (*.rtf)|*.rtf"; 
            saveFileDialog.RestoreDirectory = true;  
            saveFileDialog.AddExtension = true;  

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = saveFileDialog.FileName;

                try
                {
                    richTextBox1.SaveFile(selectedFileName, RichTextBoxStreamType.RichText);
                    MessageBox.Show("File saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while saving the file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lưuNộiDungVănBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.CheckPathExists = true;  
            saveFileDialog.Title = "Save Text File"; 
            saveFileDialog.DefaultExt = "rtf";  
            saveFileDialog.Filter = "RichText Files (*.rtf)|*.rtf";  
            saveFileDialog.RestoreDirectory = true;  
            saveFileDialog.AddExtension = true;  
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = saveFileDialog.FileName;  

                try
                {
                    richTextBox1.SaveFile(selectedFileName, RichTextBoxStreamType.RichText);
                    MessageBox.Show("File saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while saving the file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont.Bold)
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style & ~FontStyle.Bold);
            }
            else
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style | FontStyle.Bold);
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont.Italic)
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style & ~FontStyle.Italic);
            }
            else
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style | FontStyle.Italic);
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont.Underline)
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style & ~FontStyle.Underline);
            }
            else
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style | FontStyle.Underline);
            }
        }
    }
}
