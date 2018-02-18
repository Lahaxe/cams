namespace cams.model.Core
{
    public interface ISessionFactory
    {
        ISession CreateSession();
    }
}