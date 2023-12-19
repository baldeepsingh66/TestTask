﻿namespace TestTask.DataModel.ResponseDTO
{
    public class TTResponseModel<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
