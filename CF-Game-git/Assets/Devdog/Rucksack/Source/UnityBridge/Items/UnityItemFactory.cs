using UnityEngine;

namespace Devdog.Rucksack.Items
{
    public sealed class UnityItemFactory : MonoBehaviour
    {

        public UnityItemFactory()
        {
            ItemFactory.binder = new DefaultItemFactoryBinder(new UnityLogger("[Item][Factory] "));
            ItemFactory.Bind<UnityItemDefinition, UnityItemInstance>();
            ItemFactory.Bind<UnityEquippableItemDefinition, UnityEquippableItemInstance>();
        }
    }
}