using Microsoft.AspNetCore.Mvc;
using MyAspNetApp.Infrastructure;
using MyAspNetApp.Domain;
using MyAspNetApp.Domain.Entities;
using MyAspNetApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyAspNetApp.Controllers
{
    public class ServicesController:Controller
    {
        private readonly DataManager _dataManager;
        public ServicesController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Service> list = await _dataManager.Services.GetServicesAsync();
            IEnumerable<ServiceDTO> listDTO = HelperDTO.TransformService(list);
            return View(listDTO);
        }

        public async Task<IActionResult> Show(int id)
        {
            Service? entity = await _dataManager.Services.GetServiceByIdAsync(id);
            //if error
            if(entity is null)
            return NotFound();
            ServiceDTO entityDTO = HelperDTO.TransformService(entity);
            return View(entityDTO);
        }


    }
}