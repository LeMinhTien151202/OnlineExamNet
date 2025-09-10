using Domain.Entities;

namespace ExamOnline.Interfaces.IToken
{
    public interface ITokenService
    {
        Task<string?> CreateToken(ApplicationUser user);
    }
}
