using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassOptimization : MonoBehaviour
{
    [SerializeField]
    public GameObject[] GrassSpawners;
    [SerializeField]
    public Vector2 maxDst;

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject spawner in GrassSpawners)
        {
            Vector2 posSpawner = new Vector2((gameObject.transform.position.x - spawner.transform.position.x), (gameObject.transform.position.z - spawner.transform.position.z));
            if (posSpawner.x > maxDst.x || posSpawner.y > maxDst.y)
                spawner.SetActive(false);
            else if (posSpawner.x <= maxDst.x && posSpawner.y <= maxDst.y)
                spawner.SetActive(true);
        }
    }
}
