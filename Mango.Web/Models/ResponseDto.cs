﻿namespace Mango.Web.Models
{
    public class ResponseDto
    {
        public object? Result { get; set; }
        public Boolean isSuccess { get; set; } = true;

        public string Message { get; set; }="";
    }
}