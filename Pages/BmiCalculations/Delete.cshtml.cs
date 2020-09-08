using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BmiBeregner.Data;
using BmiBeregner.Models;

namespace BmiBeregner.Pages.BmiCalculations
{
    public class DeleteModel : PageModel
    {
        private readonly BmiBeregner.Data.BmiBeregnerContext _context;

        public DeleteModel(BmiBeregner.Data.BmiBeregnerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BmiCalculation BmiCalculation { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BmiCalculation = await _context.BmiCalculation.FirstOrDefaultAsync(m => m.ID == id);

            if (BmiCalculation == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BmiCalculation = await _context.BmiCalculation.FindAsync(id);

            if (BmiCalculation != null)
            {
                _context.BmiCalculation.Remove(BmiCalculation);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
