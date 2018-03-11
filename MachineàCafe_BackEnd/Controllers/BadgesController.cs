using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MachineàCafe_BackEnd.Models;

namespace MachineàCafe_BackEnd.Controllers
{
    public class BadgesController : ApiController
    {
        private MachineàCafe_BackEndContext db = new MachineàCafe_BackEndContext();

        // GET: api/Badges
        public IQueryable<Badges> GetBadges()
        {
            return db.Badges;
        }

        // GET: api/Badges/5
        [ResponseType(typeof(Badges))]
        public async Task<IHttpActionResult> GetBadges(int id)
        {
            Badges badges = await db.Badges.FindAsync(id);
            if (badges == null)
            {
                return NotFound();
            }

            return Ok(badges);
        }

        // PUT: api/Badges/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBadges(int id, Badges badges)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != badges.Id)
            {
                return BadRequest();
            }

            db.Entry(badges).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BadgesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Badges
        [ResponseType(typeof(Badges))]
        public async Task<IHttpActionResult> PostBadges(Badges badges)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //Badges bado = new Badges { Name_Boisson =badges.Name_Boisson , Mug =  true, Sucre = 1, Badge = true};
            db.Badges.Add(badges);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = badges.Id }, badges);
        }

        // DELETE: api/Badges/5
        [ResponseType(typeof(Badges))]
        public async Task<IHttpActionResult> DeleteBadges(int id)
        {
            Badges badges = await db.Badges.FindAsync(id);
            if (badges == null)
            {
                return NotFound();
            }

            db.Badges.Remove(badges);
            await db.SaveChangesAsync();

            return Ok(badges);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BadgesExists(int id)
        {
            return db.Badges.Count(e => e.Id == id) > 0;
        }
    }
}