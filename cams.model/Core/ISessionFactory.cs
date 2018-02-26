namespace cams.model.Core
{
    /// <summary>
    /// Defines the session factory.
    /// </summary>
    public interface ISessionFactory
    {
        ISession CreateSession();
    }
}