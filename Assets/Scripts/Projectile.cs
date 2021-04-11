using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Damage = 100;
    
    public float GetDamage()
    {
        return Damage;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
}
