using MyAspNetApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using MyAspNetApp.Domain;
using Microsoft.AspNetCore.Authorization;
using MyAspNetApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace MyAspNetApp.Controllers.Admin
{
   public partial class AdminController
   {
        public async Task<IActionResult>ServiceCategoriesEdit(int id)
        {
            //If ID we add or edit service category
            ServiceCategory? entity = id == default 
            ? new ServiceCategory()
            : await _dataManager.ServiceCategories.GetServiceCategoryByIdAsync(id);
            return View(entity);
        }
        [HttpPost]
        public async Task<IActionResult> ServiceCategoriesEdit(ServiceCategory entity)
        {
            //If errors
            if (!ModelState.IsValid)
            {
                return View(entity);
            }
            //add or edit service category
            await _dataManager.ServiceCategories.SaveServiceCategoryAsync(entity);
            _logger.LogInformation($"Service category saved {entity.Id} ");
            return RedirectToAction("Index");
        }
          [HttpPost]
          public async Task<IActionResult> ServiceCategoriesDelete(int id)
          {
              
              await _dataManager.ServiceCategories.DeleteServiceCategoryAsync(id);
              _logger.LogInformation($"Service category delited {id} ");
              return RedirectToAction("Index");
          }

   }
}