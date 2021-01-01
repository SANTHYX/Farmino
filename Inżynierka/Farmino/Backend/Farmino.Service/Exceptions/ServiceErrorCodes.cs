namespace Farmino.Service.Exceptions
{
    public static class ServiceErrorCodes
    {
        public static string AlreadyConnected => "already_connected";
        public static string UserDontExist => "user_dont_exist";
        public static string UserAlreadyExist => "user_already_exist";
        public static string LoginAlreadyTaken => "login_already_taken";
        public static string ProfileDontExist => "profile_dont_exist";
        public static string InvalidCredentials => "invalid_credentials";
        public static string RefreshTokenDontExist => "refresh_token_not_exist";
        public static string RefreshTokenIsRevoked => "refresh_token_is_revoked";
        public static string RefreshTokenIsActive => "refresh_token_is_active";
        public static string FarmerAlreadyExist => "farmer_already_exist";
        public static string FarmerNotExist => "farmer_not_exist";
        public static string CustomerAlreadyExist => "customer_already_exist";
        public static string OfferNotExist => "offer_not_exist";
        public static string ProductNoExist => "product_not_exist";
    }
}
