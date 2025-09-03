namespace Talabat.Core.Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
                            
        public NotFoundException(string name , object key) // Entity, Pk
            :base($"The {name} With Id:{key} Is Not Found!") 
        {
            
        }
    }
}
