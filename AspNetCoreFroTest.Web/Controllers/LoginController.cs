using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreFroTest.Web.Bll;
using AspNetCoreFroTest.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreFroTest.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginBiz _biz;

        public LoginController(ILoginBiz biz)
        {
            _biz = biz;
        }

        // GET: Login
        public IActionResult Index()
        {
            return View();
        }

        //Lab
        [HttpPost]
        public IActionResult Index([FromForm]Customer cust)
        {
            if (_biz.Login(cust.Name, cust.PW))
            {
                return RedirectToAction("Success");
            }

            return RedirectToAction("Fail");
        }

        public ActionResult Success()
        {
            return View();
        }

        public ActionResult Fail()
        {
            return View();
        }
    }
}