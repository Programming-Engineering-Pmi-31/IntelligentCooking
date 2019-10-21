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
    }
}