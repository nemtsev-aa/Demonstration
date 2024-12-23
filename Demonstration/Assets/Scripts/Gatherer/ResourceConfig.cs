using UnityEngine;

[CreateAssetMenu(fileName = nameof(ResourceConfig), menuName = "ResourceConfigs/" + nameof(ResourceConfig))]
public class ResourceConfig : ScriptableObject {
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public Sprite IconToUI { get; private set; }

}
