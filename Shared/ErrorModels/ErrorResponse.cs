

using System.Globalization;

namespace Shared.ErrorModels
{
    public class ErrorResponse
    {
        public string ErrorMessage {  get; set; }   

        public int StatusCode { get; set; }
    }
}
