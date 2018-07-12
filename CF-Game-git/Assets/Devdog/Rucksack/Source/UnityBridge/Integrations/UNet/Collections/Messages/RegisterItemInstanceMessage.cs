using System;
using Devdog.General2;
using Devdog.Rucksack.Database;
using Devdog.Rucksack.Items;
using UnityEngine.Networking;

namespace Devdog.Rucksack.Collections
{
    public sealed class RegisterItemInstanceMessage : MessageBase
    {
        public GuidMessage itemGuid;
        public GuidMessage itemDefinitionGuid;
        public string serializedData;
        public string itemInstanceAssemblyQualifiedTypeName;

        // TODO: Consider creating a lookup table for item types to avoid sending type over the network
        public Type itemType
        {
            get { return Type.GetType(itemInstanceAssemblyQualifiedTypeName); }
        }

        public RegisterItemInstanceMessage()
            : this(null)
        {

        }

        public RegisterItemInstanceMessage(IItemInstance itemInstance)
        {
            if (itemInstance != null)
            {
                itemGuid = itemInstance.ID;
                itemDefinitionGuid = itemInstance.itemDefinition.ID;
                serializedData = ""; // TODO: Set Serializable data
                itemInstanceAssemblyQualifiedTypeName = itemInstance.GetType().AssemblyQualifiedName; // TODO: Make lookup table for item types.
            }
            else
            {
                itemGuid = Guid.Empty;
                itemDefinitionGuid = Guid.Empty;
                serializedData = "";
                itemInstanceAssemblyQualifiedTypeName = "";
            }
        }
        
        public IItemInstance TryCreateItemInstance(IDatabase<UnityItemDefinition> database, ILogger logger = null)
        {
            logger = logger ?? new NullLogger();

            if (string.IsNullOrEmpty(itemInstanceAssemblyQualifiedTypeName) || itemType == null)
            {
                logger.Error($"Couldn't register item instance with ID: {itemGuid.guid} - Requested item type {itemInstanceAssemblyQualifiedTypeName} does not exist in assembly");
                return null;
            }

            logger.LogVerbose($"[Client] Server sent a new item instance with guid:\n {itemGuid.guid}\n and item definition guid:\n {itemDefinitionGuid}");
            var itemDef = database.Get(new Identifier(itemDefinitionGuid.guid));
            if (itemDef.error != null)
            {
                logger.Log($"ItemDefinition with guid {itemDefinitionGuid} not found on local client!", itemDef.error);
                return null;
            }

            var instance = ItemFactory.CreateInstance(itemDef.result, itemGuid.guid);
            if (string.IsNullOrEmpty(serializedData) == false)
            {
                JsonSerializer.DeserializeTo(instance, itemType, serializedData, null);
            }
            
            return instance;
        }
        
        public override string ToString()
        {
            return $"RegisterItemInstanceMessage - {serializedData} - {itemInstanceAssemblyQualifiedTypeName}";
        }
    }
}