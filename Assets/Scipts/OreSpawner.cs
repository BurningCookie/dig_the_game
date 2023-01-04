using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreSpawner : MonoBehaviour
{
    public float timeBetweenSpawns = 5;
    public GameObject Ore;
    public float spawnRange = 5;
    Vector3 startpos;
    RaycastHit hit;
    public LayerMask l;

    private float timer;

    private void Start()
    {
        timer = 0;
        startpos = transform.position;
    }

    private void FixedUpdate()
    {
        timer += 0.1f;
        if (timer > timeBetweenSpawns)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Random.Range(-spawnRange/2, spawnRange/2));
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z + Random.Range(-50, 50));
            if (Physics.Raycast(transform.position, -transform.up, out hit, 100, l))
            {
                if (hit.collider.gameObject.tag != "Ore")
                {
                    Instantiate(Ore, hit.point, transform.rotation);
                }
            }
            transform.rotation = Quaternion.identity;
            transform.position = startpos;
            timer = 0;
        }
    }
}
