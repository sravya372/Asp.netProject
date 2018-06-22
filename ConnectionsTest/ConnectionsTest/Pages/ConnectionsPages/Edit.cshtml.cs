using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConnectionsTest.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ConnectionsTest.Pages.ConnectionsPages
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Connections Connection { get; set; }
        [TempData]
        public String AfterAddMessage { get; set; }
        public void OnGet(int id)
        {
            Connection = _db.ConnectionItems.Find(id);

        }
        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                var ConnectionInDb = _db.ConnectionItems.Find(Connection.ID);
                ConnectionInDb.ConnectionName = Connection.ConnectionName;

                await _db.SaveChangesAsync();
                AfterAddMessage = "List item update successfully!";

                return RedirectToPage("Index");
            }
            else
            {
                return RedirectToPage();
            }
        }
    }
}