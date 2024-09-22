using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Collider))]
public class RotateMoveNehaviour : MonoBehaviour
{
    private Vector2 _inputAmount;
    private Collider _collider;
    
    [SerializeField] private float _stepTime = 0;
    [SerializeField] private float _stepTimeDecrease = 0;
    [SerializeField] private float _stepTimeMin = 0.01f;
    private float _stepTimeCurrent = 0;
    private float _pressedTime = 0;
    
    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    private void FixedUpdate()
    {
        if(!_collider.attachedRigidbody.isKinematic)
            return;

        if(_inputAmount.sqrMagnitude <= 0)
        {
            _pressedTime = 0;
            _stepTimeCurrent = _stepTime;
            return;
        }

        _pressedTime += Time.fixedDeltaTime;
        _stepTimeCurrent = Mathf.Max(_stepTimeMin, _stepTimeCurrent - Time.fixedDeltaTime * _stepTimeDecrease);
        if(_pressedTime < _stepTimeCurrent)
            return;
        
        _pressedTime = 0;

        Vector3 rotateDir1 = CustomMath.Sign(new Vector3(-_inputAmount.y, 0, 0));
        transform.RotateAround(transform.position, rotateDir1, 90);

        Vector3 rotateDir2 = CustomMath.Sign(new Vector3(0, 0, _inputAmount.x));
        transform.RotateAround(transform.position, rotateDir2, 90);

        Vector3 extentsUp = Vector3.Scale(_collider.bounds.extents, Vector3.up);
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 50))
            transform.position = hit.point + extentsUp;

        transform.position += Vector3.Scale(new Vector3(-_inputAmount.x, 0, -_inputAmount.y), _collider.bounds.size);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _inputAmount = context.ReadValue<Vector2>();
    }
}
