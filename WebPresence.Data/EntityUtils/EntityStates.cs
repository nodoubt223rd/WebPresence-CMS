using System.Data; 

namespace WebPresence.Data.EntityUtils
{
    public class EntityStates
    {
        protected static EntityState GetEntityState(Domain.Model.States.EntityState entityState)
        {
            switch (entityState)
            {
                case Domain.Model.States.EntityState.Added:
                    return EntityState.Added;
                case Domain.Model.States.EntityState.Deleted:
                    return EntityState.Deleted;
                case Domain.Model.States.EntityState.Modified:
                    return EntityState.Modified;
                case Domain.Model.States.EntityState.Unchanged:
                    return EntityState.Unchanged;
                default:
                    return EntityState.Detached;

            }
        }
    }
}
