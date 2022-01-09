namespace HousePricePrediction.API.Resources
{
    public static class Messages
    {
        public const string InvalidCredentials = "Invalid credentials.";
        public const string DuplicateUsernameOrEmail = "A user with the same username or email already exists.";
        public const string InvalidEmail = "Invalid email.";
        public const string PasswordLengthError = "The Password field must be a minimum of 6 characters.";
        public const string InvalidData = "Invalid data.";
        public static string HouseNotFoundMessage(System.Guid Id)
        {
            return $"{EntitiesConstants.HouseEntity} with id {Id} not found.";
        }
        public static string UserNotFoundMessage(System.Guid Id)
        {
            return $"{EntitiesConstants.UserEntity} with id {Id}.";
        }
    }
}
