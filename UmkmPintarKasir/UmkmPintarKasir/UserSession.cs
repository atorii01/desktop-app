namespace UmkmPintarKasir
{
    public static class UserSession
    {
        public static int IdUser { get; set; }
        public static string Username { get; set; }
        public static string Role { get; set; }

        public static bool IsOwner
        {
            get { return Role == "OWNER"; }
        }

        public static bool IsKasir
        {
            get { return Role == "KASIR"; }
        }

        public static void Clear()
        {
            IdUser = 0;
            Username = null;
            Role = null;
        }
    }
}
