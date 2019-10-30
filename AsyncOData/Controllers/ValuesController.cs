using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncOData.Entities;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AsyncOData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly AsyncODataContext _context;
        public ValuesController(AsyncODataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Posts.ToListAsync());
        }
    }
}
