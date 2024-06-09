using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeddingLetter.Data;
using WeddingLetter.Models;

namespace WeddingLetter.Repository
{
    public class PaymentsRepository : IPaymentsRepository
    {
        private readonly WeddingLetterContext _context;
        private readonly IMapper _mapper;

        public PaymentsRepository(WeddingLetterContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //Get All - API
        public async Task<List<PaymentsModel>> GetAllPaymentsAsync()
        {
            var payments = await _context.Payments.ToListAsync();
            return _mapper.Map<List<PaymentsModel>>(payments);
        }


        //Get By ID - API
        public async Task<PaymentsModel> GetPaymentByIdAsync(int paymentID)
        {
            var payment = await _context.Payments.FindAsync(paymentID);
            return _mapper.Map<PaymentsModel>(payment);
        }


        //Add Payment - API
        public async Task<int> AddPaymentsAsync(PaymentsModel paymentsModel)
        {
            var payment = _mapper.Map<Payments>(paymentsModel);
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
            return payment.Id;
        }


        //Update API
        public async Task UpdatePaymentsAsync(int paymentId, PaymentsModel paymentsModel)
        {
            var payment = _mapper.Map<PaymentsModel, Payments>(paymentsModel);
            payment.Id = paymentId;
            _context.Payments.Update(payment);
            await _context.SaveChangesAsync();
        }


        //Update Payment API Using Patch
        public async Task UpdatePaymentsAsyncByPartial(int paymentId, JsonPatchDocument paymentModel)
        {
            var payment = await _context.Payments.FindAsync(paymentId);
            if(payment != null)
            {
                paymentModel.ApplyTo(payment);
                await _context.SaveChangesAsync();
            }
        }


        //Delete Payment API
        public async Task<bool> DeletePaymentByIdAsync(int paymentId)
        {
            var payment = await _context.Payments.FindAsync(paymentId);
            if(payment == null)
            {
                return false;
            }
            _context.Payments.Remove(payment);
            await _context.SaveChangesAsync();
            return true;
        }


    }
}


