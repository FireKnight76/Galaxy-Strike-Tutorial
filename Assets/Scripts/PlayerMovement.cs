using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float controlSpeed = 10f;
    [SerializeField] float xClamp = 5f;
    [SerializeField] float yClamp = 5f;

    [SerializeField] float controllRollFactor = 20f;
    [SerializeField] float controllPitchFactor = 20f;
    [SerializeField] float rotationSpeed = 10f;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ProcessRotation();
    }

    void MovePlayer()
    {
        float xOffset = movement.x * controlSpeed * Time.deltaTime;
        float xRawPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(xRawPos, -xClamp, xClamp);

        float yOffset = movement.y * controlSpeed * Time.deltaTime;
        float yRawPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(yRawPos, -yClamp, yClamp);



        transform.localPosition = new Vector3(clampedXPos, clampedYPos, 0);
        
    }

    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
        
    }
    
    void ProcessRotation()
    {
        float rollShip = -controllRollFactor * movement.x;
        float pitchShip = -controllPitchFactor * movement.y;

        Quaternion targetRotation = Quaternion.Euler(pitchShip, 0f, rollShip);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);
        //transform.localRotation = targetRotation;
    }
}
