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

        [OperationContract]
        bool CreateUser(string Name, string LastN, string Login, string Pass, string Salt);
    }


    public class Authorization : IAuthorization
    {
        USERS_3VEntities1 users;
        DbSet<MyUsers> availableUsers;

        public Authorization()
        {
            
            users = new USERS_3VEntities1();
            availableUsers = users.MyUsers;
        }

        public string AuthorizeMethod(string Login, string Pass)
        {
            if (availableUsers.Count() > 0)
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
                        else
                        {
                            string error = "error:Token Data was expiried";
                            return JsonConvert.SerializeObject(error);
                        }

                        for (int i = 0; i < 16; i++)
                        {
                            token += rand.Next(10);
                        }

                        tn.Token = el.Token = token;
                        tn.ExpDate = el.ExpDate = DateTime.Now.AddDays(1);
                        break;
                    }
                    else
                    {
                        string error = "error:Wrong user login or password";
                        return JsonConvert.SerializeObject(error);
                    }
                }

                users.SaveChanges();
                return JsonConvert.SerializeObject(tn);
            }
            else
            {
                string error = "error:Users aren't found";
                return JsonConvert.SerializeObject(error);
            }
        }

        public string UserInfoMethod(string accessToken)
        {
            foreach (var el in availableUsers)
            {
                if (el.Token == accessToken)
                {
                    if (el.ExpDate > DateTime.Now)
                    {
                        UserInfoC info = new UserInfoC();
                        info.Name = el.UName;
                        info.LastName = el.ULastName;

                        return JsonConvert.SerializeObject(info);
                    }
                    else
                    {
                        string error = "error:Token Data was expiried";
                        return JsonConvert.SerializeObject(error);
                    }
                }
            }

            string error2 = "error:Not correct access token";
            return JsonConvert.SerializeObject(error2);
        }

        public bool CreateUser(string Name, string LastN, string Login, string Pass, string Salt)
        {
            try
            {
                foreach (var el in availableUsers)
                {
                    if (el.ULogin == Login)
                    {
                        return false;
                    }
                }

                MyUsers newUser = new MyUsers();
                newUser.UName = Name;
                newUser.ULastName = LastN;
                newUser.ULogin = Login;
                newUser.Pass = Pass;
                newUser.Salt = Salt;

                users.MyUsers.Add(newUser);
                users.SaveChanges();
                return true;
            }
            catch (Exception exc)
            {
                return false;
            }
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
