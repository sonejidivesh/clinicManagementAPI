namespace PrescriptionGeneration.Interface
{
    public interface IJwtTokenManager
    {

        string Authenicate(string doctorName, string password);
    }
}
