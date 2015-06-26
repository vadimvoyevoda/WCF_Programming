using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseUsers
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

    [ServiceContract]
    public interface IAuthorization
    {
        [OperationContract]
        string AuthorizeMethod(string Login, string Pass);

        [OperationContract]
        string UserInfoMethod(string accessToken);
    }


    public class Authorization : IAuthorization
    {
        Users_3VEntities users;
        DbSet<MyUsers> availableUsers;

        public Authorization()
        {
            
            users = new Users_3VEntities();
            availableUsers = users.MyUsers;
        }

        public string AuthorizeMethod(string Login, string Pass)
        {
            Random rand = new Random();
            AccToken tn = null;
            string token = String.Empty;

            foreach (var el in availableUsers)
            {                
                if (el.ULogin == Login && el.Pass == Pass)
                {
                    tn = new AccToken();
                    if (el.ExpDate > DateTime.Now && el.Token != null)
                    {
                        tn.Token = token = el.Token;
                        tn.ExpDate = el.ExpDate;
                        break;
                    }

                    for (int i = 0; i < 16; i++)
                    {
                        token += rand.Next(10);
                    }
                                        
                    tn.Token = el.Token = token;
                    tn.ExpDate = el.ExpDate = DateTime.Now.AddDays(1);
                    break;
                }
            }

            if (tn != null)
            {
                users.SaveChanges();
                return JsonConvert.SerializeObject(tn);
            }
            else
            {
                return null;
            }
        }

        public string UserInfoMethod(string accessToken)
        {
            foreach (var el in availableUsers)
            {
                if (el.Token == accessToken && el.ExpDate > DateTime.Now)
                {
                    UserInfoC info = new UserInfoC();
                    info.Name = el.UName;
                    info.LastName = el.ULastName;

                    return JsonConvert.SerializeObject(info);
                }
            }

            return null;
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost sh = new ServiceHost(typeof(Authorization));
            
            sh.Open();
            Console.WriteLine("Push any key for exit");
            Console.ReadKey();
            sh.Close();
        }
    }
}
