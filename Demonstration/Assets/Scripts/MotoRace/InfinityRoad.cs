using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinityRoad : MonoBehaviour
{
    [SerializeField] private Transport _transport;

    private Vector3 _startPosition;

    private void Start() {
        _startPosition = _transport.transform.position;
    }

    void Update() {
        float distance = Vector3.Distance(_startPosition, _transport.transform.position);
        
        if (distance > 300f) {
            _transport.transform.position = Vector3.up * 2f;
            distance = 0f;
        }
    }
}
