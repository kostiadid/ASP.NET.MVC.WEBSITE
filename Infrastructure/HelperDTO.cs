using MyAspNetApp.Domain.Entities;
using MyAspNetApp.Models;
using System.Collections.Generic;


namespace MyAspNetApp.Infrastructure
{
    public static class HelperDTO
    {
        //Service - ServiceDTO
        public static ServiceDTO TransformService(Service entity)
        {
            ServiceDTO entityDTO = new ServiceDTO();
            entityDTO.Id = entity.Id;
            entityDTO.CategoryName = entity.ServiceCategory?.Title;
            entityDTO.Title = entity.Title;
            entityDTO.DescriptionShort = entity.DescriptionShort;
            entityDTO.Description = entity.Description;
            entityDTO.PhotoFileName = entity.Photo;
            entityDTO.Type = entity.Type.ToString();

            return entityDTO;
        }

        public static IEnumerable<ServiceDTO> TransformService(IEnumerable<Service> entities)
        {
            List<ServiceDTO> entitiesDTO = new List<ServiceDTO>();
            foreach (var entity in entities)
            {
                entitiesDTO.Add(TransformService(entity));
            }

            return entitiesDTO;
        }
    }
}