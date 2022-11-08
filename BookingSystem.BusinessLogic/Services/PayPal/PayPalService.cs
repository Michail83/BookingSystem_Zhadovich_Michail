using BookingSystem.BusinessLogic.BusinesLogicModels.PayPalModels;
using BookingSystem.DataLayer.EntityModels;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace BookingSystem.BusinessLogic.Services.Paypal
{
    public class PayPalService
    {
        OrderBLService _orderBLService;
        HttpClient _client;
        private readonly string _basePath;
        PayPalAuthService _payPalAuthService;
        public PayPalService(PayPalAuthService payPalAuthService, IConfiguration configuration, OrderBLService orderBLService)
        {
            _payPalAuthService = payPalAuthService;
            _orderBLService = orderBLService;
            _basePath = configuration.GetSection("PayPal")["baseUrl"];
            _client = new HttpClient()

            {
                BaseAddress = new Uri(_basePath)
            };
        }

        public async Task<string> CreatePaymentAsync(int orderId, string currentUser)
        {
            var accesToken = await _payPalAuthService.AccessTokenAsync();
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accesToken);
            var body = await CreatePayPalRequest(orderId, currentUser);

            var jsonPaypalRequest = JsonConvert.SerializeObject(body, Formatting.Indented, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });

            var content = new StringContent(jsonPaypalRequest, System.Text.Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/v2/checkout/orders", content);
            var order = await response.Content.ReadAsStringAsync();
            Debug.WriteLine(order);

            return order;
        }

        public async Task<bool> CapturePayment(string orderId, string user)
        {
            try
            {
                var accesToken = await _payPalAuthService.AccessTokenAsync();
                _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accesToken);
                var content = new StringContent("", System.Text.Encoding.UTF8, "application/json");

                var response = await _client.PostAsync($"/v2/checkout/orders/{orderId}/capture", content);
                var message = await response.Content.ReadAsStringAsync();

                var json = (JObject)JsonConvert.DeserializeObject(message);
                var jtokenCaptures = json["purchase_units"][0]["payments"]["captures"][0];

                var IsStatusCompleted = String.Equals(jtokenCaptures["status"].Value<string>(), "COMPLETED");

                if (IsStatusCompleted)
                {
                    var internalOrderId = jtokenCaptures["custom_id"].Value<int>();
                    var orderResult = await _orderBLService.GetAsync(internalOrderId, user);
                    if (orderResult.Success)
                    {
                        var order = orderResult.Data;
                        order.IsPaid = true;
                        order.PaidOrder = JsonConvert.SerializeObject(order);

                        await _orderBLService.UpdateAsync(order);

                        return true;

                    }
                    
                }

                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }


        }
        private async Task<PayPal_CreatedRequest> CreatePayPalRequest(int orderId, string currentUser)
        {
            var currency_code = "USD";
            var orderResult = await _orderBLService.GetAsync(orderId, currentUser);

            if (orderResult.Success)
            {
                var order = orderResult.Data;

                PayPal_CreatedRequest request = new();
                request.Intent = "CAPTURE";
                PayPal_Purchase_unit purchase_Unit = new();
                purchase_Unit.Amount.Currency_code = currency_code;
                purchase_Unit.Amount.Breakdown.Item_total.Currency_code = currency_code;
                purchase_Unit.Custom_id = order.Id.ToString();

                foreach (var ivent in order.ListOfReservedEventTickets)
                {

                    purchase_Unit.Items.Add(new PayPal_Item
                    {
                        Name = "ticket(s)",
                        Description = ivent.ArtEventBL.EventName,
                        Quantity = ivent.Quantity,
                        Unit_amount = new PayPal_Unit_amount()
                        {
                            Currency_code = currency_code,
                            Value = ivent.ArtEventBL.Price
                        }
                    });
                    var currentTotal = ivent.Quantity * ivent.ArtEventBL.Price;
                    purchase_Unit.Amount.Value += currentTotal;
                    purchase_Unit.Amount.Breakdown.Item_total.Value += currentTotal;
                }
                request.Purchase_units.Add(purchase_Unit);
                return request;

            }
            else return null;
            
        }
    }
}