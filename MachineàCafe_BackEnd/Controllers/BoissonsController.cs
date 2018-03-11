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
    public class BoissonsController : ApiController
    {
        private MachineàCafe_BackEndContext db = new MachineàCafe_BackEndContext();

        // GET: api/Boissons
        public IQueryable<Boissons> GetBoissons()
        {
            return db.Boissons;
        }

        // GET: api/Boissons/5
        [ResponseType(typeof(Boissons))]
        public async Task<IHttpActionResult> GetBoissons(int id)
        {
            Boissons boissons = await db.Boissons.FindAsync(id);
            if (boissons == null)
            {
                return NotFound();
            }

            return Ok(boissons);
        }

        // PUT: api/Boissons/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBoissons(int id, Boissons boissons)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != boissons.Id)
            {
                return BadRequest();
            }

            db.Entry(boissons).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoissonsExists(id))
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

        // POST: api/Boissons
        [ResponseType(typeof(Boissons))]
        public async Task<IHttpActionResult> PostBoissons(Boissons boissons)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Boissons.Add(boissons);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = boissons.Id }, boissons);
        }

        // DELETE: api/Boissons/5
        [ResponseType(typeof(Boissons))]
        public async Task<IHttpActionResult> DeleteBoissons(int id)
        {
            Boissons boissons = await db.Boissons.FindAsync(id);
            if (boissons == null)
            {
                return NotFound();
            }

            db.Boissons.Remove(boissons);
            await db.SaveChangesAsync();

            return Ok(boissons);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BoissonsExists(int id)
        {
            return db.Boissons.Count(e => e.Id == id) > 0;
        }
    }
}