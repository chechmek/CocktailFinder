namespace CocktailFinderBackend.Helpers.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException()
        {

        }
        public NotFoundException(string name)
        : base(String.Format("NotFound: {0}", name))
        {

        }
    }
}
