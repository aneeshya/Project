using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeManager.Data;
using EmployeeManager.Models;
using System.Linq;
using System.Threading.Tasks;

public class EmployeeController : Controller
{
    private readonly ApplicationDbContext _context;

    public EmployeeController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Employees
    // GET: Employees
    public IActionResult Index(string searchString)
    {
        var employees = _context.Employeetbl.ToList();

        if (!String.IsNullOrEmpty(searchString))
        {
            employees = employees.Where(e => e.Name.Contains(searchString)).ToList();
        }

        return View(employees);
    }


    // GET: Employees/Details/5
    public IActionResult Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var employee = _context.Employeetbl.Find(id);
        if (employee == null)
        {
            return NotFound();
        }

        return View(employee);
    }

    // GET: Employees/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Employees/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    
    public async Task<IActionResult> Create([Bind("Name, Description")] Employee employee)
    {
        if (ModelState.IsValid)
        {
            // Check if the name already exists
            if (_context.Employeetbl.Any(e => e.Name == employee.Name))
            {
                ModelState.AddModelError("Name", "Employee with this name already exists.");
                return View(employee);
            }

            try
            {
                await _context.Database.ExecuteSqlInterpolatedAsync($"EXEC AddEmployee @Name={employee.Name}, @Description={employee.Description}");
                TempData["SuccessMessage"] = "Employee added successfully!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during database operation
                ModelState.AddModelError("", "Unable to save changes. Please try again.");
                return View(employee);
            }
        }
        return View(employee);
    }


    // GET: Employees/Edit/5
    public IActionResult Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var employee = _context.Employeetbl.Find(id);
        if (employee == null)
        {
            return NotFound();
        }

        return View(employee);
    }

    // POST: Employees/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Description")] Employee employee)
    {
        if (id != employee.ID)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync($"EXEC UpdateEmployee @ID={employee.ID}, @Name={employee.Name}, @Description={employee.Description}");
            return RedirectToAction(nameof(Index));
        }
        return View(employee);
    }

    // GET: Employees/Delete/5
    public IActionResult Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var employee = _context.Employeetbl.Find(id);
        if (employee == null)
        {
            return NotFound();
        }

        return View(employee);
    }

    // POST: Employees/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _context.Database.ExecuteSqlInterpolatedAsync($"EXEC DeleteEmployee @ID={id}");
        TempData["DeleteMessage"] = "Employee deleted successfully!";
        return RedirectToAction(nameof(Index));
    }

    private bool EmployeeExists(int id)
    {
        return _context.Employeetbl.Any(e => e.ID == id);
    }
}
