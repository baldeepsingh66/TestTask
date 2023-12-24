using TestTask.DataModel.ResponseDTO;
using TestTask.DataModel;

namespace TestTask.IService
{
    public interface ISupplierService
    {
        TTResponseModel<List<SupplierDTO>> GetHotelFromSuplier();
        bool SaveSuppliers(List<SupplierDTO> supplierDTOs);
        bool CreateSupplier(SupplierDTO suppliercDTO);
    }
}
