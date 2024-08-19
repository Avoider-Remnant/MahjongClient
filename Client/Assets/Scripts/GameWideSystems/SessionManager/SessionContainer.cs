namespace GameWideSystems.SessionManager
{
    public class SessionContainer
    {
        public ISession Session { get; private set; }

        public void BuildSession(ISessionBuilder sessionBuilder)
        {
            Session = sessionBuilder.Build();
        }
        
    }
}