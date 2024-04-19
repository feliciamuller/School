using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using School.Data;
using School.Models;

namespace School.Controllers
{
    public class StudentsController : Controller
    {
        private readonly SchoolDbContext _context;

        public StudentsController(SchoolDbContext context)
        {
            _context = context;
        }
        //Get students
        public async Task<IActionResult> Index()
        {
            var studentsList = _context.Students.Include(s => s.StudentClass).OrderBy(s => s.StudentClass);
            return View(await studentsList.ToListAsync());
        }
    }
}
