﻿namespace WS
{
    public class Response<T>
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public T Value { get; set; }
    }
}
