﻿using MediatR;

namespace MiniECommerce.Application
{
    public class CreateRoleCommand:IRequest
    {
        public Guid ID { get; set; }

        public string Name { get; set; }
    }
}
