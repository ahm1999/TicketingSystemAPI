namespace TicketingSystem.Shared.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        private bool _IsEmpty;
        public bool IsEmpty => _IsEmpty ;

        protected void MarkAsEmpty() => _IsEmpty = true ;
        public static T Empty<T>() where T : BaseEntity, new() { 
            
            var entity = new T();
            entity.MarkAsEmpty() ;
            return entity;
        }
    }
}
