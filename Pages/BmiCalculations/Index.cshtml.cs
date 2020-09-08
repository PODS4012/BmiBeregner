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
    public class IndexModel : PageModel
    {
        private readonly BmiBeregner.Data.BmiBeregnerContext _context;

        public IndexModel(BmiBeregner.Data.BmiBeregnerContext context)
        {
            _context = context;
        }

        public IList<BmiCalculation> BmiCalculation { get;set; }

        public async Task OnGetAsync()
        {
            BmiCalculation = await _context.BmiCalculation.ToListAsync();
        }
    }
}
