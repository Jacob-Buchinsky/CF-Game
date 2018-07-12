using System;

namespace Devdog.Rucksack.Collections
{
    public sealed class CollectionGroupRemoveResult<T>
        where T : IEquatable<T>
    {
        public ICollection<T> collection { get; }
        public SlotAmount[] affectedSlots { get; }

        public CollectionGroupRemoveResult(ICollection<T> collection, SlotAmount[] affectedSlots)
        {
            this.collection = collection;
            this.affectedSlots = affectedSlots;
        }
    }
}