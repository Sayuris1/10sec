using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Collider))]
public class RotateFlyBehaviour : MonoBehaviour
{
    private Vector2 _inputAmount;
    private Vector2 _lastInputAmount;
    private Collider _collider;
    
    private Vector3 _currentRot = Vector3.zero;

    [SerializeField] private float _upSpeed = 0;
    [SerializeField] private float _stepTime = 0;
    [SerializeField] private float _stepTimeDecrease = 0;
    [SerializeField] private float _stepTimeMin = 0.01f;
    private float _stepTimeCurrent = 0;
    private float _notPressedTime = 0;
    
    private void Awake()
    {
        _collider = GetComponent<Collider>();

        _stepTimeCurrent = _stepTime;
        _lastInputAmount = Vector2.up;
    }

    private void FixedUpdate()
    {
        if(!_collider.attachedRigidbody.isKinematic)
            return;

        if(_inputAmount.sqrMagnitude > 0)
        {
            _notPressedTime = 0;
            _stepTimeCurrent = _stepTime;

            // Go up part
            Vector3 rotateDir1 = CustomMath.Sign(new Vector3(-_inputAmount.y, 0, 0));
            transform.RotateAround(transform.position, rotateDir1, 90);

            Vector3 rotateDir2 = CustomMath.Sign(new Vector3(0, 0, _inputAmount.x));
            transform.RotateAround(transform.position, rotateDir2, 90);

            transform.position += Vector3.Scale(new Vector3(-_inputAmount.x, 0, -_inputAmount.y), _collider.bounds.size);
            transform.position += Vector3.Scale(new Vector3(0, _upSpeed, 0), _collider.bounds.size);

            _lastInputAmount = _inputAmount;
            _inputAmount = Vector2.zero;
            return;
        }

        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 1))
            return;

        // Fall down part
        _notPressedTime += Time.fixedDeltaTime;
        if(_notPressedTime < _stepTimeCurrent)
            return;

        _stepTimeCurrent = Mathf.Max(_stepTimeMin, _stepTimeCurrent - Time.fixedDeltaTime * _stepTimeDecrease);
        _notPressedTime = 0;

        Vector3 rotateDirDown1 = CustomMath.Sign(new Vector3(-_lastInputAmount.y, 0, 0));
        transform.RotateAround(transform.position, rotateDirDown1, 90);

        Vector3 rotateDirDown2 = CustomMath.Sign(new Vector3(0, 0, _lastInputAmount.x));
        transform.RotateAround(transform.position, rotateDirDown2, 90);

        transform.position += Vector3.Scale(_collider.bounds.size, Vector3.down);
        transform.position += Vector3.Scale(new Vector3(-_lastInputAmount.x, 0, -_lastInputAmount.y), _collider.bounds.size);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _inputAmount = context.ReadValue<Vector2>();
    }
}
