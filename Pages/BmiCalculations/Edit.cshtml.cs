using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BmiBeregner.Data;
using BmiBeregner.Models;

namespace BmiBeregner.Pages.BmiCalculations
{
    public class EditModel : PageModel
    {
        private readonly BmiBeregner.Data.BmiBeregnerContext _context;

        public EditModel(BmiBeregner.Data.BmiBeregnerContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(BmiCalculation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BmiCalculationExists(BmiCalculation.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BmiCalculationExists(int id)
        {
            return _context.BmiCalculation.Any(e => e.ID == id);
        }
    }
}
