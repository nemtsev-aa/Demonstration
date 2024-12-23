using UnityEngine;

public class ExperienceLoot : Loot {
    [field: SerializeField] public int ExperienceValue { get; private set; }

    public override void Take() {
        base.Take();
    }
}
