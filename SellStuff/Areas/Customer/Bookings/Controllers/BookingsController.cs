using DataAccess;
using DataAccess.Migrations;
using DataAccess.Repositories.Bookings;
using DataAccess.Repositories.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Models.ViewModels.Bookings;
using System.Web;

namespace SellStuff.Areas.Customer.Bookings.Controllers
{
    [Route("bookings/[controller]")]
    [Authorize]
    public class BookingsController : Controller
    {
        private readonly UserManager<User> _userManager;
        private IBookingsRepository _bookingsRepository;
        private IUserRepository _userRepository;
        private readonly ApplicationDbContext Context;
        private readonly IEmailSender _emailSender;

        public BookingsController(UserManager<User> userManager, IBookingsRepository bookingsRepository, IUserRepository userRepository,
            ApplicationDbContext context, IEmailSender emailSender)
        {
            _userManager = userManager;
            _bookingsRepository = bookingsRepository;
            _userRepository = userRepository;
            Context = context;
            _emailSender = emailSender;
        }

        [Route("Create")]
        public async Task<IActionResult> Create()
        {

            var user = await _userManager.GetUserAsync(this.User);
            string url = "/identity/account/login?returnUrl=" + "/bookings/create";

            if (user == null)
            {
                return Redirect(url);
            }

            string userId = user.Id;
            ViewBag.UserId = userId;

            return View();
        }

        [Route("edit/{bookingId}")]
        public async Task<IActionResult> Edit([FromRoute] int bookingId)
        {
            var booking = await _bookingsRepository.GetBookingById(bookingId);

            if (bookingId == 0)
            {
                return RedirectToAction("Create");
            }
            string userId = booking.UserId;

            ViewBag.UserId = userId;

            return View();
        }

        [HttpPost]
        [Route("SetBookings")]
        public async Task<IActionResult> SetBookings(short model, byte memorysize, byte grade,
            DateTime dateselector, DateTime hourselector, string firstname, string lastname, string addresslineone,
           string addresslinetwo, string city, string postcode, string phonenumber)
        {

            var userObject = await _userManager.GetUserAsync(this.User);

            if (userObject == null) { return NotFound("user not found"); }

            string userId = userObject.Id;

            var booking = new Booking
            {
                ModelId = model,
                MemorySizeId = memorysize,
                GradeId = grade,
                UserId = userId,
                IsCompleted = false,
                IsCancelled = false
            };

            var bookingDateTime = dateselector.Date + hourselector.TimeOfDay;
            booking.BookingDateTime = bookingDateTime;

            var userPersonalInfo = await _userRepository.GetUserByUserId(userId);

            if (userPersonalInfo == null) { return NotFound("user not found"); }

            userPersonalInfo.FirstName = firstname;
            userPersonalInfo.LastName = lastname;
            userPersonalInfo.AddressLine1 = addresslineone;
            userPersonalInfo.AddressLine2 = addresslinetwo;
            userPersonalInfo.City = city;
            userPersonalInfo.PostCode = postcode;
            userPersonalInfo.PhoneNumber = phonenumber;

            await _bookingsRepository.CreateBooking(booking);
            Context.ChangeTracker.Clear();
            await _userRepository.UpdateUser(userPersonalInfo);
            await _emailSender.SendEmailAsync(userPersonalInfo.Email, "Booking Success!!!",
            $"Thankyou very much for booking with us.\n" +
            $"Your booking is on {bookingDateTime}.\n" +
            $"See you then!!!"
               );
            return RedirectToAction("Confirmation", "Bookings");
        }

        [HttpPost("update")]
        [Authorize]
        public async Task<IActionResult> EditBookings([FromForm] EditBookingRequest bookingInfo)
        {
            int bookingidParsed = Int32.Parse(bookingInfo.BookingId);

            var booking = await _bookingsRepository.GetBookingById(bookingidParsed);

            string userId = booking.UserId;

            booking.ModelId = bookingInfo.Model;
            booking.MemorySizeId = bookingInfo.MemorySize;
            booking.GradeId = bookingInfo.Grade;
            booking.UserId = userId;

            var bookingDateTime = bookingInfo.DateSelector.Date + bookingInfo.HourSelector.TimeOfDay;
            booking.BookingDateTime = bookingDateTime;

            var userPersonalInfo = await _userRepository.GetUserByUserId(userId);

            userPersonalInfo.FirstName = bookingInfo.FirstName;
            userPersonalInfo.LastName = bookingInfo.LastName;
            userPersonalInfo.AddressLine1 = bookingInfo.AddressLineOne;
            userPersonalInfo.AddressLine2 = bookingInfo.AddressLineTwo;
            userPersonalInfo.City = bookingInfo.City;
            userPersonalInfo.PostCode = bookingInfo.PostCode;
            userPersonalInfo.PhoneNumber = bookingInfo.PhoneNumber;

            await _bookingsRepository.UpdateBooking(booking);
            Context.ChangeTracker.Clear();
            await _userRepository.UpdateUser(userPersonalInfo);

            return RedirectToAction("Confirmation", "Bookings");
        }

        [HttpGet("confirmation")]
        [Authorize]
        public async Task<IActionResult> Confirmation()
        {
            return View();
        }
    }
}
