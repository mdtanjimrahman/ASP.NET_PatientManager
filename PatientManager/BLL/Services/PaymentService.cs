using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class PaymentService
    {
        DataAccessFactory factory;

        public PaymentService(DataAccessFactory factory)
        {
            this.factory = factory;
        }

        public bool MakePayment(int appointmentId, double amount)
        {
            return factory.PaymentFeature().MakePayment(appointmentId, amount);
        }
    }
}
