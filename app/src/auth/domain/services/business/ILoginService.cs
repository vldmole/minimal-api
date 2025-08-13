using minimal_api.auth;
using minimal_api.src.auth.api.modelViews;


namespace minimal_api.src.auth.domain.services.business
{
    public interface ILoginService
    {
        public LoggedUser Login(LoginDTO loginDTO);
    }
}