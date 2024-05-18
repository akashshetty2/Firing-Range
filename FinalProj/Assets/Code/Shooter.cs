using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public bool readyToShoot = true;
    private Player player;
    private Recoil recoil;
    public Transform shootDirection;

    void Awake()
    {
        player = GetComponent<Player>();
        recoil = GetComponentInChildren<Recoil>();
    }

    public IEnumerator Shoot(Gun gun)
    {
        if (readyToShoot)
        {
            readyToShoot = false;

            // shoot gun

            Rigidbody shotBullet = Instantiate(gun.bullet, shootDirection.transform.position, transform.rotation) as Rigidbody;
            shotBullet.velocity = transform.TransformDirection(new Vector3(0, 0, gun.Velocity));
            recoil.RecoilFire(gun); 
	    yield return new WaitForSeconds(gun.Cooldown);

            readyToShoot = true;
        }

        yield break;
    }
}