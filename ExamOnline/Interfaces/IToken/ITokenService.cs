namespace ExamOnline.Interfaces.IToken
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
