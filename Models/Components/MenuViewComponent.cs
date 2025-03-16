using Microsoft.AspNetCore.Mvc;
using MyAspNetApp.Domain;
using MyAspNetApp.Domain.Entities;
using MyAspNetApp.Infrastructure;
namespace MyAspNetApp.Models.Components
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly DataManager _dataManager;
        public MenuViewComponent(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public async Task<IViewComponentResult>InvokeAsync()
        {
            IEnumerable<Service> list = await _dataManager.Services.GetServicesAsync();

            IEnumerable<ServiceDTO> listDTO = HelperDTO.TransformService(list);
            
            return await Task.FromResult((IViewComponentResult)View("Default",listDTO));
        }
    }
}