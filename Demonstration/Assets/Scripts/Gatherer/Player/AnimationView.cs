using UnityEngine;

public class AnimationView : MonoBehaviour {
    private const string RUN = "Run";
    private const string MOVE_SPEED = "Speed_f";
    private const string STATIC_POSITION = "Static_b";
    private const string MELEE_ATTACK = "MeleeAttack_t";

    [SerializeField] private Animator _animator;

    private void Awake() {
        _animator ??= GetComponentInChildren<Animator>();
    }

    public void Run(float speed) {
        _animator.SetBool(STATIC_POSITION, false);
        _animator.SetFloat(MOVE_SPEED, speed);
    }

    public void Attack() {
        _animator.SetBool(STATIC_POSITION, true);
        _animator.SetTrigger(MELEE_ATTACK);
    }
}

