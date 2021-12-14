using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemyPrefab;
    public float period = 0.0f;
    public float timer;
    public float counter;
    private Transform target;
    private float range;
    public float minDistance = 20f;
    void Start()
    {

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        range = Vector2.Distance(transform.position, target.position);

        if (period > timer && counter >0 && range<minDistance  )
        {
            SpawnEnemy();
            period = 0;
            counter--;
        }
        period += UnityEngine.Time.deltaTime;
    }

    public void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, transform.position, transform.rotation);
    }
}
