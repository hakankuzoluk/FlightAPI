using FlightAPI.Application.ViewModels.Reservations;
using FlightAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAPI.Application.Abstractions.Services
{
    public interface IReservationService
    {
        public Task<List<Reservation>> GetReservationsAsync();

        public Task<List<VM_List_Reservations>> GetAllReservationAsync();

        public Task AddReservationAsync(VM_Create_Reservations reservation);

        public Task UpdateQuantityAsync(VM_Update_Reservations reservation);

        public Task<bool> RemoveReservationAsync(int reservationId);
    }
}
