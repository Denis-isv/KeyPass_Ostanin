using AppKeyPass_Ostanin.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AppKeyPass_Ostanin.Contexts
{
    public class StorageContext
    {
        static string url = "https://localhost:7135/storage/";

        public static async Task<List<Storage>?> Get()
        {
            try
            {
                using (HttpClient Client = new HttpClient())
                {
                    using (HttpRequestMessage Request = new HttpRequestMessage(HttpMethod.Get, url + "get"))
                    {
                        Request.Headers.Add("token", MainWindow.Token ?? "");
                        var Response = await Client.SendAsync(Request);

                        if (Response.StatusCode == HttpStatusCode.OK)
                        {
                            string sResponse = await Response.Content.ReadAsStringAsync();
                            return JsonConvert.DeserializeObject<List<Storage>>(sResponse);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки:\n" + ex.Message);
            }
            return null;
        }

        public static async Task<Storage> Add(Storage storage)
        {
            try
            {
                using (HttpClient Client = new HttpClient())
                {
                    using (HttpRequestMessage Request = new HttpRequestMessage(HttpMethod.Post, url + "add"))
                    {
                        Request.Headers.Add("token", MainWindow.Token ?? "");
                        string JsonStorage = JsonConvert.SerializeObject(storage);
                        Request.Content = new StringContent(JsonStorage, Encoding.UTF8, "application/json");

                        var Response = await Client.SendAsync(Request);

                        if (Response.StatusCode == HttpStatusCode.OK)
                        {
                            string sResponse = await Response.Content.ReadAsStringAsync();
                            return JsonConvert.DeserializeObject<Storage>(sResponse);
                        }
                        else
                        {
                            MessageBox.Show("Сервер вернул ошибку: " + Response.StatusCode);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка добавления:\n" + ex.Message);
            }
            return null;
        }

        public static async Task<Storage> Update(Storage storage)
        {
            try
            {
                using (HttpClient Client = new HttpClient())
                {
                    using (HttpRequestMessage Request = new HttpRequestMessage(HttpMethod.Put, url + "update"))
                    {
                        Request.Headers.Add("token", MainWindow.Token ?? "");
                        string JsonStorage = JsonConvert.SerializeObject(storage);
                        Request.Content = new StringContent(JsonStorage, Encoding.UTF8, "application/json");

                        var Response = await Client.SendAsync(Request);

                        if (Response.StatusCode == HttpStatusCode.OK)
                        {
                            string sResponse = await Response.Content.ReadAsStringAsync();
                            return JsonConvert.DeserializeObject<Storage>(sResponse);
                        }
                        else
                        {
                            MessageBox.Show("Сервер вернул ошибку: " + Response.StatusCode);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка обновления:\n" + ex.Message);
            }
            return null;
        }

        public static async Task Delete(int id)
        {
            try
            {
                using (HttpClient Client = new HttpClient())
                {
                    using (HttpRequestMessage Request = new HttpRequestMessage(HttpMethod.Delete, url + "delete"))
                    {
                        Request.Headers.Add("token", MainWindow.Token ?? "");
                        Dictionary<string, string> FormData = new Dictionary<string, string> { ["id"] = id.ToString() };
                        Request.Content = new FormUrlEncodedContent(FormData);

                        var Response = await Client.SendAsync(Request);
                        if (Response.StatusCode != HttpStatusCode.OK)
                            MessageBox.Show("Ошибка удаления: " + Response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка удаления:\n" + ex.Message);
            }
        }
    }
}