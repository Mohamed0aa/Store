﻿using AutoMapper;
using Domain.Contract;
using Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManager(IUnitOfWork unitOfWork,IMapper mapper) : IServiceManager
    {
        public IProductService ProductService { get; }=new ProductService(unitOfWork,mapper);
    }
}
