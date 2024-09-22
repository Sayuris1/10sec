using UnityEngine;
using UnityEngine.InputSystem;

public class MoveNehaviour : MonoBehaviour
{
    private Vector2 _inputAmount;
    [SerializeField] private Vector2 _speed;
    [SerializeField] private bool _isUpDown;

    private void Update()
    {
        Vector2 moveAmount = _inputAmount * _speed * Time.deltaTime;

        Vector3 addPos = new(moveAmount.x, moveAmount.y, moveAmount.y);
        if(_isUpDown)
            addPos.z = 0;
        else
            addPos.y = 0;

        transform.position += addPos;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _inputAmount = context.ReadValue<Vector2>();
    }
}
