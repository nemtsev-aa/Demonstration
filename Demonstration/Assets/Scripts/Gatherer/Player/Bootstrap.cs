using UnityEngine;

public class Bootstrap : MonoBehaviour {
    [SerializeField] private Player _player;
    [SerializeField] private ResourceLootSpawner _resourceLootSpawner;
    [SerializeField] private ExperienceManager _experienceManager;

    private void Start() {
        _player.Init();
        _resourceLootSpawner.Init(_player);
        _experienceManager.Init(_player);
    }
}