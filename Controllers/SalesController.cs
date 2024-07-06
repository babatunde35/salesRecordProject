
using SalesRecord.Context;
using SalesRecord.Data;
using SalesRecord.Models.Sales;
using SalesRecord.Utility;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

[Authorize]

namespace SalesRecord.Controllers;

public class SalesController(UserManager<IdentityUser> userManager,
    SignInManager<IdentityUser> signInManager,
    INotyfService notyf,
    SalesContext arsContext,
    IHttpContextAccessor httpContextAccessor) : Controller

   private readonly UserManager<IdentityUser> _userManager = userManager;
   private readonly SignInManager<IdentityUser> _signInManager = signInManager;
   private readonly INotyfService _notyfService = notyf;
   private readonly SalesContext _salesContext = salesContext;
   private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult SalesRegistration()
    {
        var states = _salesContext.States.Select(x => new SelectListItem
        {
            Text = x.Name,
            Value = x.Id.ToString()
        }).ToList();

        var viewModel = new SalesDetailViewModel
        {
            States = states
        };

        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> SalesRegistration(SalesDetailViewModel model)
    {
        var salesExist = await _salesContext.SalesDetails.AnyAsync(x => x.Name == model.Name || x.Email == model.Email);
        var userDetail = await Helper.GetCurrentUserIdAsync(_httpContextAccessor, _userManager);

        if (teamExist)
        {
            _notyfService.Warning("already exist");
            return View(model);
        }

        var team = new SalesalesDetail    
        {
            UserId = userDetail.userId,   
            Name = model.Name,   
            Email = model.Email,
            SchoolName = model.SchoolName,
            PhoneNumber = model.PhoneNumber,
            StateId = model.StateId
        };

        await _salesContext.AddAsync(Sale);
        var result = await _salesContext.SaveChangesAsync();

        if (result > 0)
        {
            _notyfService.Success("detail registered successfully");
            return RedirectToAction("Index", "home");
        }

        _notyfService.Error("An error occured while creating  team detail");
        return View();

    }




