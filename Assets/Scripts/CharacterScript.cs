using UnityEngine;
using UnityEngine.InputSystem;
public class CharacterScript : MonoBehaviour
{
    private InputAction moveAction;
    private CharacterController characterController;
    private float speedFactor = 5f;
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        characterController = GetComponent<CharacterController>();
    }
    void Update()
    {
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        characterController.Move(speedFactor * Time.deltaTime * moveValue);
        Debug.Log(this.transform.position.y -
            Terrain.activeTerrain.SampleHeight(this.transform.position));
    }
}