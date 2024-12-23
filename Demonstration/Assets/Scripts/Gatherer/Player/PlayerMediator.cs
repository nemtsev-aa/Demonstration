using System;
using UnityEngine;

public class PlayerMediator : MonoBehaviour, IDisposable {
    public event Action<ResourceSource> ResourceSourceDestroyed;
    public event Action<ExperienceLoot> ExperienceLootCollected;
    public event Action<ResourceLoot> ResourceLootCollected;

    [SerializeField] private DynamicJoystick _joystick;
    
    private PlayerConfig _config;

    [field: SerializeField] public RigidbodyMove RigidbodyMove { get; private set; }
    [field: SerializeField] public Collector Collector { get; private set; }
    [field: SerializeField] public AnimationView AnimationView { get; private set; }

    public void Init(PlayerConfig config) {
        _config = config;

        RigidbodyMove.Init(_config, _joystick);
        RigidbodyMove.MoveStatusChanged += OnMoveStatusChanged;
        RigidbodyMove.MoveSpeedChanged += OnMoveSpeedChanged;

        Collector.Init(_config);
        Collector.LootCollected += OnLootCollected;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space))
            AnimationView.Attack();
    }

    private void OnMoveStatusChanged(MoveStatus status) {
        bool move = (status == MoveStatus.Active) ? true : false;

    }

    private void OnMoveSpeedChanged(float currentSpeed) {
        AnimationView.Run(currentSpeed);
    }


    private void OnLootCollected(Loot loot) {
        if (loot is ExperienceLoot) {
            ExperienceLoot exp = (ExperienceLoot)loot;

            ExperienceLootCollected?.Invoke(exp);
        }

        if (loot is ResourceLoot) {
            ResourceLoot resource = (ResourceLoot)loot;

            ResourceLootCollected?.Invoke(resource);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.gameObject.TryGetComponent(out ResourceSource resourceSource)) {
            Debug.Log($"ResourceSource: {resourceSource}");
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.TryGetComponent(out ResourceSource resourceSource)) {
            Debug.Log($"ResourceSource: {resourceSource}");

            ResourceSourceDestroyed?.Invoke(resourceSource);
        }
    }

    public void Dispose() {
        RigidbodyMove.MoveStatusChanged -= OnMoveStatusChanged;
        RigidbodyMove.MoveSpeedChanged -= OnMoveSpeedChanged;

        Collector.LootCollected -= OnLootCollected;
    }

}

