namespace InelligentCooking.BLL.Constants
{
    public static class Constants
    {
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

        public static string PropNotNegativeErrorMessage(string property)
        {
            return $"{property} must not be negative value";
        }

        public static string TimeRegExp => @"\d\d:\d\d";
    }
}