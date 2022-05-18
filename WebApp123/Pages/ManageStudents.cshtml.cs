using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp123.Models;
using WebApp123.Data;

namespace WebApp123.Pages
{
    public class ManageStudentsModel : PageModel
    {
        public List<Student> AllStudents { get; set; }
        [BindProperty]
        public Student NewStudent { get; set; }
        public ApplicationDbContext _context { get; set; }

        public ManageStudentsModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            AllStudents = _context.Students.ToList();
        }

        public void OnPostAddStudent() {
            _context.Students.Add(NewStudent);
            _context.SaveChanges();
            AllStudents = _context.Students.ToList();
        }
    }
}
