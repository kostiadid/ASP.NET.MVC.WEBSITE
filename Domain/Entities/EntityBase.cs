using System;
using System.ComponentModel.DataAnnotations;


namespace MyAspNetApp.Domain.Entities
{
    public abstract class EntityBase
    {
       public int Id{get;set;}
       [Required(ErrorMessage ="Need a Title field")]
       [Display(Name="Title")]
       [MaxLength(200)]
       public string? Title{get;set;}


       public DateTime DateCreated{get;set;} = DateTime.UtcNow;

    }
}