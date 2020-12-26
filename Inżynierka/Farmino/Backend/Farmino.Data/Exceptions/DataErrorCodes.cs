namespace Farmino.Data.Exceptions
{
    public static class DataErrorCodes
    {
        public static string InvalidCity => "invalid_city";
        public static string InvalidStreet => "invalid_street";
        public static string InvalidPostalCode => "invalid_postalCode";
        public static string InvalidHouseNumber => "invalid_houseNumber";
        public static string InvalidFirstName => "invalid_firstName";
        public static string InvalidLastName => "invalid_lastName";
        public static string InvalidPhoneNumber => "invalid_phoneNumber";
        public static string InvalidUserId => "invalid_userId";
        public static string InvalidLogin => "invalid_login";
        public static string InvalidPassword => "invalid_password";
        public static string InvalidEmail => "invalid_email";
        public static string InvalidSalt => "invalid_salt";
        public static string InvalidTitle => "invalid_title";
        //Refresh Token
        public static string InvalidRefreshToken => "invalid_refresh_token";
        public static string InvalidToken => "invalid_refresh_token";
        //Offer
        //Product
        public static string InvalidProductName => "invalid_product_name";
        public static string InvalidProductQuantity => "invalid_product_quantity";
        public static string InvalidProductPrice => "invalid_product_price";
        //Weight
        public static string InvalidProductWeightValue => "invalid_product_weight_value";
    }
}
