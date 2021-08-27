using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GrassPointCloudRenderer : MonoBehaviour
{

    //public Mesh grassMesh;
    //public Material material;


    private Mesh mesh;
    public MeshFilter filter;

    public int seed;
    public Vector2 size;

    [Range(1, 6000000)]
    public int grassNumber;

    public float startHeight = 1000;
    public float grassOffset = 0.0f;

    private Vector3? lastPosition = null;
    private List<Vector2> uvs = new List<Vector2>();

    bool IsReady = false;

    void Start()
    {
        StartCoroutine(HoldTime());
    }

    IEnumerator HoldTime()
    {
        yield return new WaitForSeconds(0.6f);
        IsReady = true;
    }

    // Update is called once per frameS
    void Update()
    {
        if (IsReady)
        {
            if (!lastPosition.HasValue || lastPosition != this.transform.position)
            {
                Debug.Log("used");
                Random.InitState(seed);
                List<Vector3> positions = new List<Vector3>(grassNumber);
                int[] indicies = new int[grassNumber];
                List<Color> colors = new List<Color>(grassNumber);
                List<Vector3> normals = new List<Vector3>(grassNumber);
                for (int i = 0; i < grassNumber; ++i)
                {
                    Vector3 origin = this.transform.position;
                    origin.y = startHeight;
                    origin.x += size.x * Random.Range(-0.5f, 0.5f);
                    origin.z += size.y * Random.Range(-0.5f, 0.5f);
                    Ray ray = new Ray(origin, Vector3.down);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit))
                    {
                        var grassPosition = hit.point;
                        grassPosition.y += grassOffset;
                        grassPosition -= this.transform.position;
                        if (hit.point.y > 3.5f && hit.point.y < 70)
                            positions.Add(grassPosition);
                        else
                            positions.Add(new Vector3(9000000, 900000000, 90000000));
                        uvs.Add(new Vector2(1, 1));
                        //colors.Add(new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1));
                        colors.Add(new Color(Random.Range(0.9f, 1.0f), Random.Range(0.5f, 1.0f), Random.Range(0.9f, 1.0f), 1));
                        normals.Add(hit.normal);
                        indicies[i] = i;
                    }
                }
                mesh = new Mesh();
                mesh.SetVertices(positions);
                mesh.SetIndices(indicies, MeshTopology.Points, 0);
                mesh.SetColors(colors);
                mesh.SetNormals(normals);
                mesh.SetUVs(0, uvs);
                filter.mesh = mesh;

                lastPosition = this.transform.position;
            }
            //Graphics.DrawMeshInstanced(grassMesh, 0, material, materices);
            }
    }
}
