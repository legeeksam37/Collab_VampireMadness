using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCharacter : MonoBehaviour
{
    [SerializeField]
    List<Mesh> RandomMeshs;

    [SerializeField]
    List<Material> RandomMaterials;

    MeshFilter meshFilter;
    MeshRenderer meshRend;

    // Start is called before the first frame update
    void Start()
    {
        meshFilter = gameObject.GetComponent<MeshFilter>();
        if (RandomMeshs.Count > 1)
        {
            int randMeshIndex = Random.Range(0, RandomMeshs.Count);
            meshFilter.sharedMesh = RandomMeshs[randMeshIndex];
        }
        else
        {
            meshFilter.sharedMesh = RandomMeshs[0];
        }

        meshRend = gameObject.GetComponent<MeshRenderer>();
        if(RandomMaterials.Count > 1)
        {
            int randMatIndex = Random.Range(0, RandomMaterials.Count);
            meshRend.material = RandomMaterials[randMatIndex];
        }
        else
        {
            meshRend.material = RandomMaterials[0];
        }
    }
}
