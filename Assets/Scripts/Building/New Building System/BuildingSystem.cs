using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


[System.Serializable]

public class Building
{
    public GameObject building;
    public int cost;
    public Mesh previewMesh;
    public Mesh rangePreviewMesh;
}
