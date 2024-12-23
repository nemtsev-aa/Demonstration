using UnityEngine;
using System;
using DG.Tweening;

public class ResourceLootSpawner : MonoBehaviour, IDisposable {
    [SerializeField] private ResourceLootFactory _lootFactory;
    [SerializeField] private float _spawnRadius = 1f;

    private Player _player;


    public void Init(Player player) {
        _player = player;
        _player.Mediator.ResourceSourceDestroyed += OnResourceSourceDestroyed;
    }

    private void OnResourceSourceDestroyed(ResourceSource source) {
        for (int i = 0; i < source.Resource.Amount; i++) {
            Vector3 spawnPosition = source.transform.position + UnityEngine.Random.insideUnitSphere * _spawnRadius;
            spawnPosition.y = 0;

            Loot newLoot = _lootFactory.Get(source.Resource.Config);

            newLoot.transform.DOJump(spawnPosition, 3f, 3, 1f, true);
        }
    }

    public void Dispose() {
        _player.Mediator.ResourceSourceDestroyed -= OnResourceSourceDestroyed;
    }
}