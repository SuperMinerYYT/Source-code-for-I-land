using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= 3.5f)
        {
            Debug.Log("BO O OF WO TAH");
            Destroy(gameObject);
        }
    }
}
