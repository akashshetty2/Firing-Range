using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;

    void OnCollisionEnter(Collision collisionInfo)
    {
        IDamageable damageable = collisionInfo.gameObject.GetComponent<IDamageable>();
        if (damageable != null)
            damageable.TakeDamage(damage);

        Destroy(this.gameObject, 3);
    }
}