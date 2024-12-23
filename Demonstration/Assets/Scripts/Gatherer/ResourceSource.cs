using UnityEngine;

public class ResourceSource : MonoBehaviour {
    [SerializeField] private ResourceConfig _config;
    [SerializeField] private int _amount;
    
    public Resource Resource { get; private set; }

    private void Start() {
        if (_config != null && _amount != 0) {
            Resource = new Resource(_config, _amount);
        }    
    }
}
