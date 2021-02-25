using AutoMapper;

namespace BusinessLogicLayer.Profiles
{
    public class AutomapperProfileConfiguration
    {
        public static MapperConfiguration Configure()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new EventProfile());
                cfg.AddProfile(new UserProfile());                
            });
        }
    }
}
