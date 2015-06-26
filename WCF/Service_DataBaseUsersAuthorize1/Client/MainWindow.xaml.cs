using Client.Authorization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Client
{
    [DataContract]
    public class UserInfoC
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string LastName { get; set; }
    }

    [DataContract]
    public class AccToken
    {
        [DataMember]
        public string Token { get; set; }
        [DataMember]
        public DateTime? ExpDate { get; set; }
    }

    public partial class MainWindow : Window
    {
        AuthorizationClient client;
        AccToken token;

        public MainWindow()
        {
            InitializeComponent();

            client = new AuthorizationClient();

            this.btnLog.Click += btnLog_Click;
            this.btnInfo.Click += btnInfo_Click;            
        }

        void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            if (token != null)
            {
                string res = client.UserInfoMethod(token.Token);

                UserInfoC user = JsonConvert.DeserializeObject<UserInfoC>(res);
                tbInfo.Text += Environment.NewLine;
                tbInfo.Text += "UserName : " + user.Name;
                tbInfo.Text += Environment.NewLine;
                tbInfo.Text += "UserLastName : " + user.LastName;
            }
        }

        void btnLog_Click(object sender, RoutedEventArgs e)
        {
            if (tbLogin.Text.Length > 0 && tbPass.Text.Length > 0)
            {                
                string res = client.AuthorizeMethod(tbLogin.Text, tbPass.Text);
                if ( res != null)
                {
                    MessageBox.Show("Authorization was succesfull");
                    btnInfo.IsEnabled = true;

                    token = JsonConvert.DeserializeObject<AccToken>(res);
                    if (tbInfo.Text.Length > 0)
                    {
                        tbInfo.Text += Environment.NewLine;
                    }
                    tbInfo.Text += "Token : " + token.Token;
                    tbInfo.Text += " ExpDate : " + token.ExpDate;
                }
                else
                {
                    btnInfo.IsEnabled = false;
                }
            }
        }
    }
}
