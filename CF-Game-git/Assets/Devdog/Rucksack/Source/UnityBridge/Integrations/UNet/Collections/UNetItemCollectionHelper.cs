using System;
using Devdog.Rucksack.UI;
using Devdog.Rucksack.Items;
using UnityEngine;

namespace Devdog.Rucksack.Collections
{
    public class UNetItemCollectionHelper : MonoBehaviour
    {
        [SerializeField]
        protected string collectionName;

        [SerializeField]
        protected UnityItemDefinition itemDef;
        
        [SerializeField]
        protected UnityEquippableItemDefinition equippableItemDef;
        
        protected readonly ILogger logger;
        public UNetItemCollectionHelper()
        {
            logger = new UnityLogger("[Collection][Helper] ");
        }

        protected virtual ICollection<IItemInstance> GetCollection()
        {
            var collection = ServerCollectionRegistry.byName.Get(collectionName) as ICollection<IItemInstance>;
            if (collection != null)
            {
                return collection;
            }
            
            logger.Warning($"Couldn't find collection with name {collectionName}", this);
            return null;
        }
        
        public void AddItem()
        {
            var collection = GetCollection();
            var inst = ItemFactory.CreateInstance(itemDef, System.Guid.NewGuid());
            
            var added = collection.Add(inst);
            if (added.error != null)
            {
                logger.Error("Failed to add item to collection", added.error, this);
            }
        }
        
        public void AddEquippableItem()
        {
            var collection = GetCollection();
            var inst = ItemFactory.CreateInstance(equippableItemDef, Guid.NewGuid());

            var added = collection.Add(inst);
            if (added.error != null)
            {
                logger.Error("Failed to add item to collection", added.error, this);
            }
        }

        public void ToggleReadOnly()
        {
            var collection = (CollectionBase<CollectionSlot<IItemInstance>, IItemInstance>)GetCollection();
            collection.isReadOnly = !collection.isReadOnly;
        }
    }
}