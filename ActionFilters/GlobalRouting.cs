﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PawentsOneStopShop.ActionFilters
{
    public class GlobalRouting : IActionFilter
    {
        private readonly ClaimsPrincipal _claimsPrincipal;
        public GlobalRouting(ClaimsPrincipal claimsPrincipal)
        {
            _claimsPrincipal = claimsPrincipal;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = context.RouteData.Values["controller"];
            if (controller.Equals("Home"))
            {
                if (_claimsPrincipal.IsInRole("Pet Owner"))
                {
                    context.Result = new RedirectToActionResult("Index",
                    "PetOwners", null);
                }
                else if (_claimsPrincipal.IsInRole("Pet Business"))
                {
                    context.Result = new RedirectToActionResult("Index",
                    "PetBusinesss", null);
                }
            }
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

    }
}
