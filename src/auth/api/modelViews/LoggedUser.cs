namespace minimal_api.src.auth.api.modelViews
{
    public class LoggedUser(string email, string perfil, string token)
    {
        public string Email { get; } = email;
        public string Perfil { get; } = perfil;
        public string Token { get; } = token;
    }
}