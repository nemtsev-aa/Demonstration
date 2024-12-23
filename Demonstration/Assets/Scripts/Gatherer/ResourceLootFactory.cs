using UnityEngine;

[CreateAssetMenu(fileName = nameof(ResourceLootFactory), menuName = "Factories/" + nameof(ResourceLootFactory))]
public class ResourceLootFactory : ScriptableObject {
    [SerializeField] private ResourceLootPrefabs _prefabs;

    public ResourceLoot Get(ResourceConfig config) {
        ResourceLoot prefab = _prefabs.GetPrefabByName(config.Name);

        ResourceLoot newLoot = Instantiate(prefab);
        newLoot.Init(new Resource(config, 1));

        return newLoot;
    }
}
