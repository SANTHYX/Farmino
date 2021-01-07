namespace Farmino.Service.Exceptions
{
    public static class ServiceErrorCodes
    {
        public static string AlreadyConnected => "already_connected";
        public static string UserDontExist => "user_dont_exist";
        public static string UserAlreadyExist => "user_already_exist";
        public static string LoginAlreadyTaken => "login_already_taken";
        public static string ProfileDontExist => "profile_dont_exist";
        public static string ProfileAlreadyExist => "profile_already_exist";
        public static string AddressNotExist => "address_not_exist";
        public static string AddressAlreadyExist => "address_already_exist";
        public static string InvalidCredentials => "invalid_credentials";
        public static string RefreshTokenDontExist => "refresh_token_not_exist";
        public static string RefreshTokenIsRevoked => "refresh_token_is_revoked";
        public static string RefreshTokenIsActive => "refresh_token_is_active";
        public static string FarmerAlreadyExist => "farmer_already_exist";
        public static string FarmerNotExist => "farmer_not_exist";
        public static string CustomerAlreadyExist => "customer_already_exist";
        public static string CustomerDontExist => "customer_dont_exist";
        public static string OfferNotExist => "offer_not_exist";
        public static string ProductNoExist => "product_not_exist";
        public static string AuctionerNotExist => "auctioner_not_exist";
        public static string AuctionerAlreadyExist => "auctioner_already_exist";
        public static string ParticipantNotExist => "participant_not_exist";
        public static string ParticipantAlreadyExist => "participant_already_exist";
        public static string AuctionDontExist => "auction_dont_exist";
        public static string YourPropositionIsToLow => "your_proposition_is_to_low";
        public static string CannotCancelReleasedOrder => "cannot_cancel_released_order";
        public static string CannotBuyFromOwnOffer => "cannot_buy_from_own_offer";
        public static string ProductStorageIsEmpty => "product_storage_is_empty";
        public static string AuctionHasNotEndYet => "auction_has_not_end_yet";
    }
}
