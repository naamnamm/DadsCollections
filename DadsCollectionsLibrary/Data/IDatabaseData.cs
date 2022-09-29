using DadsCollectionsLibrary.Models;

namespace DadsCollectionsLibrary.Data
{
    public interface IDatabaseData
    {
        int CreateOrder(string firstName, string lastName, string email, decimal totalCost, List<int> orderProductIdList);
        int CreateProducts(ProductModel Product);
        List<ProductModel> GetAllProducts();
        List<ProductModel> GetAvailableProducts();
        List<OrderFullModel> SearchOrders(string email);
        int UpdateOrderStatus(int orderId, string status);
        int UpdateProductDetail(ProductModel Product);
    }
}