namespace Farmino.Service.Exceptions
{
    public static class ServiceErrorCodes
    {
        public static string AlreadyConnected => "already_connected";
        public static string UserDontExist => "user_dont_exist";
        public static string UserAlreadyExist => "user_already_exist";
        public static string LoginAlreadyTaken => "login_already_taken";
        public static string InvalidCredentials => "invalid_credentials";
    }
}
