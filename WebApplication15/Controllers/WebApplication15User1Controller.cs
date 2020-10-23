using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication15.Areas.Identity.Data;
using WebApplication15.Data;

namespace WebApplication15.Controllers
{   [Authorize]
    
    public class WebApplication15User1Controller : Controller
    {
        private readonly WebApplication15Context _context;
        private readonly UserManager<WebApplication15User> _userManager;

        public WebApplication15User1Controller(WebApplication15Context context, UserManager<WebApplication15User> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        // GET: WebApplication15User1
        public async Task<IActionResult> Index()
        {
            return View(await _context.WebApplication15User.ToListAsync());
        }

        
        // GET: WebApplication15User1/Edit/5
        private List<string> list=new List<string>();
        [HttpPost]
        public async Task<IActionResult> SelectItem(string id)
        {
            list.Add(id);
            System.Diagnostics.Debug.WriteLine("123");
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(string id)
        {
            
                if (id == null)
                {
                    return NotFound();
                }

                var webApplication15User1 = await _context.WebApplication15User.FindAsync(id);
                if (webApplication15User1 == null)
                {
                    return NotFound();
                }
                if (webApplication15User1.LockoutEnd > DateTime.Today)
                {
                    webApplication15User1.LockoutEnd = DateTime.Today;
                    webApplication15User1.Status = UserStatus.Unblock;

                }
                else
                {
                    webApplication15User1.LockoutEnd = DateTime.Today.AddYears(100);
                    webApplication15User1.LockoutEnabled = true;
                    await _userManager.UpdateSecurityStampAsync(webApplication15User1);
                    webApplication15User1.Status = UserStatus.Block;
                }

                try
                {
                    _context.Update(webApplication15User1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WebApplication15User1Exists(webApplication15User1.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            
            return RedirectToAction(nameof(Index));            
        }

        // POST: WebApplication15User1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,Name,Email,RegistrationDate,LastLogingTime,Status")] WebApplication15User webApplication15User1)
        {
            if (id != webApplication15User1.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(webApplication15User1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WebApplication15User1Exists(webApplication15User1.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(webApplication15User1);
        }

        // GET: WebApplication15User1/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            
                if (id == null)
                {
                    return NotFound();
                }

                var webApplication15User1 = await _context.WebApplication15User.FindAsync(id);
                if (webApplication15User1 == null)
                {
                    return NotFound();
                }

                _context.WebApplication15User.Remove(webApplication15User1);
                await _context.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
            
        }

        // POST: WebApplication15User1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var webApplication15User1 = await _context.WebApplication15User.FindAsync(id);
            _context.WebApplication15User.Remove(webApplication15User1);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool WebApplication15User1Exists(string id)
        {
            return _context.WebApplication15User.Any(e => e.Id == id);
        }
    }
}
