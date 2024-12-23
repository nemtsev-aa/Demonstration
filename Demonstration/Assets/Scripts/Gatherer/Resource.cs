using UnityEngine;

public class Resource : MonoBehaviour {
    [field: SerializeField] public ResourceConfig Config { get; private set; }
    [field: SerializeField] public int Amount { get; private set; }

    public Resource(ResourceConfig config, int amount) {
        Config = config;
        Amount = amount;
    }
}
