using System;
using System.ComponentModel.DataAnnotations;
using MyAspNetApp.Domain.Enums;

namespace MyAspNetApp.Domain.Entities
{
    public class Service : EntityBase
    {
       [Display(Name="Service Type")]
       public int? ServiceCategoryId { get; set; }
       public ServiceCategory? ServiceCategory{get;set;}

       [Display(Name="Description")]
       [MaxLength(500)]
       public string ? DescriptionShort{get;set;}

       [Display(Name ="Full Description")]
       [MaxLength(1000)]
       public string ? Description{get;set;}

       [Display(Name ="Picture")]
       [MaxLength(300)]
       public string? Photo{get;set;}

       [Display(Name ="Type of service")]
       public ServiceTypeEnum Type{get;set;}
    }
}