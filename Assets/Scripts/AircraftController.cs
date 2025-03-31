using UnityEngine;

public class AircraftController : AircraftBase
{
    public void Update()
    {
        base.Update();
        FlyForward();
        Steer();
        SetTiltDirection();
    }

    private void FlyForward()
    {
        playerTransform.Translate(forwardSpeed * Vector3.forward * Time.deltaTime);
    }

    private void Steer()
    {
        playerTransform.Rotate(Vector3.up, movement.x * turningSpeed * Time.deltaTime, Space.Self);
        playerTransform.Rotate(Vector3.right, -movement.z * upSpeed * Time.deltaTime, Space.Self);
    }

    private void SetTiltDirection()
    {
        tiltDirection = (int)movement.z;
    }
}
