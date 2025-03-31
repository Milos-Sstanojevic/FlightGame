using UnityEngine;
using UnityEngine.InputSystem;

public class AircraftBase : MonoBehaviour
{
    [SerializeField] protected float forwardSpeed;
    [SerializeField] protected float upSpeed;
    [SerializeField] protected float turningSpeed;
    [SerializeField] protected float maxTiltAngleSide = 70;
    [SerializeField] protected float maxTiltAngleUp = 40;
    [SerializeField] protected float tiltSpeed = 5f;
    [SerializeField] protected GameObject aircraftModel;

    protected Vector3 movement = new Vector3(0, 0, 0);
    protected Transform playerTransform;
    protected Transform aircraftTransform;
    protected int tiltDirection = 0;

    public void Movement(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector3>();
    }

    private void Awake()
    {
        playerTransform = transform;
        aircraftTransform = aircraftModel.transform;
    }

    public void Update()
    {
        ApplyTilting();
    }

    private void ApplyTilting()
    {
        float currentTiltHorizontal = aircraftTransform.localEulerAngles.z;
        float currentTiltVertical = aircraftTransform.localEulerAngles.x;

        if (currentTiltHorizontal > 180) currentTiltHorizontal -= 360;
        if (currentTiltVertical > 180) currentTiltVertical -= 360;

        float targetTiltHorizontal = movement.x * -maxTiltAngleSide;
        float targetTiltVertical = tiltDirection * -maxTiltAngleUp;

        float newTiltHorizontal = Mathf.Lerp(currentTiltHorizontal, targetTiltHorizontal, tiltSpeed * Time.deltaTime);
        float newTiltVertical = Mathf.Lerp(currentTiltVertical, targetTiltVertical, tiltSpeed * Time.deltaTime);

        aircraftTransform.localRotation = Quaternion.Euler(newTiltVertical, 0, newTiltHorizontal);
    }
}