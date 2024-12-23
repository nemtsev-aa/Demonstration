using UnityEngine;
using System;

[Serializable]
public class ResourceLootPrefab {
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public ResourceLoot Loot { get; private set; }
}
