using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Week4Prova_Store.Client.Contracts;

namespace Week4Prova_Store.Client
{
    //Da correggere 
    public static class Menu
    {
        internal static void Start()
        {
            bool quit = false;
            char choice;
            do
            {
                Console.WriteLine("Seleziona un'opzione del menu" +
                        "\n[ 1 ] - Elenco di tutti gli ordini" +
                        "\n[ 2 ] - Crea un ordine" +
                        "\n[ 3 ] - Modifica un ordine" +
                        "\n[ 5 ] - Cancella un ordine" +
                        "\n[ q ] - ESCI");

                choice = Console.ReadKey().KeyChar;

                switch (choice)
                {
                    case '1':
                        FetchOrders();
                        break;
                    case '2':
                      
                        break;
                    case '3':
                        
                        break;
                    case '4':

                        break;
                    case '5':
                       
                        break;
                    case 'q':
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("Scelta non corretta.");
                        break;
                }
            } while (!quit);
        }

       

        private static void FetchOrders()
        {
            HttpClient client = new HttpClient();

            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://localhost:44318/api/Order")
            };






            var response = client.SendAsync(request).Result;


            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = response.Content.ReadAsStringAsync().Result;
                

                var data = JsonConvert.DeserializeObject<List<OrderContract>>(jsonResponse);

                foreach (OrderContract order in data)
                    Console.WriteLine($"[{order.OrderCode}] " +
                        $"{order.OrderDate} - {order.ProductCode} - {order.Amount} - {order.CustomerId}");
            }
        }
    }
}

       
   
