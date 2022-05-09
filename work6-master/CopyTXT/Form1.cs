namespace CopyTXT
{
    public partial class Form1 : Form
    {
        FileInfo fileInfo_First;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            //判断用户是否正确的选择了文件
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                //获取用户选择文件的后缀名
                string extension = Path.GetExtension(fileDialog.FileName);
                if (extension == ".txt")
                {
                    //获取用户选择的文件
                    fileInfo_First = new FileInfo(fileDialog.FileName);
                    this.textBox1.Text = fileInfo_First.FullName;
                }
                else
                {
                    this.textBox1.Text = "选择的文件不是文本文件，请重新选择。";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.label1.Text = "";
            StreamReader reader = null;
            try
            {
                FileStream fin = new FileStream(fileInfo_First.FullName, FileMode.Open, FileAccess.Read);
                reader = new StreamReader(fin, System.Text.Encoding.Default);
                int linNum = 0;
                string s = string.Empty;
                while ((s = reader.ReadLine()) != null)
                {
                    linNum++;
                    this.label1.Text += s + "\n";
                }
            }
            catch(FileNotFoundException)
            {
                this.Dispose();
            }
        }
    }
}