using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int Speed = 15;
    public GameObject Projectile;
    public float ProjectileSpeed = 5f;
    public float FiringRate = 0.2f;

    float xMin;
    float xMax;

    float padding = 1;
    public float Health = 250;

    public AudioClip FireClip;

    private void Start()
    {
        xMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0)).x + padding;
        xMax = Camera.main.ViewportToWorldPoint(new Vector3(1, 0)).x - padding;
    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            InvokeRepeating("Fire", 0, FiringRate);

        if (Input.GetKeyUp(KeyCode.Space))
            CancelInvoke("Fire");

        if (Input.GetKey(KeyCode.LeftArrow))
            transform.position += Vector3.left * Speed * Time.deltaTime;
        else if (Input.GetKey(KeyCode.RightArrow))
            transform.position += Vector3.right * Speed * Time.deltaTime;

        float newX = Mathf.Clamp(transform.position.x, xMin, xMax);
        Vector3 pos = transform.position;
        pos.x = newX;
        transform.position = pos;
	}

    private void Fire()
    {
        GameObject projectile = Instantiate(Projectile, transform.position + Vector3.up, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, ProjectileSpeed);
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
                LevelManager manager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
                manager.LoadLevel("Win Screen");
            }
        }
    }
}
