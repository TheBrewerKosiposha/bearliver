using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace ЛюбительПива
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string key;

        private void button1_Click(object sender, EventArgs e)
        {
            key=textBox1.Text;
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string source = openFileDialog1.FileName;
                saveFileDialog1.Filter = "des files |*.des";
                if(saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string dest = saveFileDialog1.FileName;
                    Encrypt(source, dest, key);
                }
            }
        }

        private void Encrypt(string s, string d,string k)
        {
            FileStream fsInput = new FileStream(s, FileMode.Open, FileAccess.Read); 
            FileStream fsEn = new FileStream(d, FileMode.Create, FileAccess.Write);
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            try
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                des.Key = ASCIIEncoding.ASCII.GetBytes(k);  
                des.IV = ASCIIEncoding.ASCII.GetBytes(k);
                ICryptoTransform cryptoTransform = des.CreateEncryptor();
                CryptoStream cryptoStream = new CryptoStream(fsEn, cryptoTransform, CryptoStreamMode.Write);
                byte[] bytes= new byte[fsInput.Length - 0];
                fsInput.Read(bytes, 0, bytes.Length);
                cryptoStream.Write(bytes, 0, bytes.Length);
                cryptoStream.Close();
                stopwatch.Stop();
                MessageBox.Show("time ="+stopwatch.ElapsedMilliseconds);
            }
            catch
            {
                MessageBox.Show("error");
                return;
            }
                fsInput.Close();

        }


        private void Dencrypt(string s, string d, string k)
        {
            FileStream fsInput = new FileStream(s, FileMode.Open, FileAccess.Read);
            FileStream fsEn = new FileStream(d, FileMode.Create, FileAccess.Write);
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            try
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                des.Key = ASCIIEncoding.ASCII.GetBytes(k);
                des.IV = ASCIIEncoding.ASCII.GetBytes(k);
                ICryptoTransform cryptoTransform = des.CreateDecryptor();
                CryptoStream cryptoStream = new CryptoStream(fsEn, cryptoTransform, CryptoStreamMode.Write);
                byte[] bytes = new byte[fsInput.Length - 0];
                fsInput.Read(bytes, 0, bytes.Length);
                cryptoStream.Write(bytes, 0, bytes.Length);
                cryptoStream.Close();
                stopwatch.Stop();
                MessageBox.Show("time =" + stopwatch.ElapsedMilliseconds);
            }
            catch
            {
                MessageBox.Show("error");
                return;
            }
            fsInput.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            key = textBox1.Text;
            openFileDialog1.Filter = "des files |*.des";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string source = openFileDialog1.FileName;
                saveFileDialog1.Filter = "txt files |*.txt";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string dest = saveFileDialog1.FileName;
                    Dencrypt(source, dest, key);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }



}