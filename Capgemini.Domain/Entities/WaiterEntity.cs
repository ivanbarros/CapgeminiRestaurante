using Capgemini.Domain.Entities.Base;

namespace Capgemini.Domain.Entities
{
    public class WaiterEntity : BaseEntity
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
            
    }
}
