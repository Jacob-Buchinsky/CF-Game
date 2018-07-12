//using UnityEngine;
//
//namespace Devdog.Rucksack.CharacterEquipment
//{
//    public sealed class UNetExternalEquippableCharacter : MonoBehaviour, IEquippableCharacter<GameObject>
//    {
//        private IMountPoint<GameObject>[] _mountPoints = new IMountPoint<GameObject>[0];
//        public IMountPoint<GameObject>[] mountPoints
//        {
//            get { return _mountPoints; }
//            set { _mountPoints = value; }
//        }
//
//        private readonly ILogger logger;
//        public UNetExternalEquippableCharacter()
//        {
//            logger = new UnityLogger("[UNet][EquippableCharacter] ");
//        }
//        
//        private void Awake()
//        {
//            UpdateMountPoints();
//        }
//
//        private void OnEnable()
//        {
//            UpdateMountPoints();
//        }
//        
//#if UNITY_EDITOR
//        
//        protected virtual void OnValidate()
//        {
//            UpdateMountPoints();
//        }
//    
//#endif
//        
//        public void UpdateMountPoints()
//        {
//            mountPoints = GetComponentsInChildren<IMountPoint<GameObject>>(true);
//        }
//        
//        public IMountPoint<GameObject> GetMountPoint(string mountPointName)
//        {
//            foreach (var mountPoint in mountPoints)
//            {
//                if (mountPoint.name == mountPointName)
//                {
//                    return mountPoint;
//                }
//            }
//
//            return null;
//        }
//
////        public IEnumerable<GameObject> GetAll()
////        {
////            foreach (var mountPoint in mountPoints)
////            {
////                yield return mountPoint.hasMountedItem
////            }
////        }
//
////        public GameObject Get(int index)
////        {
////            return equippableCharacter.Get(index);
////        }
//
//        public Result<bool> Equip(GameObject item, int amount = 1)
//        {
//            foreach (var mountPoint in mountPoints)
//            {
//                if(mountPoint.)
//            }
//            
//            mountPoints[].Mount(item);
//            return true;
//        }
//
//        public Result<bool> EquipAt(int index, GameObject item, int amount = 1)
//        {
//            mountPoints[index].Mount(item);
//            return true;
//        }
//
//        public Result<bool> UnEquip(GameObject item, int amount = 1)
//        {
//            mountPoints[].Clear();
//            return true;
//        }
//
//        public Result<bool> UnEquipAt(int index, int amount = 1)
//        {
//            mountPoints[index].Clear();
//            return true;
//        }
//
//        public override string ToString()
//        {
//            return name;
//        }
//    }
//}