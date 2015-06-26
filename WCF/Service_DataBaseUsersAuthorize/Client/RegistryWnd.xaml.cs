using Client.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Client
{
    public partial class RegistryWnd : Window
    {
        AuthorizationClient client;

        public string Token { get; set; }

        public RegistryWnd()
        {
            InitializeComponent();

            client = new AuthorizationClient();

            this.btnReg.Click += btnReg_Click;
           
        }

        void btnReg_Click(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            string salt = string.Empty;

            if (tbName.Text.Length > 0
                && tbLastName.Text.Length > 0
                && tbLogin.Text.Length > 0
                && tbPassword.Text.Length > 0)
            {
                string res = client.AuthorizeMethod(tbLogin.Text, tbPassword.Text);
                if (res.Contains("error"))
                {
                    for (int i = 0; i < 16; i++)
                    {
                        salt += rand.Next(10);
                    }

                    string newPass = CalculateMD5Hash(tbPassword.Text);
                    newPass += salt;

                    string prepPass = CalculateMD5Hash(newPass);

                    if (client.CreateUser(tbName.Text, tbLastName.Text, tbLogin.Text, prepPass, salt))
                    {
                        MessageBox.Show("Successfully create");
                        Token = client.AuthorizeMethod(tbLogin.Text, prepPass);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Erorr, User is already exist");
                    }
                }
                else
                {
                    MessageBox.Show("User with such Login or Password is exist");
                }

            }
            else
            {
                MessageBox.Show("Some fields are empty");
            }
        }

        public string CalculateMD5Hash(string input)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
