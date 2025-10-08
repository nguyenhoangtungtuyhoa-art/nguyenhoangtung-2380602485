using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTap5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            foreach (FontFamily font in FontFamily.Families)
                toolStripComboBox1.Items.Add(font.Name);

            int defaultFontIndex = toolStripComboBox1.Items.IndexOf("Tahoma");
            toolStripComboBox1.SelectedIndex = defaultFontIndex >= 0 ? defaultFontIndex : 0;

            int[] fontSizes = { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            foreach (int size in fontSizes)
                toolStripComboBox2.Items.Add(size.ToString());

            int defaultSizeIndex = toolStripComboBox2.Items.IndexOf("14");
            toolStripComboBox2.SelectedIndex = defaultSizeIndex >= 0 ? defaultSizeIndex : 0;

            // Set default font for RichTextBox
            richTextBox1.Font = new Font("Tahoma", 14);

            toolStripComboBox1.SelectedIndexChanged += toolStripComboBox1_Click;
            toolStripComboBox2.SelectedIndexChanged += toolStripComboBox1_Click;

        }

        private void ChangeFont()
        {
            string fontName = toolStripComboBox1.SelectedItem?.ToString() ?? "Microsoft Sans Serif";
            float fontSize = 12f;
            float.TryParse(toolStripComboBox2.SelectedItem?.ToString(), out fontSize);

            if (richTextBox1.SelectionLength > 0)
                richTextBox1.SelectionFont = new Font(fontName, fontSize);
            else
                richTextBox1.Font = new Font(fontName, fontSize);
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            ChangeFont();
        }

        

        private void toolStripComboBox2_Click(object sender, EventArgs e)
        {
            ChangeFont();
        }

        private void địnhDạngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.ShowColor = true;
            fontDialog.ShowApply = true;
            fontDialog.ShowEffects = true; 
            if (fontDialog.ShowDialog() != DialogResult.Cancel)
            {
                richTextBox1.Font = fontDialog.Font;
                richTextBox1.ForeColor = fontDialog.Color;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();

            richTextBox1.Font = new Font("Tahoma", 14);

            int defaultFontIndex = toolStripComboBox1.Items.IndexOf("Tahoma");
            toolStripComboBox1.SelectedIndex = defaultFontIndex >= 0 ? defaultFontIndex : 0;

            int defaultSizeIndex = toolStripComboBox2.Items.IndexOf("14");
            toolStripComboBox2.SelectedIndex = defaultSizeIndex >= 0 ? defaultSizeIndex : 0;
        }

        private void tạoVănBảnMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();

            richTextBox1.Font = new Font("Tahoma", 14);

            int defaultFontIndex = toolStripComboBox1.Items.IndexOf("Tahoma");
            toolStripComboBox1.SelectedIndex = defaultFontIndex >= 0 ? defaultFontIndex : 0;

            int defaultSizeIndex = toolStripComboBox2.Items.IndexOf("14");
            toolStripComboBox2.SelectedIndex = defaultSizeIndex >= 0 ? defaultSizeIndex : 0;

            currentFilePath = null;
        }



        private string currentFilePath = null;
        private void mởTậpTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text Files (*.txt)|*.txt|Rich Text Files (*.rtf)|*.rtf";
                openFileDialog.Title = "Chọn tập tin để mở";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    if (filePath.EndsWith(".rtf", StringComparison.OrdinalIgnoreCase))
                    {
                        richTextBox1.LoadFile(filePath, RichTextBoxStreamType.RichText);
                    }
                    else
                    {
                        richTextBox1.LoadFile(filePath, RichTextBoxStreamType.PlainText);
                    }
                    currentFilePath = filePath;
                }
            }
        }

        private void lưuNộiDungVănBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentFilePath))
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Rich Text Files (*.rtf)|*.rtf";
                    saveFileDialog.Title = "Lưu văn bản";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        richTextBox1.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.RichText);
                        currentFilePath = saveFileDialog.FileName;
                        MessageBox.Show("Lưu văn bản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                richTextBox1.SaveFile(currentFilePath, RichTextBoxStreamType.RichText);
                MessageBox.Show("Lưu văn bản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
          
            var btn = sender as ToolStripButton;
            if (btn != null)
                btn.Checked = !btn.Checked;

            Font currentFont = richTextBox1.SelectionFont ?? richTextBox1.Font;
            FontStyle newFontStyle;

            if (currentFont.Bold)
                newFontStyle = currentFont.Style & ~FontStyle.Bold;
            else
                newFontStyle = currentFont.Style | FontStyle.Bold;

            richTextBox1.SelectionFont = new Font(currentFont, newFontStyle);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            var btn = sender as ToolStripButton;
            if (btn != null)
                btn.Checked = !btn.Checked;

            Font currentFont = richTextBox1.SelectionFont ?? richTextBox1.Font;
            FontStyle newFontStyle;

            if (currentFont.Italic)
                newFontStyle = currentFont.Style & ~FontStyle.Italic;
            else
                newFontStyle = currentFont.Style | FontStyle.Italic;

            richTextBox1.SelectionFont = new Font(currentFont, newFontStyle);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            var btn = sender as ToolStripButton;
            if (btn != null)
                btn.Checked = !btn.Checked;

            Font currentFont = richTextBox1.SelectionFont ?? richTextBox1.Font;
            FontStyle newFontStyle;

            if (currentFont.Underline)
                newFontStyle = currentFont.Style & ~FontStyle.Underline;
            else
                newFontStyle = currentFont.Style | FontStyle.Underline;

            richTextBox1.SelectionFont = new Font(currentFont, newFontStyle);
        }
    }
}
