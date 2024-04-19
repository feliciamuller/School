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
    public class EnrollmentsController : Controller
    {
        private readonly SchoolDbContext _context;

        public EnrollmentsController(SchoolDbContext context)
        {
            _context = context;
        }

        //Get all enrollments
        public async Task<IActionResult> Index()
        {
            var enrollmentsList = _context.Enrollments
                .Include(e => e.Course)
                .OrderBy(e => e.Course)
                .Include(e => e.Student)
                .Include(e => e.Teacher)
                .ToListAsync();

            return View(await enrollmentsList);
        }
        //Get teachers for programming 1
        public async Task<IActionResult> GetTeachers()
        {
            var teachersList = _context.Enrollments
                .Include(e => e.Teacher)
                .Include(e => e.Course)
                .Where(e => e.FKCourseId == 1)
                .ToListAsync();

            return View(await teachersList);
        }
        //Get students and their teachers
        public async Task<IActionResult> GetStudentAndTeacher()
        {
            var studentTeacherList = _context.Enrollments
                .Include(e => e.Teacher)
                .Include(e => e.Student)
                .Include(e => e.Course)
                .ToListAsync();

            return View(await studentTeacherList);
        }
        //Get students and teachers for programming 1
        public async Task<IActionResult> GetStudentAndCourse()
        {
            var studentTeacherList = _context.Enrollments
                .Include(c => c.Teacher)
                .Include(c => c.Student)
                .Include(c => c.Course)
                .Where(c => c.FKCourseId == 1)
                .ToListAsync();

            return View(await studentTeacherList);
        }
        //GET: Update a students teacher in Programming 1
        public async Task<IActionResult> UpdateTeacher()
        {
            var studentTeacherList = _context.Enrollments
                .Include(e => e.Teacher)
                .Include(e => e.Student)
                .Include(e => e.Course)
                .Where(e => e.FKCourseId == 1)
                .ToList();

            var teachers = _context.Teachers.ToList();

            var viewModel = new StudentTeacherViewModel
            {
                Enrollments = studentTeacherList,
                Teachers = teachers,
            };
            return View(viewModel);
        }

        //POST: Update a students teacher in Programming 1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateTeacher(int FKStudentId, int selectedTeacher)
        {
            var enrollmentToUpdate = await _context.Enrollments
                .FirstOrDefaultAsync(e => e.FKStudentId == FKStudentId);
            if (enrollmentToUpdate != null)
            {
                enrollmentToUpdate.FKTeacherId = selectedTeacher;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
