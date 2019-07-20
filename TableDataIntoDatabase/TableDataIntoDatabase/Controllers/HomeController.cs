using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TableDataIntoDatabase.Data;
using TableDataIntoDatabase.Models;

namespace TableDataIntoDatabase.Controllers
{
    public class HomeController : Controller
    {
        public readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InsertStudents([FromBody]StudentViewModel studentVM)
        {
            List<StudentInfo> model = studentVM.StudentInfos;
            _context.AddRange(model);
            int insertedRecords = await _context.SaveChangesAsync();
            return Json(insertedRecords);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
