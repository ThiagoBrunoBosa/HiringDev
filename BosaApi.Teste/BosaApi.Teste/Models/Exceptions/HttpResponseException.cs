using System;

namespace BosaApi.Teste.Models
{
    public class HttpResponseException : Exception
    {
        public int Status { get; set; } = 500;

        public object Value { get; set; }

        public HttpResponseException()
            : base(null) { }

        public HttpResponseException(string message)
            : base(message) { }

        public HttpResponseException
            (string message, Exception innerException)
            : base(message, innerException) { }
    }
}
