using System;
using UnityEditor;
using UnityEngine;

public class Collector : MonoBehaviour {
    public event Action<Loot> LootCollected;

    private PlayerConfig _config;
  
    public bool IsActive { get; private set; } = false;

    private float DistanceToCollect { 
        get {
            if (_config != null)
                return _config.CollectionDistance;

            return 1f;
        }    
    } 

    private LayerMask _layerMask => _config.CollectionLayerMask;

    public void Init(PlayerConfig config) {
        _config = config;
        IsActive = true;
    }

    private void FixedUpdate() {
        if (IsActive == false)
            return;

        Collider[] colliders = Physics.OverlapSphere(transform.position, DistanceToCollect, _layerMask, QueryTriggerInteraction.Ignore);
        
        for (int i = 0; i < colliders.Length; i++) {

            if (colliders[i].TryGetComponent(out Loot loot)) {
                loot.Collect(this);

                LootCollected?.Invoke(loot);
            }    
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected() {
        Handles.color = Color.yellow;
        Handles.DrawWireDisc(transform.position, Vector3.up, DistanceToCollect);
    }
#endif
}
