using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float Health = 150;
    public GameObject Projectile;
    public float ProjectileSpeed = 10;
    public float ShotsPerSeconds = 0.5f;
    public int scoreValue = 150;

    public AudioClip FireClip;
    public AudioClip DieClip;

    ScoreKeeper scoreKeeper;

    private void Start()
    {
        scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
    }

    private void Update()
    {
        float probability = ShotsPerSeconds * Time.deltaTime;
        if(Random.value < probability)
            Fire();
    }

    private void Fire()
    {
        GameObject missile = Instantiate(Projectile, transform.position, Quaternion.identity);
        missile.GetComponent<Rigidbody2D>().velocity = Vector2.down * ProjectileSpeed;
        AudioSource.PlayClipAtPoint(FireClip, transform.position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Projectile missile = collision.GetComponent<Projectile>();
        if (missile)
        {
            Health -= missile.GetDamage();
            missile.Hit();
            if (Health < 0)
            {
                Destroy(gameObject);
                scoreKeeper.Score(scoreValue);
                AudioSource.PlayClipAtPoint(DieClip, transform.position);
            }
        }
    }
}
