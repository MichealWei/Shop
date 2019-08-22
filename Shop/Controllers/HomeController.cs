using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Models;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        private UserManager<Customer> userManager;
        private SignInManager<Customer> signInManager;
        private IProductRepository repository;
        public int PageSize = 4;
        public HomeController(IProductRepository repo, UserManager<Customer> userMgr, SignInManager<Customer> signInMgr)
        {
            repository = repo;
            userManager = userMgr;
            signInManager = signInMgr;
        }

        public ViewResult Index(int productPage = 1)
        => View(repository.Products.OrderBy(p => p.ID).Skip((productPage - 1) * PageSize).Take(PageSize));


        [AllowAnonymous]
        public ViewResult Login(string returnUrl)
        {
            return View(new LoginModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                Customer user = await userManager.FindByNameAsync(loginModel.Name);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    if ((await signInManager.PasswordSignInAsync(user, loginModel.Password, false, false)).Succeeded)
                    {
                        return Redirect(loginModel?.ReturnUrl ?? "/Admin/Index");
                    }
                }
            }

            ModelState.AddModelError("", "Invalid name or password");
            return View(loginModel);
        }

        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }

        public ViewResult CreateUser() => View();

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateModel model)
        {
            if (ModelState.IsValid)
            {
                Customer user = new Customer
                {
                    Name = model.Name,
                    SurName = model.SurName,
                    Address = model.Address,
                    Email = model.Email,
                    PhoneNumber = model.Telefone,
                    UserName = model.Name,
                    Password = model.Password
                };
                IdentityResult result
                    = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return View(model);
        }
    }
}
