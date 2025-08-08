namespace WinFormsApp1
{
    public class Userlogic
    {
        public string? Username { get; set; }
        public string? Password { get; set; }

        public bool ValidateUser()
        {
            return Username == "admin" && Password == "admin@123";
        }

        public string Greet()
        {
            return $"Welcome, {Username}!";
        }
    }
}
