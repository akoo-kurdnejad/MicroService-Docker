﻿using Ordering.Domain.Aggregates.OrderAggregate.Enums;
using Ordering.Domain.Common;

namespace Ordering.Domain.Aggregates.OrderAggregate
{
    public class Order : BaseEntity
    {
        public string UserName { get; set; }
        public decimal TotalPrice { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public string BankName { get; set; }
        public string RefCode { get; set; }
        public PaymentMethodTypeEnum PaymentMethod { get; set; }
    }
}
