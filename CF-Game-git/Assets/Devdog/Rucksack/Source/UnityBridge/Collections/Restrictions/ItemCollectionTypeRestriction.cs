using System;
using Devdog.Rucksack.Items;

namespace Devdog.Rucksack.Collections
{
    public sealed class ItemCollectionTypeRestriction : ICollectionRestriction<IItemInstance>
    {
        public readonly Type type;
        public readonly bool allowSubClasses;

        public ItemCollectionTypeRestriction(Type requiredType, bool allowSubClasses = true)
        {
            this.type = requiredType;
            this.allowSubClasses = allowSubClasses;
        }
        
        public Result<bool> CanAdd(IItemInstance item, CollectionContext context)
        {
            if (allowSubClasses)
            {
                if (item?.GetType().IsSubclassOf(type) == false)
                {
                    return new Result<bool>(false, Errors.CollectionRestrictionPreventedAction);
                }
            }
            else
            {
                if (item?.GetType() != type)
                {
                    return new Result<bool>(false, Errors.CollectionRestrictionPreventedAction);
                }
            }
            
            return true;
        }

        public Result<bool> CanRemove(IItemInstance item, CollectionContext context)
        {
            return true;
        }
    }
}