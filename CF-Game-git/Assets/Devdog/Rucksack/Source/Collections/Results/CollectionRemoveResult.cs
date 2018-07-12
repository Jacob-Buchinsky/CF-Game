using System;

namespace Devdog.Rucksack.Collections
{
    public sealed class CollectionRemoveResult : EventArgs
    {
        public SlotAmount[] affectedSlots { get; }
        public CollectionRemoveResult(SlotAmount[] affectedSlots)
        {
            this.affectedSlots = affectedSlots;
        }
    }
}