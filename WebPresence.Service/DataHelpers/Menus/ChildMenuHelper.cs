using System;
using System.Collections.Generic;

using WebPresence.Domain.Model;
using WebPresence.Presentation.ViewModels.ContentMenu;

namespace WebPresence.Service.DataHelpers.Menus
{
    internal class ChildMenuHelper
    {
        public static ChildNode BuildChildNode(Item item, List<Item> items)
        {
            if (item.IsChild && item.IsParentItem)
            {
                ChildNode node = new ChildNode();

                node.Id = item.Id;
                node.ParentItemId = item.ParentItemId.Value;
                node.ItemTypeId = item.ItemTypeId;
                node.ItemName = item.ItemName;
                node.DisplayName = item.DisplayName;
                node.Created = item.Created;
                node.ContentOwner = item.ContentOwner;

                if (item.IsParentItem)
                {
                    node.Siblings = new List<ChildNode>();

                    new ChildMenuHelper().BuildSiblings(node, items);
                }

                return node;
            }
            else
                return null;
        }

        private ChildNode BuildSiblings(ChildNode node, List<Item> items)
        {
            foreach (var item in items)
            {
                if(item.ParentItemId == node.Id)
                {
                    if (item.IsChild && !item.IsParentItem)
                    {
                        ChildNode sibling = new ChildNode();

                        sibling.Id = item.Id;
                        sibling.ParentItemId = item.ParentItemId.Value;
                        sibling.ItemTypeId = item.ItemTypeId;
                        sibling.ItemName = item.ItemName;
                        sibling.DisplayName = item.DisplayName;
                        sibling.Created = item.Created;
                        sibling.ContentOwner = item.ContentOwner;

                        node.Siblings.Add(sibling);
                    }
                }
            }

            return node;
        }
    }
}
