using BarHand.API.Inventory.Domain.Repositories;
using BarHand.API.SalesOrders.Domain.Models;
using BarHand.API.SalesOrders.Domain.Repositories;
using BarHand.API.SalesOrders.Services.Communication;
using BarHand.API.Shared.Domain.Repositories;
using BarHand.API.Suppliers.Domain.Repositories;

namespace BarHand.API.SalesOrders.Services;

public class OrderDetailService:IOrderDetailService
{
    private readonly IOrderDetailRepository _orderDetailRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IProductRepository _productRepository;
    private readonly IOrderRepository _orderRepository;
    
    public OrderDetailService(IOrderDetailRepository orderDetailRepository, IUnitOfWork unitOfWork, IProductRepository productRepository,IOrderRepository orderRepository)
    {
        _orderDetailRepository = orderDetailRepository;
        _unitOfWork = unitOfWork;
        _productRepository = productRepository;
        _orderRepository = orderRepository;
    }
    
    public async Task<IEnumerable<OrderDetail>> ListAsync()
    {
        return await _orderDetailRepository.ListAsync();
    }

    public async Task<IEnumerable<OrderDetail>> ListByOrderIdAsync(long orderId)
    {
        return await _orderDetailRepository.FindByOrderIdAsync(orderId);
    }

    public async Task<OrderDetailResponse> GetByIdAsync(long id)
    {
        var existingOrderDetail = await _orderDetailRepository.FindByIdAsync(id);

        if (existingOrderDetail == null)
            return new OrderDetailResponse("Orden detail not found.");

        return new OrderDetailResponse(existingOrderDetail);
    }

    public async Task<OrderDetailResponse> SaveAsync(OrderDetail orderDetail)
    {
        //validate existence of assigned Order
        var existingOrder = await _orderRepository.FindByIdAsync(orderDetail.OrderId);
        if (existingOrder == null)
            return new OrderDetailResponse("Invalid Order");
        //validate existence of assigned Order
        var existingProduct = await _productRepository.FindByIdAsync(orderDetail.ProductId);
        if (existingProduct == null)
            return new OrderDetailResponse("Invalid Product");

        //Perform Adding
        try
        {
            orderDetail.QuotedPrice = orderDetail.Quantity*orderDetail.Product.Price;
            //add Order detail
            await _orderDetailRepository.AddAsync(orderDetail);
            
            //Complete transaction 
            await _unitOfWork.CompleteAsync();
            
            //Return Response
            return new OrderDetailResponse(orderDetail);

        }
        catch (Exception e)
        {
            //Error handling
            return new OrderDetailResponse($"An error  occurred saving the order detail: {e.Message}");
        }
    }

    public async Task<OrderDetailResponse> UpdateAsync(long id, OrderDetail orderDetail)
    {
        //validate if product exists
        var existingOrderDetail=await _orderDetailRepository.FindByIdAsync(id);
        
        if (existingOrderDetail == null)
            return new OrderDetailResponse("OrderDetail not found");
        //validate existence of assigned Order
        var existingOrder = await _orderRepository.FindByIdAsync(orderDetail.OrderId);
        if (existingOrder == null)
            return new OrderDetailResponse("Invalid Order");
        //validate existence of assigned Order
        var existingProduct = await _productRepository.FindByIdAsync(orderDetail.ProductId);
        if (existingProduct == null)
            return new OrderDetailResponse("Invalid Product");
 
        
        //Modify field
        existingOrderDetail.Quantity = orderDetail.Quantity;
        int totalPrice = orderDetail.Product.Price * orderDetail.Quantity;
        existingOrderDetail.QuotedPrice = totalPrice;
        
        //perform update
        try
        {
            _orderDetailRepository.Update(existingOrderDetail);
            await _unitOfWork.CompleteAsync();

            return new OrderDetailResponse(existingOrderDetail);
        }
        catch (Exception e)
        {
            //Error handling
            return new OrderDetailResponse($"An error  occurred while updating the order detail: {e.Message}");
        }
    }

    public async Task<OrderDetailResponse> DeleteAsync(long id)
    {
        //Validate Order Detail existence
        var existingOrderDetail=await _orderDetailRepository.FindByIdAsync(id);
        if (existingOrderDetail == null)
            return new OrderDetailResponse("OrderDetail not found");
        //Perform delete

        try
        {
            _orderDetailRepository.Remove(existingOrderDetail);
            await _unitOfWork.CompleteAsync();

            return new OrderDetailResponse(existingOrderDetail);
        }
        catch (Exception e)
        {
            //Error Handling
            return new OrderDetailResponse($"An error occurred while deleting the order detail:{e.Message}");
        }
    }
}