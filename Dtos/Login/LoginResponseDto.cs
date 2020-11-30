namespace api.Dtos.Login
{
    public class LoginResponseDto
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string token { get; set; }
        public string rol { get; set; }
    }
}