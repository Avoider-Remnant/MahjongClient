namespace GameWideSystems.SessionManager
{
    public class SessionContainer
    {
        public SessionContainer()
        {
            Session = new Session();
        }

        public ISession Session { get; set; }
    }
}