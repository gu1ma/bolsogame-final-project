using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] coronas;

    private float timeBtwSpawns;
    public float startTimeBtwSpaws;

    public float minTimeBtwSpawns;
    public float decrease;

    public GameObject bolso;

    // Update is called once per frame
    void Update() {
        if(bolso != null) {
            if(timeBtwSpawns <= 0) {
                Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
                GameObject randomCorona = coronas[Random.Range(0, coronas.Length)];
                
                //Spawn random corona at random spawn point
                Instantiate(randomCorona, randomSpawnPoint.position, Quaternion.identity);

                if(startTimeBtwSpaws > minTimeBtwSpawns) {
                    startTimeBtwSpaws -= decrease;
                }

                //Reset time for create a new corona enemy
                timeBtwSpawns = startTimeBtwSpaws;
            } else {
                timeBtwSpawns -= Time.deltaTime;
            }
        }
    }
}
