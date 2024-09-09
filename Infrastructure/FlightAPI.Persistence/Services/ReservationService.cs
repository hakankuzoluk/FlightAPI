using FlightAPI.Application.Abstractions.Services;
using FlightAPI.Application.ViewModels.Reservations;
using FlightAPI.Domain.Entities;
using FlightAPI.Domain.Entities.Identity;
using FlightAPI.Persistence.Contexts;
using Google;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAPI.Persistence.Services
{
    public class ReservationService : IReservationService
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly UserManager<AppUser> _userManager;
        readonly FlightAPIDbContext _context;

        public ReservationService(IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager, FlightAPIDbContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _context = context;
        }

        public async Task<AppUser?> ContextUser()
        {
            var user = _httpContextAccessor?.HttpContext?.User;

            var username = _httpContextAccessor?.HttpContext?.User?.Identity?.Name;
            if (!string.IsNullOrEmpty(username))
            {
                return await _userManager.Users
                    .Include(x => x.Reservations)
                    .FirstOrDefaultAsync(u => u.UserName == username);
            }
            return null;
        }

        // Rezervasyon ekleme işlemi
        public async Task AddReservationAsync(VM_Create_Reservations reservation)
        {
            var user = await ContextUser();
            if (user != null)
            {
                var newReservation = new Reservation
                {
                    FlightId = reservation.FlightId,
                    UserId = user.Id,
                    Quantity = reservation.Quantity,
                    // Diğer özellikleri burada ekleyin
                };
                _context.Reservations.Add(newReservation);
                await _context.SaveChangesAsync();
            }
        }

        // Kullanıcının rezervasyonlarını listeleme
        public async Task<List<Reservation>> GetReservationsAsync()
        {
            var user = await ContextUser();
            if (user != null)
            {
                return await _context.Reservations
                    .Include(r => r.Flight) // Uçuş bilgilerini de dahil et
                    .Include(r => r.User)
                    .Where(r => r.UserId == user.Id)
                    .ToListAsync();
            }
            return new List<Reservation>();
        }
        public async Task<List<Reservation>> GetReservationUserAsync()
        {
            var user = await ContextUser();
            if (user != null)
            {
                return await _context.Reservations
                    .Include(r => r.Flight) // Uçuş bilgilerini de dahil et
                    .Include(r => r.User)
                    .Where(r => r.UserId == user.Id)
                    .ToListAsync();
            }
            return new List<Reservation>();
        }

        // Rezervasyon iptal etme işlemi

        public async Task<bool> RemoveReservationAsync(int reservationId)
        {
            try
            {
                var reservation = await _context.Reservations.FindAsync(reservationId);
                if (reservation != null)
                {
                    _context.Reservations.Remove(reservation);
                    await _context.SaveChangesAsync();
                }
                return true;
            }
            catch (Exception ex) 
            {
                return false;
            }
           
           
        }

        // Rezervasyon güncelleme işlemi (Örneğin koltuk sayısını güncelleme)
        public Task UpdateQuantityAsync(VM_Update_Reservations reservation)
        {
            throw new NotImplementedException();
        }

        public async Task<List<VM_List_Reservations>> GetAllReservationAsync()
        {
            return await _context.Reservations
                .Include(r => r.User)  // Kullanıcı bilgilerini dahil et
                .Include(r => r.Flight)  // Uçuş bilgilerini dahil et
                .Select(r => new VM_List_Reservations
                {
                    UserName = r.User.UserName, // Kullanıcı Adı
                    ReservationId = r.Id,
                    Name = r.User.NameSurname,
                    Destination = r.Flight.Destination,
                    Departure = r.Flight.Departure,
                    ReservationTime = r.Flight.Date, // Rezervasyon Zamanı
                    Quantity = r.Quantity // Kişi Sayısı
                })
                .ToListAsync();
        }
    }
}
