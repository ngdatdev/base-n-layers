using Application.DTOs.Request;
using FluentValidation;
using static WebAPI.Validation.Constant.ConstantValidator;

namespace WebAPI.Validation
{
    public class LoginValidator : AbstractValidator<LoginRequest>
    {
        public LoginValidator()
        {
            RuleFor(loginRequest => loginRequest.Username)
                .NotEmpty()
                .WithMessage(UserNameIsRequired);

            RuleFor(LoginRequest => LoginRequest.Password)
                .NotEmpty()
                .WithMessage(PasswordIsRequired)
                .MaximumLength(50)
                .WithMessage(NameLength)
                .MinimumLength(3)
                .WithMessage(NameLength);
        }
    }
}
