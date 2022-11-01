using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//This wrapper class is for additional user help, can be called to let user know if result was a success or failure.

namespace BookClub_app.Models
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }

        public bool Success { get; set; } = true;

        public string Message { get; set; } = string.Empty;
    }
}