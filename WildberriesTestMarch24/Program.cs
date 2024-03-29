using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace WildberriesTestMarch24
{
    class Program
    {
        static HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            // Номенклатура товара
            string itemCode = "148748593";

            // Токен авторизации
            string authToken = "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJpYXQiOjE3MTE2MzMyMzYsInZlcnNpb24iOjIsInVzZXIiOiIyOTc3MTE1MyIsInNoYXJkX2tleSI6IjgiLCJjbGllbnRfaWQiOiJ3YiIsInNlc3Npb25faWQiOiIzNWY1ZTZjNzk4YTI0YWU2OTQ1NzY4YzQ1ZjRmN2UzNyIsInVzZXJfcmVnaXN0cmF0aW9uX2R0IjoxNjc0MTQyMzc5LCJ2YWxpZGF0aW9uX2tleSI6ImFlZGIxNDE3NTdkNWZjZjRlMWExZDhhODYyNDMwOGEwNzJhYWQ5NDIyOGM0NmNmMDcwZjU4MzIwMzBiNmVlMGEiLCJwaG9uZSI6IjN3dVlTT0c2Q1ZtblNJRmduMXpPWnc9PSJ9.Ot9YOpcK87bACsyRvWLAW7MSXzZiMVC_kTVhLoDzSGzCCNR71K60EeVNjBTgJc_FpabsnlikaTyrTckKI3iIF2yeRTSCbo6zTwMHwWr0-COMiMcW7k7qbkU8f09ktagyZvDar72nZ8CEK-aBSzMUhzfb1O4NVdcyIfh3SNlJQD6FFjsEzii7V6d1NW_X3KFAfQxlbRUzoKtvfxg1I37OURJm-NvVuiKQoycmmZHmeLHsxF5eqAod-VvAZlOgt-PVX4RwJThndIZKeh4tUoZdxXLu-n1KIyGQyP290jcvrzuM0Y5lUdOtR3XIg9M_smRqrxYA3-ufBSYPASgjN1uWgw";

            // Вызываем метод для добавления товара в корзину
            bool success = await AddItemToCart(itemCode, authToken);

            if (success)
            {
                Console.WriteLine($"Товар с номенклатурой {itemCode} успешно добавлен в корзину!");
            }
            else
            {
                Console.WriteLine($"Не удалось добавить товар с номенклатурой {itemCode} в корзину.");
            }
        }

        static async Task<bool> AddItemToCart(string itemCode, string authToken)
        {
            // URL для добавления товара в корзину
            string apiUrl = $"https://user-storage-01dp.wb.ru/api/v2/data/set";

            // Параметры запроса
            var requestData = new
            {
                goods = new[] { new { id = itemCode, quantity = 1 } }
            };

            // Добавляем токен авторизации в заголовок запроса
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);

            // Отправка POST запроса для добавления товара в корзину
            HttpResponseMessage response = await client.PostAsJsonAsync(apiUrl, requestData);

            // Проверка успешности выполнения запроса
            return response.IsSuccessStatusCode;
        }
    }
}
