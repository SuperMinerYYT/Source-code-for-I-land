using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerAssigner : MonoBehaviour
{
    GameObject terrainGround;
    MeshCollider terrainMeshCollider;
    public PhysicMaterial groundPhysxMat;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SetLayer");
    }

    IEnumerator SetLayer()
    {
        yield return new WaitForSeconds(0.2f);
        terrainGround = this.gameObject.transform.GetChild(2).gameObject;
        terrainMeshCollider = this.gameObject.transform.GetChild(2).gameObject.GetComponent<MeshCollider>();
        terrainMeshCollider.material = groundPhysxMat;
        terrainGround.layer = 6;
    }
}
