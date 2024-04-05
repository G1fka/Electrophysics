namespace ClassLibrary
{
    public class CurrentUser
    {
        public static User User { get; set; }
        public CurrentUser()
        {
            User = new User();
        }
    }
}
