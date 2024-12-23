using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] private PlayerConfig _config;
    [SerializeField] private PlayerMediator _mediator;

    [SerializeField] private Transform _playerTransform;

    public PlayerMediator Mediator => _mediator;

    public void Init() {
        _mediator.Init(_config);
    }
}
