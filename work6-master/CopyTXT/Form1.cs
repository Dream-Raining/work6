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
            //�ж��û��Ƿ���ȷ��ѡ�����ļ�
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                //��ȡ�û�ѡ���ļ��ĺ�׺��
                string extension = Path.GetExtension(fileDialog.FileName);
                if (extension == ".txt")
                {
                    //��ȡ�û�ѡ����ļ�
                    fileInfo_First = new FileInfo(fileDialog.FileName);
                    this.textBox1.Text = fileInfo_First.FullName;
                }
                else
                {
                    this.textBox1.Text = "ѡ����ļ������ı��ļ���������ѡ��";
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