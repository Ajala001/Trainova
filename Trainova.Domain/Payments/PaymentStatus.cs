using System;
using System.Collections.Generic;
using System.Text;

namespace Trainova.Domain.Payments
{
    public enum PaymentStatus
    {
        Paid = 1,
        Pending,
        Failed,
        Refunded
    }
}
