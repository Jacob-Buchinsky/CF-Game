using Devdog.General2;
using Devdog.Rucksack.CharacterEquipment.Items;
using Devdog.Rucksack.Characters;
using Devdog.Rucksack.Collections;
using Devdog.Rucksack.Items;
using UnityEngine;

namespace Devdog.Rucksack.CharacterEquipment
{
    public class UnityEquippableCharacter : MonoBehaviour, IEquippableCharacter<IEquippableItemInstance>
    {
        public IMountPoint<IEquippableItemInstance>[] mountPoints
        {
            get { return equippableCharacter.mountPoints; }
            set { equippableCharacter.mountPoints = value; }
        }

        protected EquippableCharacter<IItemInstance, IEquippableItemInstance> equippableCharacter;

        [Required]
        [SerializeField]
        protected string collectionName;
        protected readonly ILogger logger;

        public UnityEquippableCharacter()
        {
            logger = new UnityLogger("[EquippableCharacter] ");
        }
        
        protected virtual void Awake()
        {
            equippableCharacter = new EquippableCharacter<IItemInstance, IEquippableItemInstance>(null, GetComponent<IInventoryCollectionOwner>().itemCollectionGroup, logger);
            UpdateMountPoints();
        }

        protected virtual void OnEnable()
        {
            var col = FindEquipmentCollection();
            if (col != null)
            {
                SetEquippableCharacter(col);
                UpdateMountPoints();
                RefreshAllMountedObjects();
            }
            else
            {
                logger.Warning($"Couldn't find EquipmentCollection for {nameof(UnityEquippableCharacter)}", this);
            }
        }

        protected virtual EquipmentCollection<IEquippableItemInstance> FindEquipmentCollection()
        {
            return CollectionRegistry.byName.Get(collectionName) as EquipmentCollection<IEquippableItemInstance>;
        }

        protected virtual void OnDisable()
        {
        }
        
        protected virtual void SetEquippableCharacter(EquipmentCollection<IEquippableItemInstance> collection)
        {
            collection.characterOwner = this;
            
            equippableCharacter.collection = collection;
            equippableCharacter.mountPoints = mountPoints;
            equippableCharacter.restoreItemsToGroup = GetComponent<IInventoryCollectionOwner>().itemCollectionGroup;
        }
        
#if UNITY_EDITOR
        
        protected virtual void OnValidate()
        {
            equippableCharacter = new EquippableCharacter<IItemInstance, IEquippableItemInstance>(null, GetComponent<IInventoryCollectionOwner>().itemCollectionGroup, logger);
            UpdateMountPoints();
        }
    
#endif
        
        public virtual void UpdateMountPoints()
        {
            equippableCharacter.mountPoints = GetComponentsInChildren<IMountPoint<IEquippableItemInstance>>(true);
        }
        
        protected virtual IMountPoint<IEquippableItemInstance> GetMountPoint(IEquippableItemInstance item)
        {
            foreach (var mountPoint in mountPoints)
            {
                if (mountPoint.name == item.itemDefinition.mountPoint)
                {
                    return mountPoint;
                }
            }

//            return equippableCharacter.GetMountPoint(mountPointName);
            return null;
        }

        public void RefreshAllMountedObjects()
        {
            for (var i = 0; i < equippableCharacter.mountPoints.Length; i++)
            {
                var mountPoint = equippableCharacter.mountPoints[i];
                var item = equippableCharacter.Get(i);

                mountPoint.Clear();
                if (item != null)
                {
                    mountPoint.Mount(item);
                }
            }
        }

        public virtual Result<bool> Equip(IEquippableItemInstance item, int amount = 1)
        {
            var equipped = equippableCharacter.Equip(item, amount);
            if (equipped.error == null)
            {
                var mountPoint = GetMountPoint(item);
                mountPoint?.Clear();
                mountPoint?.Mount(item);
            }

            return equipped;
        }

        public virtual Result<bool> EquipAt(int index, IEquippableItemInstance item, int amount = 1)
        {
            var equipped = equippableCharacter.EquipAt(index, item, amount);
            if (equipped.error == null)
            {
                var mountPoint = GetMountPoint(item);
                mountPoint?.Clear();
                mountPoint?.Mount(item);
            }

            return equipped;
        }

        public virtual Result<bool> UnEquip(IEquippableItemInstance item, int amount = 1)
        {
            var unEquipped = equippableCharacter.UnEquip(item, amount);
            if (unEquipped.error == null)
            {
                var mountPoint = GetMountPoint(item);
                mountPoint?.Clear();
            }

            return unEquipped;
        }

        public virtual Result<bool> UnEquipAt(int index, int amount = 1)
        {
            var unEquipped = equippableCharacter.UnEquipAt(index, amount);
            if (unEquipped.error == null)
            {
                var mountPoint = GetMountPoint(equippableCharacter.collection[index]);
                mountPoint?.Clear();
            }

            return unEquipped;
        }

        public Result<bool> SwapOrMerge(int from, int to)
        {
            return equippableCharacter.SwapOrMerge(from, to);
        }

        public override string ToString()
        {
            return name;
        }
    }
}