using BarHand.API.SalesOrders.Domain.Models;
using BarHand.API.SalesOrders.Domain.Repositories;
using BarHand.API.SalesOrders.Services.Communication;
using BarHand.API.Shared.Domain.Repositories;
using BarHand.API.Stores.Domain.Repositories;

namespace BarHand.API.SalesOrders.Services;

public class OrderService:IOrderService
{
    
    private readonly IOrderRepository _orderRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IStoreRepository _storeRepository;
    
    public OrderService(IOrderRepository orderRepository, IUnitOfWork unitOfWork, IStoreRepository storeRepository)
    {
        _orderRepository = orderRepository;
        _unitOfWork = unitOfWork;
        _storeRepository = storeRepository;
    }
    public async Task<IEnumerable<Order>> ListAsync()
    {
        return await _orderRepository.ListAsync();
    }

    public async Task<IEnumerable<Order>> ListByStoreIdAsync(long storeId)
    {
        return await _orderRepository.FindByStoreIdAsync(storeId);
    }

    public async Task<OrderResponse> GetByIdAsync(long id)
    {
        var existingProduct = await _orderRepository.FindByIdAsync(id);

        if (existingProduct == null)
            return new OrderResponse("Product not found.");

        return new OrderResponse(existingProduct);
    }

    public async Task<OrderResponse> SaveAsync(Order order)
    {
        
        var existingStore = await _storeRepository.FindByIdAsync(order.StoreId);
        if (existingStore == null)
            return new OrderResponse("Invalid Supplier");
        

        //Perform Adding
        try
        {
            //add Order
            await _orderRepository.AddAsync(order);
            
            //Complete transaction 
            await _unitOfWork.CompleteAsync();
            
            //Return Response
            return new OrderResponse(order);

        }
        catch (Exception e)
        {
            //Error handling
            return new OrderResponse($"An error  occurred saving the Order: {e.Message}");
        }
    }

    public async Task<OrderResponse> UpdateAsync(long id, Order order)
    {
        var existingOrder=await _orderRepository.FindByIdAsync(id);
        
        if (existingOrder == null)
            return new OrderResponse("Order not found");

        //validate existence of assigned supplier
        var existingStore = await _storeRepository.FindByIdAsync(order.StoreId);
        if (existingStore == null)
            return new OrderResponse("Invalid Store");
        
       
        
        //Modify field
        existingOrder.orderDetails = order.orderDetails;
        

        //perform update
        try
        {
            _orderRepository.Update(existingOrder);
            await _unitOfWork.CompleteAsync();

            return new OrderResponse(existingOrder);
        }
        catch (Exception e)
        {
            //Error handling
            return new OrderResponse($"An error  occurred while updating the Order: {e.Message}");
        }
    }

    public async Task<OrderResponse> DeleteAsync(long id)
    {
        //Validate Products existence
        var existingOrder=await _orderRepository.FindByIdAsync(id);
        if (existingOrder == null)
            return new OrderResponse("Order not found");
        //Perform delete

        try
        {
            _orderRepository.Remove(existingOrder);
            await _unitOfWork.CompleteAsync();

            return new OrderResponse(existingOrder);
        }
        catch (Exception e)
        {
            //Error Handling
            return new OrderResponse($"An error occurred while deleting the order:{e.Message}");
        }
    }
}