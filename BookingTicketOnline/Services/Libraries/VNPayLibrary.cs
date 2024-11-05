using BookingTicketOnline.Models;
using System.Globalization;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace BookingTicketOnline.Services.Libraries
{
    public class VNPayLibrary
    {
        private readonly SortedList<string, string> _requestData = new SortedList<string, string>(new VnPayCompare());
        private readonly SortedList<string, string> _responseData = new SortedList<string, string>(new VnPayCompare());

        public void AddRequestData(string key, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                _requestData.Add(key, value);
            }
        }

        public string CreateRequestUrl(string baseUrl, string vnpHashSecret)
        {
            var data = new StringBuilder();

            foreach (KeyValuePair<string, string> kv in _requestData)
            {
                if (!string.IsNullOrEmpty(kv.Value))
                {
                    data.Append(WebUtility.UrlEncode(kv.Key) + "=" + WebUtility.UrlEncode(kv.Value) + "&");
                }
            }

            string queryString = data.ToString();
            baseUrl += "?" + queryString;
            String signData = queryString;
            if (signData.Length > 0)
            {
                signData = signData.Remove(data.Length - 1, 1);
            }

            string vnpSecureHash = HmacSHA512(vnpHashSecret, signData);
            baseUrl += "vnp_SecureHash=" + vnpSecureHash;

            return baseUrl;
        }

        public PaymentResponseModel GetFullResponseData(IQueryCollection collection, string vnpHashSecret)
        {
            var vnpayData = new PaymentResponseModel();
            foreach (var (key, value) in collection)
            {
                if (!string.IsNullOrEmpty(key) && key.StartsWith("vnp_"))
                {
                    _responseData.Add(key, value.ToString());
                }
            }

            vnpayData.OrderDescription = _responseData.GetValueOrDefault("vnp_OrderInfo", "");
            vnpayData.TransactionId = _responseData.GetValueOrDefault("vnp_TransactionNo", "");
            vnpayData.OrderId = _responseData.GetValueOrDefault("vnp_TxnRef", "");
            vnpayData.PaymentMethod = _responseData.GetValueOrDefault("vnp_BankCode", "");
            vnpayData.PaymentId = _responseData.GetValueOrDefault("vnp_PayDate", "");
            vnpayData.Token = _responseData.GetValueOrDefault("vnp_SecureHash", "");
            vnpayData.VnPayResponseCode = _responseData.GetValueOrDefault("vnp_ResponseCode", "");

            var secureHash = _responseData.GetValueOrDefault("vnp_SecureHash", "");
            bool checkSignature = ValidateSignature(secureHash, vnpHashSecret);

            vnpayData.Success = checkSignature && vnpayData.VnPayResponseCode == "00";

            return vnpayData;
        }

        private string HmacSHA512(string key, string inputData)
        {
            var hash = new StringBuilder();
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] inputBytes = Encoding.UTF8.GetBytes(inputData);
            using (var hmac = new HMACSHA512(keyBytes))
            {
                byte[] hashValue = hmac.ComputeHash(inputBytes);
                foreach (var theByte in hashValue)
                {
                    hash.Append(theByte.ToString("x2"));
                }
            }

            return hash.ToString();
        }

        private bool ValidateSignature(string inputHash, string secretKey)
        {
            var rspRaw = GetResponseData();
            string myChecksum = HmacSHA512(secretKey, rspRaw);
            return myChecksum.Equals(inputHash, StringComparison.InvariantCultureIgnoreCase);
        }

        private string GetResponseData()
        {
            var data = new StringBuilder();
            if (_responseData.Count > 0)
            {
                foreach (KeyValuePair<string, string> kv in _responseData)
                {
                    if (!string.IsNullOrEmpty(kv.Value) && kv.Key != "vnp_SecureHashType" && kv.Key != "vnp_SecureHash")
                    {
                        data.Append(WebUtility.UrlEncode(kv.Key) + "=" + WebUtility.UrlEncode(kv.Value) + "&");
                    }
                }

                if (data.Length > 0)
                {
                    data.Remove(data.Length - 1, 1);
                }
            }

            return data.ToString();
        }
    }

    public class VnPayCompare : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (x == y) return 0;
            if (x == null) return -1;
            if (y == null) return 1;
            var vnpCompare = CompareInfo.GetCompareInfo("en-US");
            return vnpCompare.Compare(x, y, CompareOptions.Ordinal);
        }
    }
}
