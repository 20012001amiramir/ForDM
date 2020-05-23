using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VkNet;
using System.Threading.Tasks;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Model.RequestParams;

namespace ForDataMining
{
    class IdAndGroups
    {
        public string nickname;
        public long[] groups;
        public IdAndGroups(string id, long[] groups)
        {
            this.nickname = id;
            this.groups = groups;
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            VkApi api = new VkApi();
            ulong AppID = 6666666;//Api приложения
            string email = "";//ваш логин
            string password = "";//ваш пароль
            Settings setting = Settings.All;
            try
            {
                api.Authorize(new ApiAuthParams()
                {
                    Login = email,
                    Password = password,
                    ApplicationId = AppID,
                    Settings = setting
                });
            }
            catch
            {
                new Exception("Логин или пароль, неверны");
            }
            List<long> groupsmy = new List<long>();
            List<long> f = new List<long>();
            var gr = new IdAndGroups[100000000000000000];//кол-во друзей в вк
            var grup = api.Groups.Get(new GroupsGetParams() { UserId = api.UserId, Extended = true });
            var frends = api.Friends.Get(new FriendsGetParams() { Fields = ProfileFields.LastName });
            int a = 0;
            foreach (var g in frends)
            {
                f.Add(g.Id);
                List<long> sd = new List<long>();
                foreach (var aas in api.Groups.Get(new GroupsGetParams() { UserId = g.Id, Extended = true }))
                {
                    sd.Add(aas.Id);
                }
                gr[a] = new IdAndGroups(g.LastName, sd.ToArray<long>());
                a++;
            }
            foreach (var g in grup)
            {
                groupsmy.Add(g.Id);
            }
            List<string> druzya = new List<string>();
            for (int i = 0; i < gr.Length; i++)
            {
                if(IdGetFas(gr[i].nickname, groupsmy.ToArray<long>(), gr[i].groups) != null)
                    druzya.Add(IdGetFas(gr[i].nickname, groupsmy.ToArray<long>(), gr[i].groups));
            }
            foreach (var r in druzya) Console.WriteLine(r.ToString());
            Console.ReadLine();
        }
        public static string IdGetFas(string nick, long[] mygr, long[] frgr)
        {
            int counter = 0;
            foreach (var a in mygr)
            {
                foreach (var b in frgr)
                {
                    if (a == b) counter++;
                }
            }
            if (counter >= 5) return nick;
            else return null;
        }
    }
    
}

