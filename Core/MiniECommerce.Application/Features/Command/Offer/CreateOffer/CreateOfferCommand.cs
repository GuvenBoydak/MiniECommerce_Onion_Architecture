﻿using MediatR;

namespace MiniECommerce.Application
{
    public class CreateOfferCommand:IRequest
    {
        public decimal Price { get; set; }

        public bool IsApproved { get; set; }

        public Guid AppUserID { get; set; }

        public Guid ProductID { get; set; }
    }
}
