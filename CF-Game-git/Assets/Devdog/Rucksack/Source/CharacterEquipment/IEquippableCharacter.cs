
using System;

namespace Devdog.Rucksack.CharacterEquipment
{
    public interface IEquippableCharacter<in TEquippableItemType>
        where TEquippableItemType : IEquatable<TEquippableItemType>
    {
        Result<bool> Equip(TEquippableItemType item, int amount = 1);
        Result<bool> EquipAt(int index, TEquippableItemType item, int amount = 1);
        Result<bool> UnEquip(TEquippableItemType item, int amount = 1);
        Result<bool> UnEquipAt(int index, int amount = 1);

        Result<bool> SwapOrMerge(int from, int to);
    }
}