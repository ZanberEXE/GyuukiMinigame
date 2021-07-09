using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] baconsToSpawn;
    public GameObject vertex;
    public GameObject itsukiUdon;
    public Transform[] spawnPlaces;
    public float minWait = 0.3f;
    public float maxWait = 1.0f;
    public float distFromCamera = 20.0f;
    

    //Vector2 randomPositionOnScreen = Camera.main.ViewportToWorldPoint(new Vector2(Random.value, Random.value));
    void Start()
    {
        StartCoroutine(SpawnBacons());
    }

    private IEnumerator SpawnBacons()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(minWait, maxWait));

            //get random position value for viewport (0,0) - (1,1), fixed distance from Camera (z)
            Vector3 pos = new Vector3(Random.value, Random.value, distFromCamera);
            pos = Camera.main.ViewportToWorldPoint(pos); //Vector3 world position

            // create empty GO assign bomb or other object randomly
            GameObject go = null;
            float p = Random.Range(0, 100);
            if(p < 10)
            { go = itsukiUdon; }
            else 
            { go = baconsToSpawn[Random.Range(0, baconsToSpawn.Length)]; }

            //Instantiate GameObject
            GameObject food = Instantiate(go, pos, Quaternion.identity);

            Debug.Log("Bacon created!");

            Destroy(food, 10.0f);
        }
    }
}
