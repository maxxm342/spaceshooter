using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnmanager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private GameObject enemycontainer;

    private bool stopspawning = false;
    // Start is called before the first frame update
    void Start()
    {
     StartCoroutine(spawnRoutine(2.0f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator spawnRoutine(float spawnInterval)
    {
        while (stopspawning == false)
        {
            GameObject newenemy = Instantiate(enemy, new Vector3(Random.Range(-8f, 8f), 10, 0), Quaternion.identity);
            newenemy.transform.parent = enemycontainer.transform;
            yield return new WaitForSeconds(5.0f);
        }
    }

    public void onplayerdeath()
    {
        stopspawning = true;
    }
}
