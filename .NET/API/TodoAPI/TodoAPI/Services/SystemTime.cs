namespace TodoAPI.Services
{
    public class SystemTime : ISystemTime
    {
        public DateTime GetCurrentTime()
        {
            return DateTime.Now;
        }
    }
}
