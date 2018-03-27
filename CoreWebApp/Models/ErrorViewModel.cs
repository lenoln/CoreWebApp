using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;

namespace CoreWebApp.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        public string Message { get; set; }
        public HttpStatusCode Code { get; set; }
        public ModelStateDictionary ModelState { get; set; }
    }
}