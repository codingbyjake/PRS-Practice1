using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRS_Practice1.Models;

namespace PRS_Practice1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        private readonly PRSPrac1DbContext _context;

        public RequestsController(PRSPrac1DbContext context)
        {
            _context = context;
        }

        // GET: api/Requests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Request>>> GetRequests()
        {
            return await _context.Requests.ToListAsync();
        }

        // GET: api/Requests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Request>> GetRequest(int id)
        {
            var request = await _context.Requests.FindAsync(id);

            if (request == null)
            {
                return NotFound();
            }

            return request;
        }

        // ************* Handmade GetReviews method *************
        //Gets requests in "REVIEW" status and not owned by the user with the primary key of id.
        // GET: api/Requests/Reviews/5
        [HttpGet("Reviews/{id}")]
        public async Task<ActionResult<IEnumerable<Request>>> GetReviews(int id) {
        // public async Task<ActionResult<List<Request>>> GetReviews(int id) {
            List<Request> requests = await _context.Requests.Where(x => (x.Status == "REVIEW") && (x.UserId != id)).ToListAsync();
            if (requests == null) {
                return NotFound();
            }
            return requests;
        }


        // PUT: api/Requests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequest(int id, Request request)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }

            _context.Entry(request).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestExists(id))
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

        // ************* Handmade Review method *************
        // PUT: api/Requests/Review/5
        [HttpPut("Review/{id}")]
        public async Task<IActionResult> Review(int id, Request request) {
            if (request.Total <= 50) {
                request.Status = "APPROVED";
            }
            else {
                request.Status = "REVIEW";
            }
            return await PutRequest(id, request);
        }

        // ************* Handmade Approve method *************
        // PUT: api/Requests/Approve/5
        [HttpPut("Approve/{id}")]
        public async Task<IActionResult> Approve(int id, Request request) {
            request.Status = "APPROVED";      
            return await PutRequest(id, request);
        }

        // ************* Handmade Reject method *************
        // PUT: api/Requests/Reject/5
        [HttpPut("Reject/{id}")]
        public async Task<IActionResult> Reject(int id, Request request) {
            request.Status = "REJECTED";
            return await PutRequest(id, request);
        }


        // POST: api/Requests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Request>> PostRequest(Request request)
        {
            _context.Requests.Add(request);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRequest", new { id = request.Id }, request);
        }

        // DELETE: api/Requests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequest(int id)
        {
            var request = await _context.Requests.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }

            _context.Requests.Remove(request);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RequestExists(int id)
        {
            return _context.Requests.Any(e => e.Id == id);
        }
    }
}
