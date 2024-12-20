using DG.Tweening;
using System;
using UnityEngine;


public class BikeAnimator : MonoBehaviour
{
    [SerializeField] private float _xOffset = 5f;
    [SerializeField] private float _rotateAngle = 12f;
    [SerializeField] private float _duration;

    [SerializeField] private GameObject _stopLight;

    private Transport _transport;

    private float IsSpeedUp => _transport.IsSpeedUp;
     

    public void Init(Transport transport) {
        _transport = transport;
        _transport.MoveDirectionChanged += OnMoveDirectionChanged;

        ShowStopLight(false);
    }

    private void OnMoveDirectionChanged(MoveDirections directions) {
        if (directions == MoveDirections.Left)
            MoveToLeftAnimationStart(-1);

        if (directions == MoveDirections.Right)
            MoveToLeftAnimationStart(1);

        if (directions == MoveDirections.Forward)
            ShowStopLight(false);

        if (directions == MoveDirections.Back)
            ShowStopLight(true);
    }

    private void MoveToLeftAnimationStart(int k) {

        float currentOffset = _transport.transform.position.x + _xOffset * k;

        Sequence move = DOTween.Sequence();

        move.Append(transform.DOLocalRotate(Vector3.forward * _rotateAngle * -k, _duration));
        move.Append(_transport.transform.DOLocalMoveX(currentOffset, _duration));
        move.Append(transform.DOLocalRotate(Vector3.zero, _duration));
        move.OnComplete(() => 
            _transport.transform.position = new Vector3(currentOffset, _transport.transform.position.y, _transport.transform.position.z));
        
    }

    private void ShowStopLight(bool status) {

        if (status == false || IsSpeedUp == 0) {
            _stopLight.gameObject.SetActive(false);
            return;
        }

        Color currentColor = IsSpeedUp > 0 ? Color.red : Color.white;
        _stopLight.GetComponent<Light>().color = currentColor;

        _stopLight.gameObject.SetActive(true);
    }
}
