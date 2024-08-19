namespace GameWideSystems.SessionManager
{
    public class SessionBuilder : ISessionBuilder
    {
        public ISession Build()
        {
            return new Session();
        }
    }
}