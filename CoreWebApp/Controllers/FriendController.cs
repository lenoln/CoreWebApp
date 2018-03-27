using LibraryData.Models;
using LibraryData.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CoreWebApp.Controllers
{
    [Route("api/[controller]")]
    public class FriendController : Controller
    {
        private readonly IFriendService _friendService;
        public FriendController(IFriendService friendService)
        {
            _friendService = friendService;
        }
        // GET: api/Friend
        [HttpGet]
        public IEnumerable<Friend> Get()
        {
            return _friendService.GetAll();
        }

        // GET: api/Friend/5
        [HttpGet("{id}", Name = "Get")]
        public Friend Get(int id)
        {
            return _friendService.GetById(id);
        }
        
        // POST: api/Friend
        [HttpPost]
        public void Post([FromBody]Friend friend)
        {
            _friendService.Add(friend);
        }
        
        // PUT: api/Friend/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Friend friend)
        {
            _friendService.Update(friend);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _friendService.Remove(id);
        }
    }
}
