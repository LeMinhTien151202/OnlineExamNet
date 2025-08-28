namespace ExamOnline.Interfaces.IRole
{
    public interface IRoleRepository
    {
        Task<Role?> GetRoleByNameAsync(string name);
    }
}
