using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRS_Practice1.Models;

namespace PRS_Practice1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorsController : ControllerBase
    {
        private readonly PRSPrac1DbContext _context;

        public VendorsController(PRSPrac1DbContext context)
        {
            _context = context;
        }

        // GET: api/Vendors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vendor>>> GetVendors()
        {
            return await _context.Vendors.ToListAsync();
        }

        // GET: api/Vendors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vendor>> GetVendor(int id)
        {
            var vendor = await _context.Vendors.FindAsync(id);

            if (vendor == null)
            {
                return NotFound();
            }

            return vendor;
        }

        // ************* Handmade CreatePo method *************
        // GET: api/Vendors/Po/5
        [HttpGet("po/{vendorId}")]
        public async Task<ActionResult<Po>> CreatePo(int vendorId) { // Start of Method
            var po = new Po();

            po.Vendor = await _context.Vendors.FindAsync(vendorId);

            var resultlines = from v in _context.Vendors
                          join p in _context.Products
                            on v.Id equals p.VendorId
                          join rl in _context.RequestLines
                            on p.Id equals rl.ProductId
                          join r in _context.Requests
                             on rl.RequestId equals r.Id
                          where r.Status != "APPROVED"
                          where v.Id == vendorId              
                          select new {
                              p.Id,
                              ProductName = p.Name,
                              // p.Name,    <<<<<<<<<<<<<<<<<<<<<<< Why not just this ?????????????
                              rl.Quantity,
                              p.Price,
                              ResultLineTotal = p.Price * rl.Quantity
                          };

            var sortedLines = new SortedList<int, Poline>();
            foreach(var line in resultlines) {
                if (!sortedLines.ContainsKey(line.Id)) {
                    var poline = new Poline() {
                        // Product = line.Name,    <<<<<<<<<<<<<<<<<<<<<<< Why not just this ?????????????
                        Product = line.ProductName,
                        //Quantity = line.Quantity,
                        Quantity = 0,
                        Price = line.Price,
                        LineTotal = line.ResultLineTotal
                    };
                    sortedLines.Add(line.Id, poline);
                }
            sortedLines[line.Id].Quantity += line.Quantity;
            }

            po.Polines = sortedLines.Values;
            po.PoTotal= sortedLines.Sum(x => x.Value.LineTotal * x.Value.Quantity);

            return po;

        } // End of Method

        // PUT: api/Vendors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVendor(int id, Vendor vendor)
        {
            if (id != vendor.Id)
            {
                return BadRequest();
            }

            _context.Entry(vendor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Vendors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vendor>> PostVendor(Vendor vendor)
        {
            _context.Vendors.Add(vendor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVendor", new { id = vendor.Id }, vendor);
        }

        // DELETE: api/Vendors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVendor(int id)
        {
            var vendor = await _context.Vendors.FindAsync(id);
            if (vendor == null)
            {
                return NotFound();
            }

            _context.Vendors.Remove(vendor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VendorExists(int id)
        {
            return _context.Vendors.Any(e => e.Id == id);
        }

    }
}
