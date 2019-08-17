using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using loggerapi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace loggerapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoggerDocumentController : ControllerBase
    {

        // TODO use a service here to decouple the business logic
        private readonly LoggerApiContext _context;

        public LoggerDocumentController(LoggerApiContext context)
        {
            _context = context;

            if (_context.LogDocuments.Count() == 0)
            {
                // Create a new LogDocument if collection is empty,
                // which means you can't delete all LogDocuments.
                _context.LogDocuments.Add(new LogDocument() { Message = "Mensaje de prueba!"});
                _context.SaveChanges();
            }
        }

        // GET: api/LoggerDocument
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LogDocument>>> GetLoggerDocuments()
        {
            return await _context.LogDocuments.ToListAsync();
        }

        // GET: api/LoggerDocument/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LogDocument>> GetLoggerDocument(long id)
        {
            var todoItem = await _context.LogDocuments.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        // POST: api/LogDocument
        [HttpPost]
        public async Task<ActionResult<LogDocument>> PostLogDocument(LogDocument logDocument)
        {
            _context.LogDocuments.Add(logDocument);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLoggerDocument), new { id = logDocument.Id }, logDocument);
        }
    }
}
