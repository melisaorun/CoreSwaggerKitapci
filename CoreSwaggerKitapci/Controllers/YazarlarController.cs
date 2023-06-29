using CoreSwaggerKitapci.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreSwaggerKitapci.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YazarlarController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public YazarlarController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet] //api listeleme
        [Route("GetYazarlar")]
        public async Task<IEnumerable<Yazarlar>> GetYazarlar()
        {
            return await _db.Yazarlar.ToListAsync();

        }
        //paralel  programının içinde kullanılır. amacıda uygulamanında aynı anda birden fazla işi yapabilmesini sağlamaktadır.

        [HttpPost] //api ekleme httppost
        [Route("AddYazarlar")]
        public async Task<Yazarlar> AddYazarlar(Yazarlar yazarlar)
        {
            _db.Yazarlar.Add(yazarlar);
            await _db.SaveChangesAsync();
            return yazarlar;
        }
        [HttpPut] //api günceleme httpput
        [Route("UpdateYazarlar/{id}")]
        public async Task<Yazarlar> UpdateYazarlar(Yazarlar yazarlar)
        {
            _db.Entry(yazarlar).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return yazarlar;

        }
        [HttpDelete] //api günceleme httpput
        [Route("DeleleYazarlar/{id}")]
        public bool DeleteYazarlar(int id)
        {
            bool a = false;
            var yazarlar = _db.Yazarlar.Find(id);
            if (yazarlar != null)
            {
                a = true;
                _db.Entry(yazarlar).State = EntityState.Deleted;
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
