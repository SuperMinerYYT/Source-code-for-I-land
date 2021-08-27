using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(hit());
        }
    }

    IEnumerator hit()
    {
        anim.SetBool("Hit", true);
        yield return new WaitForSeconds(1);
        anim.SetBool("Hit", false);
    }
}
