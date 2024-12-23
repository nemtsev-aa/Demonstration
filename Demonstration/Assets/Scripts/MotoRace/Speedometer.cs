using UnityEngine;

public class Speedometer : MonoBehaviour
{
    [SerializeField] private RectTransform _arrowTransform;
    [SerializeField] private float _maxAngle = 110f;

    [SerializeField] private Transport _transport;

    private void Awake() {
        if (_transport != null)
            Init(_transport);
    }

    public void Init(Transport transport) {
        _transport = transport;
        _transport.VelocityChanged += OnVelocityChanged;

        OnVelocityChanged(0);
    }

    private void OnVelocityChanged(float percent) {
        if (percent <= 0) {
            _arrowTransform.localEulerAngles = (Vector3.forward * -_maxAngle);
            return;
        }

        var currentAngle = -_maxAngle + (_maxAngle * 2 * percent);
        _arrowTransform.localEulerAngles = (Vector3.forward * currentAngle);
    }
}
