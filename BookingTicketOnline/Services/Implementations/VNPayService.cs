using BookingTicketOnline.Configurations;
using BookingTicketOnline.Models;
using BookingTicketOnline.Services.Interfaces;
using BookingTicketOnline.Services;
using BookingTicketOnline.Services.Libraries;

namespace BookingTicketOnline.Services.Implementations
{
    public class VNPayService : IVNPayService
    {
        private readonly IConfiguration _configuration;
        private readonly VNPayConfig _vnPayConfig;

        public VNPayService(IConfiguration configuration)
        {
            _configuration = configuration;
            _vnPayConfig = _configuration.GetSection("VNPay").Get<VNPayConfig>()!;
        }

        public string CreatePaymentUrl(PaymentInformation payment, string returnUrl)
        {
            var timeZoneById = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
            var timeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZoneById);
            var tick = DateTime.Now.Ticks.ToString();
            var pay = new VNPayLibrary();

            pay.AddRequestData("vnp_Version", _vnPayConfig.Version);
            pay.AddRequestData("vnp_Command", _vnPayConfig.Command);
            pay.AddRequestData("vnp_TmnCode", _vnPayConfig.TmnCode);
            pay.AddRequestData("vnp_Amount", ((int)payment.Amount * 100).ToString());
            pay.AddRequestData("vnp_CreateDate", timeNow.ToString("yyyyMMddHHmmss"));
            pay.AddRequestData("vnp_CurrCode", _vnPayConfig.CurrCode);
            pay.AddRequestData("vnp_IpAddr", payment.IpAddress);
            pay.AddRequestData("vnp_Locale", _vnPayConfig.Locale);
            pay.AddRequestData("vnp_OrderInfo", $"{payment.OrderDescription} {payment.Name}");
            pay.AddRequestData("vnp_OrderType", payment.OrderType);
            pay.AddRequestData("vnp_ReturnUrl", returnUrl);
            pay.AddRequestData("vnp_TxnRef", tick);

            var paymentUrl = pay.CreateRequestUrl(_vnPayConfig.BaseUrl, _vnPayConfig.HashSecret);

            return paymentUrl;
        }

        public PaymentResponseModel PaymentExecute(IQueryCollection collections)
        {
            var pay = new VNPayLibrary();
            var response = pay.GetFullResponseData(collections, _vnPayConfig.HashSecret);

            return response;
        }
    }
}
