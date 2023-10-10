namespace _00_Assingment.Interfacas
{
    public interface IUserHandlar
    {
        void AddUserAsync(IUserInfo userInfo);
        bool DeletOneUser(string FullName);
        IEnumerable<IUserInfo> GetAllUsers();
        IUserInfo GetOneUser(string FullName);
    }
}