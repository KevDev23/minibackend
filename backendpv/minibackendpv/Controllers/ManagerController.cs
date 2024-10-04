using backendpv.Dtos;
using backendpv.Interfaces;
using backendpv.Models;
using backendpv.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace backendpv.Controllers
{
    public class ManagerController : Controller //controller base
    {
        //private readonly IResRepository _resRepository;
        private readonly UserManager<Manager> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<Manager> _signInManager;

            public ManagerController(UserManager<Manager> userManager, ITokenService tokenService, SignInManager<Manager> signInManager)
            {
                _userManager = userManager; 
                _tokenService = tokenService;
                _signInManager = signInManager;
            }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == loginDto.Email);

            if (user == null)
                return Unauthorized("Invalid Email"); 
    
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password ,false);
           
           
            if (!result.Succeeded)
                return Unauthorized("Email or Password not found/incorrect");

            return Ok(
                new NewUserDto
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    Token = _tokenService.CreateToken(user)
                }); 
        }

        //the rest is auto generated

        // GET: ManagerController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ManagerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ManagerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManagerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ManagerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ManagerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ManagerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ManagerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        /*public class AccountController: ControllerBase
        {
            private readonly UserManager
            
            public AccountControllerController(UserManager<Manager> userManager)
            {

            }

        }*/
    }
}
