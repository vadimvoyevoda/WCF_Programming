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
        RegistryWnd wnd;

        public MainWindow()
        {
            InitializeComponent();

            client = new AuthorizationClient();

            this.btnLog.Click += btnLog_Click;
            this.btnInfo.Click += btnInfo_Click;
            btnReg.Click += btnReg_Click;
        }

        void btnReg_Click(object sender, RoutedEventArgs e)
        {
            wnd = new RegistryWnd();
            wnd.Closing += wnd_Closing;            
            wnd.ShowDialog();
        }

        void wnd_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            token = JsonConvert.DeserializeObject<AccToken>(wnd.Token);
            ClientAuthorize();
        }
        
        void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            if (token != null)
            {
                string res = client.UserInfoMethod(token.Token);

                try
                {
                    UserInfoC user = JsonConvert.DeserializeObject<UserInfoC>(res);
                    tbInfo.Text += Environment.NewLine;
                    tbInfo.Text += "UserName : " + user.Name;
                    tbInfo.Text += Environment.NewLine;
                    tbInfo.Text += "UserLastName : " + user.LastName;
                }
                catch (Exception exc)
                {
                    tbInfo.Text += JsonConvert.DeserializeObject<string>(res);
                }
            }
        }

        void btnLog_Click(object sender, RoutedEventArgs e)
        {
            ClientAuthorize();
        }

        void ClientAuthorize()
        {
            if (tbLogin.Text.Length > 0 && tbPass.Text.Length > 0)
            {
                string res = client.AuthorizeMethod(tbLogin.Text, tbPass.Text);
                if (!res.Contains("error:"))
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
                    tbInfo.Text += JsonConvert.DeserializeObject<string>(res);
                }
            }
        }
    }
}
