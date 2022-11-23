using BarHand.API.Inventory.Domain.Models;
using BarHand.API.Inventory.Domain.Services.Communication;
using BarHand.API.Notifications.Domain.Models;
using BarHand.API.Notifications.Domain.Repositories;
using BarHand.API.Notifications.Domain.Services;
using BarHand.API.Notifications.Domain.Services.Communication;
using BarHand.API.Shared.Domain.Repositories;
using BarHand.API.Stores.Domain.Repositories;
using BarHand.API.Suppliers.Domain.Repositories;
using BarHand.API.Suppliers.Persistence.Repositories;

namespace BarHand.API.Notifications.Services;

    public class NotificationService:INotificationService
    {
    private readonly INotificationRepository _notificationRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISupplierRepository _supplierRepository;
    private readonly IStoreRepository _storeRepository;

    public NotificationService(INotificationRepository notificationRepository, IUnitOfWork unitOfWork, ISupplierRepository supplierRepository, IStoreRepository storeRepository)
    {
        _notificationRepository = notificationRepository;
        _supplierRepository = supplierRepository;
        _storeRepository = storeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Notification>> ListAsync()
    {
        return await _notificationRepository.ListAsync();
    }

    public async Task<NotificationResponse> GetByIdAsync(long id)
    {
        var existingNotification = await _notificationRepository.FindByIdAsync(id);
        if (existingNotification == null)
            return new NotificationResponse("Notification not found");

        return new NotificationResponse(existingNotification);
    }

    public async Task<IEnumerable<Notification>> ListByTypeIdAsync(long id, string type)
    {
        return await _notificationRepository.FindByTypeIdAsync(id,type);
    }


    public async Task<NotificationResponse> SaveAsync(Notification notification)
    {

        //validate existence of assigned Supplier
       // var existingSupplier =  _supplierRepository.FindByIdAsync(notification.SupplierId);
      //  if (existingSupplier == null)
      //  {
         //   notification.Supplier = null;
       //     notification.SupplierId = 0;
       // }
        //  return new NotificationResponse("Invalid Supplier");

       // var existingStore =  _storeRepository.FindByIdAsync(notification.StoreId);
       // if (existingStore == null)
       // {
       //     notification.Supplier = null;
        //    notification.SupplierId = 0;
        //}
          //  return new NotificationResponse("Invalid Store");


        try
        {
            await _notificationRepository.AddAsync(notification);
            await _unitOfWork.CompleteAsync();
            return new NotificationResponse(notification);

        }
        catch (Exception e)
        {
            return new NotificationResponse($"An error occurred while saving the notification: {e.Message}");
        }
    }

    public async Task<NotificationResponse> UpdateAsync(long notificationId, Notification supplier)
    {
        var existingNotification = await _notificationRepository.FindByIdAsync(notificationId);
        if (existingNotification == null)
        {
            return new NotificationResponse("Mechanic not found ");
        }

        try
        {
            _notificationRepository.Update(existingNotification);
            await _unitOfWork.CompleteAsync();

            return new NotificationResponse(existingNotification);
        }
        catch (Exception e)
        {
            return new NotificationResponse($"An error occurred while updating the notification: {e.Message}");
        }
    }

    public async Task<NotificationResponse> DeleteAsync(long id)
    {
        var existingNotification = await _notificationRepository.FindByIdAsync(id);

        if (existingNotification == null)
            return new NotificationResponse("Mechanic not found.");

        try
        {
            _notificationRepository.Remove(existingNotification);
            await _unitOfWork.CompleteAsync();

            return new NotificationResponse(existingNotification);
        }
        catch (Exception e)
        {
            return new NotificationResponse($"An error occurred while deleting the notification: {e.Message}");
        }
    }
}

