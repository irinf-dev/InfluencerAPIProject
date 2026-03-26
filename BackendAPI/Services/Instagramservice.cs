namespace BackendAPI.Services
{
    public class InstagramService
    {
        public void SendDM(string username, string message)
        {
            Console.WriteLine($"DM sent to @{username}: {message}");
        }
    }
}
