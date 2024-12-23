using UnityEngine;

[CreateAssetMenu(fileName = nameof(PlayerConfig), menuName = "Configs/" + nameof(PlayerConfig))]
public class PlayerConfig : ScriptableObject {
    [field: SerializeField] public LayerMask CollectionLayerMask { get; internal set; }
    [field: SerializeField] public float CollectionDistance { get; internal set; }
    [field: SerializeField] public float Damage { get; internal set; }
    [field: SerializeField] public float MoveSpeed { get; internal set; }
    [field: SerializeField] public float ShotPeriod { get; internal set; }
    [field: SerializeField] public float Colldown { get; internal set; }
}

