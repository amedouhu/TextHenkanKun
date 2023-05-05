using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace テキスト変換くん
{
    public partial class テキスト変換くん : Form
    {
        public テキスト変換くん()
        {
            InitializeComponent();
        }

        private void btEnter_Click(object sender, EventArgs e)
        {
            // 実行ボタンがクリックされたとき
            string input = tbInput.Text;
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            tbOutput.Text = null;
            foreach (byte b in bytes) {
                tbOutput.AppendText(Convert.ToString(b, 2).PadLeft(8, '0') + Environment.NewLine);
            }
        }

        private void 開くToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 開くボタンがクリックされたとき
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.Title = "開く";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string text = File.ReadAllText(filePath);
                tbInput.Text = text;
            }
            openFileDialog.Dispose();
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 保存ボタンがクリックされたとき
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "テキストファイル|*.txt";
            saveFileDialog.FileName = "テキスト変換くん.txt";
            saveFileDialog.Title = "保存";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                File.WriteAllText(saveFileDialog.FileName, tbOutput.Text);
            }

        }

        private void 初期化ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 初期化ボタンがクリックされたとき
            tbInput.Text = null;
            tbOutput.Text = null;
        }
    }
}
