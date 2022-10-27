﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniECommerce.Application
{
    public class CreateBrandCommand:IRequest
    {
        public string Name { get; set; }
    }
}
