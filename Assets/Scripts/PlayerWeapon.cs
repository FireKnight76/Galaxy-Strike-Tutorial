using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] lasers;
    [SerializeField] RectTransform crosshair;
    [SerializeField] Transform targetPoint;

    [SerializeField] float targetDistance = 100f;

   bool isFiring = false;

    private void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessFiring();
        MoveCrosshair();
        MoveTargetPoint();
        AimLasers();
    }

    void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }

    void ProcessFiring()
    {
        foreach (var laser in lasers)
        {
            var emmissionModule = laser.GetComponent<ParticleSystem>().emission;
            emmissionModule.enabled = isFiring;
        }

    }

    void MoveCrosshair()
    {
        crosshair.position = Mouse.current.position.ReadValue();
    }

    void MoveTargetPoint()
    {
        Vector3 targetPointPosition = new Vector3(Mouse.current.position.x.ReadValue(), Mouse.current.position.y.ReadValue(), targetDistance);

        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition);
    }

    void AimLasers()
    {
        foreach(var laser in lasers)
        {
            Vector3 fireDirection = targetPoint.position - transform.position;
            Quaternion rotationToTarget = Quaternion.LookRotation(fireDirection);
            laser.transform.rotation = rotationToTarget;
        }
    }

}
