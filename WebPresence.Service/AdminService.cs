using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebPresence.Data;
using WebPresence.Data.Interfaces;
using WebPresence.Domain.Model;
using WebPresence.Service.Interfaces;
using WebPresence.Presentation.ViewModels.ContentMenu;

namespace WebPresence.Service
{
    public class AdminService : IAdminService
    {
        private readonly IBaseDataRepository<Item> _itemRepository;

        public AdminService()
        {
            AdminStartUp.StartupOnce();

            _itemRepository = new BaseDataRepository<Item>();
        }

        public ContentTree GetContentTree()
        {

            ContentTree contentTree = new ContentTree();

            List<Item> contentItems = _itemRepository.GetAll().ToList();

            if (contentItems == null)
                return null;

            ParentNode parentNode = null;

            contentTree.ContentTreeNodes = new List<ParentNode>();            

            foreach (Item contentItem in contentItems)
            {
				
                if (contentItem.IsParentItem)
                {
                    parentNode = new ParentNode();

					parentNode.IsContentNode = contentItem.ParentItemId.HasValue ? false : true;

                    parentNode.NodeName = contentItem.DisplayName;
                    parentNode.NodeId = contentItem.Id;
                    parentNode.ChildNodes = new List<ChildNode>();
                }

                if (contentItem.IsParentItem)
                {
                    foreach (Item childNode in contentItems)
                    {
                        if (parentNode != null)
                        {
                            if (childNode.ParentItemId.HasValue )
                            {
                                if (childNode.ParentItemId.Value == parentNode.NodeId)
                                {
                                    ChildNode node = new ChildNode();

                                    node.Id = childNode.Id;
                                    node.ParentItemId = childNode.ParentItemId.Value;
                                    node.ItemTypeId = childNode.ItemTypeId;
                                    node.ItemName = childNode.ItemName;
                                    node.DisplayName = childNode.DisplayName;
                                    node.Created = childNode.Created;
                                    node.ContentOwner = childNode.ContentOwner;

                                    parentNode.ChildNodes.Add(node);
                                }
                            }
                        }
                    }

                    contentTree.ContentTreeNodes.Add(parentNode);
                }
            }

            return contentTree;
        }
    }
}
