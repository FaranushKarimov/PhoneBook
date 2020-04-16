
namespace PhoneBook_App
{
    using System;
    using System.Threading.Tasks;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using Newtonsoft.Json.Linq;

    class Authentication
    {
        public String user_id { get; set; }

        /// <summary>
        /// Проверка на наличие почты и пароля
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int loginUser(String email, String password)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost/phonebook/tutorial/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync("login.php?email=" +
                         email + "&password=" +
                         password).Result;

                string res = "";

                using (HttpContent content = response.Content)
                {
                    Task<string> result = content.ReadAsStringAsync();
                    res = result.Result;
                }

                JObject o = JObject.Parse(res);
                String error = o["exists"].ToString();

                if (error.Equals("False"))
                {
                    return 0;
                }
                else
                {
                    user_id = o["uid"].ToString();
                    return 1;
                }
                return 0;
            }
        }

        /// <summary>
        /// Добавление нового пользователя
        /// </summary>
        /// <param name="name"> Первый параметр имя пользователя</param>
        /// <param name="email">Второй параметр почта пользователя</param>
        /// <param name="password">Третий парметр пароль</param>
        /// <returns>Возвращает полученный результат</returns>
        public int registerUser(String name, String email, String password)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost/phonebook/tutorial/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync("registeruser.php?name=" +
                         name + "&email=" +
                         email + "&password=" +
                         password).Result;

                string res = "";

                using (HttpContent content = response.Content)
                {
                    Task<string> result = content.ReadAsStringAsync();
                    res = result.Result;
                }

                JObject o = JObject.Parse(res);
                String error = o["error_msg"].ToString();

                if (error.Equals("True"))
                {
                    return 0;
                }
                else
                {
                    JObject user = JObject.Parse(o["user"].ToString());
                    user_id = user["id"].ToString();
                    return 1;
                }
                return 0;
            }
        }

    }
}
