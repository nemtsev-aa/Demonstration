using UnityEngine;

public class InputHandler : MonoBehaviour {
    private const KeyCode VIEW_SELECTOR = KeyCode.V;
    private const KeyCode FORWARD_MOVE = KeyCode.W;
    private const KeyCode BACK_MOVE = KeyCode.S;
    private const KeyCode LEFT_MOVE = KeyCode.A;
    private const KeyCode RIGHT_MOVE = KeyCode.D;

    [SerializeField] private CameraViewManager _cameraViewManager;
    [SerializeField] private Transport _transport;

    void Update()
    {
        if (Input.GetKeyDown(VIEW_SELECTOR))
            _cameraViewManager.SwitchView();

        if (Input.GetKeyDown(LEFT_MOVE))
            _transport.LeftMove();

        if (Input.GetKeyDown(RIGHT_MOVE))
            _transport.RightMove();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(FORWARD_MOVE))
            _transport.ForwardMove(1);

        if (Input.GetKey(BACK_MOVE))
            _transport.ForwardMove(-2);

    }
}
