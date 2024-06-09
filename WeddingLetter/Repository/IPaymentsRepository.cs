using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeddingLetter.Models;

namespace WeddingLetter.Repository
{
    public interface IPaymentsRepository
    {
        Task<List<PaymentsModel>> GetAllPaymentsAsync();
        Task<PaymentsModel> GetPaymentByIdAsync(int paymentID);
        Task<int> AddPaymentsAsync(PaymentsModel paymentsModel);
        Task UpdatePaymentsAsync(int paymentId, PaymentsModel paymentsModel);
        Task UpdatePaymentsAsyncByPartial(int paymentId, JsonPatchDocument paymentModel);
        Task<bool> DeletePaymentByIdAsync(int paymentId);
    }
}
