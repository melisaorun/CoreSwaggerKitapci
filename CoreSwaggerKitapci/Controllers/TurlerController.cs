using CoreSwaggerKitapci.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreSwaggerKitapci.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurlerController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public TurlerController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet] //api listeleme
        [Route("GetTurler")]
        public async Task<IEnumerable<Turler>> GetTurler()
        {
            return await _db.Turler.ToListAsync();

        }
        //paralel  programının içinde kullanılır. amacıda uygulamanında aynı anda birden fazla işi yapabilmesini sağlamaktadır.

        [HttpPost] //api ekleme httppost
        [Route("AddTurler")]
        public async Task<Turler> AddTurler(Turler turler)
        {
            _db.Turler.Add(turler);
            await _db.SaveChangesAsync();
            return turler;
        }
        [HttpPut] //api günceleme httpput
        [Route("UpdateTurler/{id}")]
        public async Task<Turler> UpdateTurler(Turler turler)
        {
            _db.Entry(turler).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return turler;

        }
        [HttpDelete] //api günceleme httpput
        [Route("DeleleTurler/{id}")]
        public bool DeleteTurler(int id)
        {
            bool a = false;
            var turler = _db.Turler.Find(id);
            if (turler != null)
            {
                a = true;
                _db.Entry(turler).State = EntityState.Deleted;
                _db.SaveChanges();
            }
            else
            {
                a = false;
            }
            return a;

        }

    }
}
