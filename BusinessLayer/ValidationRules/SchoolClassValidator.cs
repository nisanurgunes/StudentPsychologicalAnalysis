using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class SchoolClassValidator : AbstractValidator<SchoolClass>
    {
        public SchoolClassValidator()
        {
            RuleFor(x => x.ClassList).NotEmpty().WithMessage("Kategori Adını Boş Geçemezsiniz");
            RuleFor(x => x.ClassesTeacher).NotEmpty().WithMessage("Açıklamayı boş geçemezsiniz");
            RuleFor(x => x.ClassList).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapın");
            RuleFor(x => x.ClassList).MaximumLength(20).WithMessage("Lütfen 20 karakterden fazla değer girişi" +
                "yapmayın");
        }
    }
}
