using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Gun currGun;

    private Shooter shooter;

    void Awake()
    {
        shooter = GetComponent<Shooter>();
    }

    void Update()
    {
        if (currGun.Automatic && Input.GetMouseButton(0))
            StartCoroutine(shooter.Shoot(currGun));
        else if (!currGun.Automatic && Input.GetMouseButtonDown(0))
            StartCoroutine(shooter.Shoot(currGun));
    }

    public void ChangeGun(Gun gun)
    {
        currGun = gun;
        shooter.readyToShoot = true;
    }
}