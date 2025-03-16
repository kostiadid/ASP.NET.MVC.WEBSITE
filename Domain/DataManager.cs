using System;
using System.Data;
using MyAspNetApp.Domain.Repositories.Abstract;

namespace MyAspNetApp.Domain
{
    public class DataManager
    {
        public IServiceCategoriesRepository ServiceCategories{ get;set; }
        public IServicesRepository Services{ get;set; }

        public DataManager(IServiceCategoriesRepository serviceCategoriesRepository, IServicesRepository servicesRepository)
        {
          ServiceCategories = serviceCategoriesRepository;
          Services = servicesRepository;  
        }
    }
}

