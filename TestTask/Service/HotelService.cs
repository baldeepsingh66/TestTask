using System;
using Newtonsoft.Json;
using System.IO;
using TestTask.IService;
using TestTask.DataModel.ResponseDTO;

namespace TestTask.Service
{
    public class HotelService : IHotelService
    {
        public async Task<TTResponseModel<List<HotelSuplierResponse>>> GetHotelFromSuplier()
        {
            try
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Suplier.json");
                string jsonData=string.Empty;
                if (File.Exists(filePath))
                {
                    jsonData = File.ReadAllText(filePath);
                }
                else
                {
                    return new TTResponseModel<List<HotelSuplierResponse>>() { IsSuccess = false, Data = null, Message = "File not found" };
                }
                var result= JsonConvert.DeserializeObject<List<HotelSuplierResponse>>(jsonData);
                return new TTResponseModel<List<HotelSuplierResponse>>() { IsSuccess = true, Data = result, Message="Success" };
            }
            catch(Exception ex)
            {
                return new TTResponseModel<List<HotelSuplierResponse>>() { IsSuccess = false, Data = null, Message = ex.Message };
            }
        }
    }
}
