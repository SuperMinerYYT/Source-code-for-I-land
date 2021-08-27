using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestGenerator : MonoBehaviour
{
    public int forestSize = 10;
    public int elementSpacing = 150;

    public Element[] elements;

    private void Start()
    {
        for (int x = -734; x < forestSize; x += elementSpacing)
        {
            for (int z = -853; z < forestSize; z += elementSpacing)
            {

                for (int i = 0; i < elements.Length; i++)
                {

                    Element element = elements[i];

                    if (element.CanPlace())
                    {

                        Vector3 position = new Vector3(x, 150, z);
                        Vector3 offset = new Vector3(Random.Range(-10f, 10f), 150, Random.Range(-10f, 10f));
                        Vector3 rotation = new Vector3(Random.Range(0, 7f), Random.Range(0, 360f), Random.Range(0, 7f));
                        float randomizedScale = Random.Range(0.75f, 1.25f);
                        Vector3 scale = new Vector3((1.3f * randomizedScale), (1.5f * randomizedScale), (1.3f * randomizedScale));

                        GameObject newElement = Instantiate(element.GetRandom());
                        newElement.transform.SetParent(transform);
                        newElement.transform.position = position + offset;
                        newElement.transform.eulerAngles = rotation;
                        newElement.transform.localScale = scale;
                        break;

                    }

                }

            }
        }
    }
}

[System.Serializable]
public class Element
{
    public string name;
    
    [Range(0, 10)]
    public int density;

    public GameObject[] prefabs;

    public bool CanPlace()
    {
        if (Random.Range(0, 10) < density)
            return true;
        else
            return false;
    }

    public GameObject GetRandom()
    {
        return prefabs[Random.Range(0, prefabs.Length)];
    }
}
