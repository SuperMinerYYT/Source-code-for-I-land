using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{

    public Animator anim;
    bool isReady = true;
    public LayerMask Interactables;
    GameObject Hits;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        //RaycastHit Raycast = Physics.Raycast(transform.position, Vector3.forward, 6f, Interactables);
        if (Physics.Raycast(transform.parent.position,transform.parent.forward, out hit,4f,Interactables))
        {
            Hits = hit.collider.gameObject.transform.parent.GetChild(1).gameObject;
            //Hits.SetActive(true);
        }
        else
        {
            if (Hits != null)
                Hits = null;
                
        }
        if (Input.GetMouseButton(0) && isReady)
        {
            StartCoroutine(HitCoolDown());
        }
    }

    IEnumerator HitCoolDown()
    {
        isReady = false;
        anim.SetTrigger("Hit");
        if (Hits != null)
        {
            Health healthScript;
            yield return new WaitForSeconds(0.3f);
            if (Hits != null)
            {
                healthScript = Hits.transform.parent.GetChild(0).gameObject.GetComponent<Health>();
                if (healthScript != null)
                {
                    healthScript.health -= 10;
                    healthScript.hb.SetHealth(healthScript.health);
                }
            }
        }
            
        yield return new WaitForSeconds(0.48f);
        isReady = true;

    }

    public void HitDamage()
    {
    }
}
