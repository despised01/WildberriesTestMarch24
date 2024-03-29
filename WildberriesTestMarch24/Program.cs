namespace WildberriesTestMarch24
{
    class Program
    {
        static HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            // Токен аутентификации
            string authToken = "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJpYXQiOjE3MTE2MzMyMzYsInZlcnNpb24iOjIsInVzZXIiOiIyOTc3MTE1MyIsInNoYXJkX2tleSI6IjgiLCJjbGllbnRfaWQiOiJ3YiIsInNlc3Npb25faWQiOiIzNWY1ZTZjNzk4YTI0YWU2OTQ1NzY4YzQ1ZjRmN2UzNyIsInVzZXJfcmVnaXN0cmF0aW9uX2R0IjoxNjc0MTQyMzc5LCJ2YWxpZGF0aW9uX2tleSI6ImFlZGIxNDE3NTdkNWZjZjRlMWExZDhhODYyNDMwOGEwNzJhYWQ5NDIyOGM0NmNmMDcwZjU4MzIwMzBiNmVlMGEiLCJwaG9uZSI6IjN3dVlTT0c2Q1ZtblNJRmduMXpPWnc9PSJ9.Ot9YOpcK87bACsyRvWLAW7MSXzZiMVC_kTVhLoDzSGzCCNR71K60EeVNjBTgJc_FpabsnlikaTyrTckKI3iIF2yeRTSCbo6zTwMHwWr0-COMiMcW7k7qbkU8f09ktagyZvDar72nZ8CEK-aBSzMUhzfb1O4NVdcyIfh3SNlJQD6FFjsEzii7V6d1NW_X3KFAfQxlbRUzoKtvfxg1I37OURJm-NvVuiKQoycmmZHmeLHsxF5eqAod-VvAZlOgt-PVX4RwJThndIZKeh4tUoZdxXLu-n1KIyGQyP290jcvrzuM0Y5lUdOtR3XIg9M_smRqrxYA3-ufBSYPASgjN1uWgw";

            // Отправка запроса к API WB
            string apiUrl = "https://cart-storage-api.wildberries.ru";
            string endpoint = "/api/basket/sync?ts=1711710356884&device_id=site_cfa6b1c394314fc1b6c9438b8dff11d5";
            string response = await GetRequest(apiUrl + endpoint, authToken);

            Console.WriteLine(response);
        }

        static async Task<string> GetRequest(string url, string authToken)
        {
            // Добавление токена в заголовок запроса
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authToken);

            // Отправка GET запроса к API WB
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                // Получение ответа от API
                string responseData = await response.Content.ReadAsStringAsync();
                return responseData;
            }
            else
            {
                // Обработка ошибок запроса к API
                Console.WriteLine("Ошибка выполнения запроса: " + response.ReasonPhrase);
                return null;
            }   
        }
    }
}
