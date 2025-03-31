using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableAircraft", menuName = "Aircraft/Scriptable Aircraft")]
public class AircraftData : ScriptableObject
{
    public float Speed;
    public float MaxUpSpeed;
    public float UpSpeed;
}