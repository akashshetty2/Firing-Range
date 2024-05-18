using UnityEngine;

[CreateAssetMenu(menuName = "Assets/Gun")]
public class Gun : ScriptableObject
{
    [Range(0, 10)]
    public float Cooldown;

    [Range(0, 100)]
    public float Velocity;

    [Range(0, 100)]
    public int Damage;

    [Range(0, 1)]
    public float ShotDelay;

    [Range(0, 100)]
    public float Recoil;

    public bool Automatic = false;

    public Rigidbody bullet;

    [Header("Sounds")]
    [Tooltip("Enter name of clip")]
    public string shoot;
    
    [Tooltip("Enter name of clip")]
    public string reload;

}