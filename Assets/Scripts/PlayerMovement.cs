using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float controlSpeed = 10f;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float offsetX = movement.x * controlSpeed * Time.deltaTime;
        float offsetY = movement.y * controlSpeed * Time.deltaTime;

        transform.localPosition = new Vector3(transform.localPosition.x + offsetX, transform.localPosition.y + offsetY, 0);
        
    }

    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
        
    }
}
