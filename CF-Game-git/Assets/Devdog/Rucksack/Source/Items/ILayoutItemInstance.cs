using System;

namespace Devdog.Rucksack.Items
{
    public interface ILayoutItemInstance : IItemInstance, IShapeOwner2D, IComparable<ILayoutItemInstance>, IEquatable<ILayoutItemInstance>
    {
        
    }
}