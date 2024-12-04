using UnityEngine;
using UnityEngine.InputSystem;
public class CharacterScript : MonoBehaviour
{
    private InputAction moveAction;
    private CharacterController characterController;
    private float speedFactorGrounded = 5f; 
    private float speedFactorAirborne = 10f; 
    private float maxHeight = 20.0f;
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        characterController = GetComponent<CharacterController>();
    }
    void Update()
    {
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        Vector3 move = Camera.main.transform.forward;  
        move.y = 0.0f;  
        if (move == Vector3.zero)  
        {
            move = Camera.main.transform.up;  
        }
        move.Normalize();  
        Vector3 moveForward = move;
        move += moveValue.x * Camera.main.transform.right;

        bool isGrounded = characterController.isGrounded;
        float currentSpeed = isGrounded ? speedFactorGrounded : speedFactorAirborne;

        if (Keyboard.current.shiftKey.isPressed)
        {
            currentSpeed += 3f;
        }

        if (transform.position.y < maxHeight)
        {
            move.y = moveValue.y;
        }
        move.y -= 30f * Time.deltaTime;
        
        characterController.Move(currentSpeed * Time.deltaTime * move);
        this.transform.forward = moveForward;
    }
}