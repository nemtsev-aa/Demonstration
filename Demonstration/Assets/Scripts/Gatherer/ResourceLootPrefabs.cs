using UnityEngine;
using System.Collections.Generic;
using System.Linq;

[CreateAssetMenu(fileName = nameof(ResourceLootPrefabs), menuName = "Factories/" + nameof(ResourceLootPrefabs))]
public class ResourceLootPrefabs : ScriptableObject {
    [field: SerializeField] public List<ResourceLootPrefab> LootPrefabs { get; private set; }

    public ResourceLoot GetPrefabByName(string name) {
        return LootPrefabs.FirstOrDefault(loot => loot.Name == name).Loot;
    }
}
