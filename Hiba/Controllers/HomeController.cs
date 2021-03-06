using Hiba.Data;
using Hiba.Models;
using MailKit.Security;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;
//using MimeKit;
//using MimeKit.Text;
using MailKit.Security;
using MailKit.Net.Smtp;
using MailKit.Net.Pop3;

namespace Hiba.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStringLocalizer<HomeController> _localizer;
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public HomeController(ILogger<HomeController> logger, IStringLocalizer<HomeController> localizer, ApplicationDbContext context, IWebHostEnvironment env)
        {
            _logger = logger;
            _localizer = localizer;
            _context = context;
            _env = env;
        }

        public IActionResult ChangeLanguage(string lang)
        {
            Response.Cookies.Append(
                 CookieRequestCultureProvider.DefaultCookieName,
                 CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(lang)),
                 new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) });
            return Redirect(Request.Headers["Referer"].ToString());
        }
        public IActionResult Index()
        {

            CultureInfo uiCultureInfo = Thread.CurrentThread.CurrentUICulture;
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            ViewBag.lang = cultureInfo.ToString();

            //Response.Cookies.Append(
            //      CookieRequestCultureProvider.DefaultCookieName,
            //      CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(lang)),
            //      new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) });
            //return LocalRedirect("~/");



            //if (lang != "" && lang != null)
            //{
            //    ViewBag.lang = lang;
            //    Response.Cookies.Append(
            //     CookieRequestCultureProvider.DefaultCookieName,
            //     CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(lang)),
            //     new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) });
            //    return LocalRedirect("~/");
            //    //return View();
            //}

            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

       

        public IActionResult CMS()
        {
            return View();
        }

        public IActionResult About()
        {

            CultureInfo uiCultureInfo = Thread.CurrentThread.CurrentUICulture;
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            ViewBag.lang = cultureInfo.ToString();
            var data = _context.Pages.Where(p => p.Name == "About" && p.Lang == cultureInfo.ToString()).FirstOrDefault();
            return View(data);
        }
        public IActionResult AboutCenter()
        {
            CultureInfo uiCultureInfo = Thread.CurrentThread.CurrentUICulture;
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            ViewBag.lang = cultureInfo.ToString();
            var data = _context.Pages.Where(p => p.Name == "AboutCenter" && p.Lang== cultureInfo.ToString()).FirstOrDefault();
            return View(data);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult OurVision()
        {
            CultureInfo uiCultureInfo = Thread.CurrentThread.CurrentUICulture;
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            ViewBag.lang = cultureInfo.ToString();
            var data = _context.Pages.Where(p => p.Name == "Vision" && p.Lang == cultureInfo.ToString()).FirstOrDefault();
            return View(data);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public void Email(string myemail)
        {

            string contentRootPath = _env.ContentRootPath;
            string webRootPath = _env.WebRootPath;
            try
            {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse("hamzasukkarforprogramming@gmail.com"));
                email.To.Add(MailboxAddress.Parse("hamzasukkar@gmail.com"));
                email.Subject = "Admin Support Replay for:";
                email.Body = new TextPart(TextFormat.Html) { Text = "ddgdg" };
                // send email
                using var smtp = new MailKit.Net.Smtp.SmtpClient();
                smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                smtp.Authenticate("hamzasukkarforprogramming@gmail.com", "Ac123456");
                smtp.Send(email);
                smtp.Disconnect(true);

            }
            catch (Exception ex)
            {


                //if (!System.IO.File.Exists(webRootPath + "/log.txt"))
                //{
                //    System.IO.File.Create(webRootPath + "/log.txt");
                //}


                //using (StreamWriter outputFile = new StreamWriter(Path.Combine(webRootPath + "/log.txt")))
                //{

                //    outputFile.WriteLine(ex.Message);
                //}



            }

        }
    }
}
