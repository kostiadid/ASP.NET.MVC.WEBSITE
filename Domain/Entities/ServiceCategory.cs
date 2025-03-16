using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAspNetApp.Domain.Entities
{
    public class ServiceCategory : EntityBase
    {
       public ICollection<Service>? Services{get;set;}  

    }

}