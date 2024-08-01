using FlightAPI.Application.ViewModels.Flights;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAPI.Application.Validators.Flights
{
    public class CreateFlightValidator : AbstractValidator<VM_Flight_Create>
    {
       public CreateFlightValidator() {

            RuleFor(p => p.Departure)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Uçak Kalkış Alanı Boş Olamaz!")
                .MaximumLength(30)
                .MinimumLength(2)
                    .WithMessage("Uçak Kalkış Alanı için Lütfen 2 ile 30 Karakter Arasında Değer Giriniz!");

            RuleFor(p => p.Destination)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Uçak İniş Alanı Boş Olamaz!")
                .MaximumLength(30)
                .MinimumLength(2)
                    .WithMessage("Uçak İniş Alanı için Lütfen 2 ile 30 Karakter Arasında Değer Giriniz!");

            RuleFor(s => s.Price)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Bilet Fiyat Alanı Boş Olamaz!")
                .Must(s => s>= 0)
                    .WithMessage("Bilet Fiyatı Negatif Bir Değer Olamaz!");

            RuleFor(s => s.Capacity)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Kapasite Alanı Boş Olamaz!")
                .Must(s => s >= 0)
                    .WithMessage("Kapasite Negatif Bir Değer Olamaz.");






        }
    }
}
