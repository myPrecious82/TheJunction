using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheJunction.Data;
using TheJunction.Models;
using TheJunction.Services;
using TheJunction.ViewModels;

namespace TheJunction.Controllers.Web
{
    public class AppController : Controller
    {
        private IMailService _mailService;
        private IConfigurationRoot _config;
        private MyContext _context;

        public AppController(IMailService mailService, IConfigurationRoot config, MyContext context)
        {
            _mailService = mailService;
            _config = config;
            _context = context;
        }

        public IActionResult Index()
        {
            var data = _context.Shifts.ToList();

            return View(data);
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {
            if (model.Email.Contains("aol.com")) ModelState.AddModelError("Email", "We don't support AOL addresses");

            if (ModelState.IsValid)
            {
                _mailService.SendMail(_config["MailSettings:ToAddress"], model.Email, "from the junction", model.Message);

                ModelState.Clear();
                ViewBag.UserMessage = "Message Sent";

            }

            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
