using Microsoft.AspNetCore.Identity;

namespace Connex.DataAccess.Helpers;

public class CustomIdentityErrorDescriber:IdentityErrorDescriber
{
    public override IdentityError ConcurrencyFailure()
    {
        return new IdentityError { Code = nameof(ConcurrencyFailure), Description = "Uyğunlaşma xətası baş verdi." };
    }

    public override IdentityError DefaultError()
    {
        return new IdentityError { Code = nameof(DefaultError), Description = "Naməlum xəta baş verdi." };
    }

    public override IdentityError DuplicateEmail(string email)
    {
        return new IdentityError { Code = nameof(DuplicateEmail), Description = $"'{email}' email artıq istifadə olunur." };
    }

    public override IdentityError DuplicateRoleName(string role)
    {
        return new IdentityError { Code = nameof(DuplicateRoleName), Description = $"'{role}' rolu artıq mövcuddur." };
    }

    public override IdentityError DuplicateUserName(string userName)
    {
        return new IdentityError { Code = nameof(DuplicateUserName), Description = $"'{userName}' istifadəçi adı artıq mövcuddur." };
    }

    public override IdentityError InvalidEmail(string? email)
    {
        return new IdentityError { Code = nameof(InvalidEmail), Description = $"'{email}' email yanlışdır." };
    }

    public override IdentityError InvalidRoleName(string? role)
    {
        return new IdentityError { Code = nameof(InvalidRoleName), Description = $"'{role}' rolu yanlışdır." };
    }

    public override IdentityError InvalidToken()
    {
        return new IdentityError { Code = nameof(InvalidToken), Description = "Token yanlışdır." };
    }

    public override IdentityError InvalidUserName(string? userName)
    {
        return new IdentityError { Code = nameof(InvalidUserName), Description = $"'{userName}' istifadəçi adı yanlışdır." };
    }

    public override IdentityError LoginAlreadyAssociated()
    {
        return new IdentityError { Code = nameof(LoginAlreadyAssociated), Description = "Bu login artıq başqa istifadəçi ilə əlaqələndirilib." };
    }

    public override IdentityError PasswordMismatch()
    {
        return new IdentityError { Code = nameof(PasswordMismatch), Description = "Parol yanlışdır." };
    }

    public override IdentityError PasswordRequiresDigit()
    {
        return new IdentityError { Code = nameof(PasswordRequiresDigit), Description = "Parol ən azı bir rəqəm ('0'-'9') ehtiva etməlidir." };
    }

    public override IdentityError PasswordRequiresLower()
    {
        return new IdentityError { Code = nameof(PasswordRequiresLower), Description = "Parol ən azı bir kiçik hərf ('a'-'z') ehtiva etməlidir." };
    }

    public override IdentityError PasswordRequiresNonAlphanumeric()
    {
        return new IdentityError { Code = nameof(PasswordRequiresNonAlphanumeric), Description = "Parol ən azı bir xüsusi simvol ehtiva etməlidir." };
    }

    public override IdentityError PasswordRequiresUniqueChars(int uniqueChars)
    {
        return new IdentityError { Code = nameof(PasswordRequiresUniqueChars), Description = $"Parol ən azı {uniqueChars} fərqli simvoldan ibarət olmalıdır." };
    }

    public override IdentityError PasswordRequiresUpper()
    {
        return new IdentityError { Code = nameof(PasswordRequiresUpper), Description = "Parol ən azı bir böyük hərf ('A'-'Z') ehtiva etməlidir." };
    }

    public override IdentityError PasswordTooShort(int length)
    {
        return new IdentityError { Code = nameof(PasswordTooShort), Description = $"Parol ən azı {length} simvoldan ibarət olmalıdır." };
    }

    public override IdentityError RecoveryCodeRedemptionFailed()
    {
        return new IdentityError { Code = nameof(RecoveryCodeRedemptionFailed), Description = "Bərpa kodu istifadə edilə bilmədi." };
    }

    public override IdentityError UserAlreadyHasPassword()
    {
        return new IdentityError { Code = nameof(UserAlreadyHasPassword), Description = "İstifadəçi artıq parol təyin edib." };
    }

    public override IdentityError UserAlreadyInRole(string role)
    {
        return new IdentityError { Code = nameof(UserAlreadyInRole), Description = $"İstifadəçi artıq '{role}' rolundadır." };
    }

    public override IdentityError UserLockoutNotEnabled()
    {
        return new IdentityError { Code = nameof(UserLockoutNotEnabled), Description = "İstifadəçi üçün kilidləmə aktiv deyil." };
    }

    public override IdentityError UserNotInRole(string role)
    {
        return new IdentityError { Code = nameof(UserNotInRole), Description = $"İstifadəçi '{role}' rolunda deyil." };
    }
}
