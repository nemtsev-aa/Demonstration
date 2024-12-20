using System.Collections.Generic;
using UnityEngine;

public class CameraViewManager : MonoBehaviour {
    
    [SerializeField] private Camera _camera;
    [SerializeField] private List<Transform> _views;

    private int _currentViewIndex = -1;

    public int CurrentViewIndex => _currentViewIndex;

    void Start() {
         SwitchView();
    }
    
    public void SwitchView() {
        if (_views.Count == 0) {
            Debug.Log("Views list is empty!");
            return;
        }

        _currentViewIndex++;

        if (_currentViewIndex >= _views.Count) 
            _currentViewIndex = 0;
        
        _camera.transform.position = _views[_currentViewIndex].transform.position;
        _camera.transform.rotation = _views[_currentViewIndex].transform.rotation;
    }
}
