using CoreSwaggerKitapci.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace CoreSwaggerKitapci.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KitaplarController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public KitaplarController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet] //api listeleme
        [Route("GetKitaplar")]
        public async Task<IEnumerable<Kitaplar>> GetKitaplar()
        {
            return await _db.Kitaplar.ToListAsync();

        }
        //paralel  programının içinde kullanılır. amacıda uygulamanında aynı anda birden fazla işi yapabilmesini sağlamaktadır.

        [HttpPost] //api ekleme httppost
        [Route("AddKitaplar")]
        public async Task<Kitaplar> AddKitaplar(Kitaplar kitaplar)
        {
            _db.Kitaplar.Add(kitaplar);
            await _db.SaveChangesAsync();
            return kitaplar;
        }
        [HttpPut] //api günceleme httpput
        [Route("UpdateKitaplar/{id}")]
        public async Task<Kitaplar> UpdateKitaplar(Kitaplar kitaplar)
        {
            _db.Entry(kitaplar).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return kitaplar;

        }
        [HttpDelete] //api günceleme httpput
        [Route("DeleleKitaplar/{id}")]
        public bool DeleteKitaplar(int id)
        {
            bool a = false;
            var kitaplar = _db.Kitaplar.Find(id);
            if (kitaplar != null)
            {
                a = true;
                _db.Entry(kitaplar).State = EntityState.Deleted;
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
