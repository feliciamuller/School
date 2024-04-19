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
    public class CoursesController : Controller
    {
        private readonly SchoolDbContext _context;

        public CoursesController(SchoolDbContext context)
        {
            _context = context;
        }

        //Get all courses
        public async Task<IActionResult> Index()
        {
            return View(await _context.Courses.ToListAsync());
        }
        //GET: update CourseName
        public async Task<IActionResult> UpdateCourseName()
        {
            var updateCourse = _context.Courses.FirstOrDefault(c => c.CourseId == 2);
            return View(updateCourse);
        }

        //POST: update CourseName
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateCourseName(string CourseName)
        {
            var courseToUpdate = await _context.Courses.FirstOrDefaultAsync(e => e.CourseId == 2);
            if (courseToUpdate != null)
            {
                courseToUpdate.CourseName = CourseName;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
