using System;
using System.Collections.Generic;
using System.Linq;

using WebPresence.Data.Interfaces;
using WebPresence.Domain.Model;

namespace WebPresence.Data
{
    public class ItemRepository : BaseDataRepository<Item>, IItemRepository
    {
    }
}
