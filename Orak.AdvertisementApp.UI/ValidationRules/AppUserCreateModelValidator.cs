using FluentValidation;
using Orak.AdvertisementApp.UI.Models;

namespace Orak.AdvertisementApp.UI.ValidationRules
{
    public class AppUserCreateModelValidator : AbstractValidator<AppUserCreateModel>
    {
        public AppUserCreateModelValidator()
        {
            RuleFor(x=> x.Password).NotEmpty().WithMessage("Parola alanı boş olamaz.");
            RuleFor(x => x.Password).MinimumLength(3).WithMessage("Parolanız en az 3 karakter olmalıdır.");
            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword).WithMessage("Parolalar eşleşmiyor.");// Equal = eşittir manasında kullanılır.
            RuleFor(x=> x.Username).MinimumLength(3).WithMessage("Kullanıcı adı en az 3 karakterden oluşturulmalıdır.");
            RuleFor(x => new
            {
                x.Username,
                x.Firstname
            }).Must(x => CanNotFirstname(x.Username, x.Firstname)).WithMessage("kullanıcı adı adınızı içeremez.").When(x => x.Username != null && x.Firstname != null); 
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı adı alanı boş olamaz.");
            RuleFor(x => x.GenderId).NotEmpty().WithMessage("Cinsiyet alanı boş bırakılamaz.");
            RuleFor(x=> x.Firstname).NotEmpty().WithMessage("firstname alanı boş bırakılamaz.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname alanı boş bırakılamaz.");
        }
        // Must ile de şart ekliyoruz, kendimizin dışarıdan yazmış olduğu fonksiyonu burada tetikliyoruz.İlgili propertye yönelik.
        private bool CanNotFirstname(string userName, string firstname)
        {
            return !userName.Contains(firstname);
        }
    }
}
