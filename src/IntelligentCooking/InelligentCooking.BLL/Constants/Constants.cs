namespace InelligentCooking.BLL.Constants
{
    public static class Constants
    {
        public static string TimeRegExp => @"\d\d:\d\d";

        public static string TimeFormat => @"hh\:mm";

        public static string DublicateObjectErrorMessage(string entity, string property)
        {
            return $"{entity} with specified {property} already exists";
        }

        public static string NotFoundErrorMessage(string entity)
        {
            return $"There is no {entity} with such id";
        }

        public static string CollectionsOfSameLengthErrorMessage(string collection1, string collection2)
        {
            return $"{collection1} and {collection2} must be of same length";
        }

        public static string WrongPasswordErrorMessage()
        {
            return $"Given password is not valid for current user";
        }

        public static string TokenNotExpiredErrorMessage()
        {
            return $"Token has not expired yet";
        }

        public static string InvalidTokenErrorMessage()
        {
            return $"Invalid token";
        }
    }
}