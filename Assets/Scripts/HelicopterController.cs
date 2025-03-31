using UnityEngine;

public class HelicopterController : AircraftBase
{
    private void Update()
    {
        base.Update();
        Fly();
        SetTiltDirection();
    }

    private void Fly()
    {
        playerTransform.Translate(forwardSpeed * Time.deltaTime * Vector3.forward * movement.z);
        playerTransform.Translate(upSpeed * Time.deltaTime * Vector3.up * movement.y);
        playerTransform.Translate(turningSpeed * Time.deltaTime * Vector3.right * movement.x);
    }

    private void SetTiltDirection()
    {
        tiltDirection = (int)-movement.z;
    }
}