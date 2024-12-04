using UnityEngine;
using UnityEngine.InputSystem;

public class CameraScript : MonoBehaviour
{
    private GameObject character;
    private Vector3 s;
    private InputAction lookAction;
    private float angleH, angleH0; 
    private float angleV, angleV0; 

    private float maxHeight = 20f; 
    private float minVerticalAngle = 0f; 
    private float maxVerticalAngle = 90f; 

    void Start()
    {
        character = GameObject.Find("Character"); 
        lookAction = InputSystem.actions.FindAction("Look"); 
        s = this.transform.position - character.transform.position;
        angleH0 = angleH = transform.eulerAngles.y; 
        angleV0 = angleV = transform.eulerAngles.x; 
    }

    void Update()
    {
        
        Vector2 lookValue = lookAction.ReadValue<Vector2>();
        angleH += lookValue.x * 0.05f; 
        angleV -= lookValue.y * 0.05f; 

       
        angleV = Mathf.Clamp(angleV, minVerticalAngle, maxVerticalAngle);     
        this.transform.eulerAngles = new Vector3(angleV, angleH, 0f);
        Vector3 newPosition = character.transform.position +
            Quaternion.Euler(angleV - angleV0, angleH - angleH0, 0f) * s;
        float terrainHeight = Terrain.activeTerrain.SampleHeight(newPosition);
        newPosition.y = Mathf.Clamp(newPosition.y, terrainHeight, maxHeight);
        this.transform.position = newPosition;
    }
}
