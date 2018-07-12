using UnityEngine;

namespace Devdog.Rucksack.Items
{
    public sealed class UNetItemFactory : MonoBehaviour
    {
        public UNetItemFactory()
        {
            ItemFactory.binder = new UNetItemFactoryBinder(new UnityLogger("[UNet][Item][Factory] "));
            ItemFactory.Bind<UnityItemDefinition, UNetItemInstance>();
            ItemFactory.Bind<UnityEquippableItemDefinition, UNetEquippableItemInstance>();
        }
    }
}