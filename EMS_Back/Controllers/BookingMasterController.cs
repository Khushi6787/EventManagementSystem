﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ems.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ems.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingMasterController : ControllerBase
    {
        private readonly emsContext _context;
        public BookingMasterController(emsContext context)
        {
            _context = context;
        }
        // GET: api/<BookingMasterController>
        [HttpGet]
        public List<BookingMaster> GetMyBookings(string email)
        {

            try
            {
                List<BookingMaster> bookings =_context.BookingMaster.Include(x => x.Event).Where(e => e.CustomerEmail == email).ToList();
                return bookings;
            }   
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST api/<BookingMasterController>
        [HttpPost]
        public BookingMaster BookTicket(BookingMaster booking)
        {
            try
            {
                _context.BookingMaster.Add(booking);
                _context.SaveChanges();
                return _context.BookingMaster.Find(booking.BookingId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // PUT api/<BookingMasterController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BookingMasterController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
