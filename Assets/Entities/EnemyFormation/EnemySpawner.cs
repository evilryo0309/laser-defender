using System;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Vector2 Size;
    public float Speed = 5f;

    float xMin;
    float xMax;
    bool MovingRight;

	void Start ()
    {
        xMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0)).x;
        xMax = Camera.main.ViewportToWorldPoint(new Vector3(1, 0)).x;
        SpawnUntilFull();
    }

    private void SpawnUntilFull()
    {
        Transform freePosition = GetNextFreePosition();
        if (freePosition)
            Instantiate(enemyPrefab, freePosition, false);

        if(GetNextFreePosition())
            Invoke("SpawnUntilFull", 0.5f);
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, Size);
    }

    void Update()
    {
        if (MovingRight)
            transform.position += Vector3.right * Speed * Time.deltaTime;
        else
            transform.position += Vector3.left * Speed * Time.deltaTime;

        if (transform.position.x - 0.5f * Size.x < xMin)
            MovingRight = true;
        else if ((transform.position.x + 0.5f * Size.x) > xMax)
            MovingRight = false;

        if (AllMemgersDead())
            SpawnUntilFull();
    }

    private Transform GetNextFreePosition()
    {
        foreach (Transform item in transform)
            if (item.childCount == 0)
                return item;
        return null;
    }

    private bool AllMemgersDead()
    {
        foreach (Transform item in transform)
            if (item.childCount > 0)
                return false;
        return true;
    }


}
