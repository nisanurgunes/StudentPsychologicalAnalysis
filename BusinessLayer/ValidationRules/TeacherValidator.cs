using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class TeacherValidator : AbstractValidator<Teacher>
    {
        //TeacherValidator
        public TeacherValidator()
        {
            RuleFor(x => x.TeacherName).NotEmpty().WithMessage("Kişi adını boş geçemezsiniz");
            RuleFor(x => x.TeacherSurname).NotEmpty().WithMessage("Kişi soy adını boş geçemezsiniz");
            RuleFor(x => x.TeacherAbout).NotEmpty().WithMessage("Hakkımda kısmını boş geçemezsiniz");
            RuleFor(x => x.TeacherClass).NotEmpty().WithMessage("Unvan kısmını boş geçemezsiniz.");
            //Ödev: Yazarın hakkında kısmında mutlaka A harfi ifade yer alsın.
            //RuleFor(x => x.WriterAbout).Must(x => x != null && x.ToUpper().Contains("A")).WithMessage("Hakkında kısmında en az bir a harfi içermelidir");
            RuleFor(x => x.TeacherName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapın");
            RuleFor(x => x.TeacherSurname).MaximumLength(50).WithMessage("Lütfen 50 karakterden fazla değer girişi" +
                "yapmayın");           
        }
    }
}
