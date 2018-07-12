using Devdog.Rucksack.CharacterEquipment.Items;
using Devdog.Rucksack.Collections;

namespace Devdog.Rucksack.CharacterEquipment
{
    public class UNetEquippableCharacter : UnityEquippableCharacter
    {
        private ServerCollectionRegistryFinder<EquipmentCollection<IEquippableItemInstance>> _finder;
        
        protected override void OnEnable()
        {
            _finder = new ServerCollectionRegistryFinder<EquipmentCollection<IEquippableItemInstance>>(collectionName);
            _finder.OnCollectionChanged += FinderOnOnCollectionChanged;
            base.OnEnable();
        }

        protected override void OnDisable()
        {
            _finder.OnCollectionChanged -= FinderOnOnCollectionChanged;
            base.OnDisable();
        }

        private void FinderOnOnCollectionChanged(EquipmentCollection<IEquippableItemInstance> before, EquipmentCollection<IEquippableItemInstance> after)
        {
            if (after != null)
            {
                SetEquippableCharacter(after);
                UpdateMountPoints();
                RefreshAllMountedObjects();
            }
        }
        
        protected override EquipmentCollection<IEquippableItemInstance> FindEquipmentCollection()
        {
            return ServerCollectionRegistry.byName.Get(collectionName) as EquipmentCollection<IEquippableItemInstance>;
        }
    }
}