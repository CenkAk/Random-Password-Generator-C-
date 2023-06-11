using System;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Random_Password_Generator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click (object sender, EventArgs e)
        {
            int length = Convert.ToInt32(numericUpDown1.Value);
            textBox1.Text = GeneratePassword(length);
        }

        private string GeneratePassword(int length)
        {
            string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()_-+=[{]};:>|./?";
            string password = "";
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                while(password.Length != length)
                {
                    byte[] oneByte = new byte[1];
                    rng.GetBytes(oneByte);
                    char character = (char)oneByte[0];
                    if (validChars.Contains(character.ToString()))
                    {
                        password += character;
                    }
                }
            }
            return password;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}