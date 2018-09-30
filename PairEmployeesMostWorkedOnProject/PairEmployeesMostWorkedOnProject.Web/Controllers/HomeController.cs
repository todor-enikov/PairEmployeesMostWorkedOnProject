using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PairEmployeesMostWorkedOnProject.Core;
using PairEmployeesMostWorkedOnProject.Web.Models;

namespace PairEmployeesMostWorkedOnProject.Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file != null)
            {
                var resourceFolderPath = Path.GetFullPath("Resources\\");
                if (file.Length > 0)
                {
                    using (var stream = new FileStream(resourceFolderPath + file.FileName, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
                else
                {
                    return RedirectToAction(nameof(Error));
                }

                var filePath = resourceFolderPath + file.FileName;

                var manager = new EmployeeManager(filePath);
                var result = manager.CalculateMostWorkedEmployeesInProject();

                return View(result);
            }
            else
            {
                return RedirectToAction(nameof(Error));
            }
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
