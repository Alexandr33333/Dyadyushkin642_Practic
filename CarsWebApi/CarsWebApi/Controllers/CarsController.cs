using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CarsWebApi.Entities;

namespace CarsWebApi.Controllers
{
    public class CarsController : ApiController
    {
        private bdAvtoLider2Entities db = new bdAvtoLider2Entities();

        // GET: api/Cars
        public IQueryable<Cars> GetCars()
        {
            return db.Cars;
        }

        // GET: api/Cars/5
        [ResponseType(typeof(Cars))]
        public IHttpActionResult GetCars(int id)
        {
            Cars cars = db.Cars.Find(id);
            if (cars == null)
            {
                return NotFound();
            }

            return Ok(cars);
        }

        // PUT: api/Cars/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCars(int id, Cars cars)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cars.Id)
            {
                return BadRequest();
            }

            db.Entry(cars).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarsExists(id))
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

        // POST: api/Cars
        [ResponseType(typeof(Cars))]
        public IHttpActionResult PostCars(Cars cars)
        {
            if (string.IsNullOrWhiteSpace(cars.Brand))
                ModelState.AddModelError("Brand", "Enter the brand name of the car");
            if (!(cars.Brand.Intersect("#$%^&_").Count() == 0))
                ModelState.AddModelError("Brand", "The name of the brand of the car should not contain special characters");
            if (string.IsNullOrWhiteSpace(cars.Model))
                ModelState.AddModelError("Model", "Enter the model name of the car");
            try
            {
                Convert.ToDecimal(cars.Price);
            }
            catch
            {
                ModelState.AddModelError("Price", "Enter the price of the car");
            }
            try
            {
                Convert.ToInt32(cars.Amount);
            }
            catch
            {
                ModelState.AddModelError("Amount", "Enter the amount of the car");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cars.Add(cars);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cars.Id }, cars);
        }

        // DELETE: api/Cars/5
        [ResponseType(typeof(Cars))]
        public IHttpActionResult DeleteCars(int id)
        {
            Cars cars = db.Cars.Find(id);
            if (cars == null)
            {
                return NotFound();
            }

            db.Cars.Remove(cars);
            db.SaveChanges();

            return Ok(cars);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CarsExists(int id)
        {
            return db.Cars.Count(e => e.Id == id) > 0;
        }
    }
}