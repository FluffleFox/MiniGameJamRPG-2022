using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddColliderToChildren : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private bool IsTrigger = false;
    void Start()
    {
        foreach(Transform child in transform)
        {
            Mesh mesh = child.gameObject.GetComponent<MeshFilter>().mesh;

            if (mesh != null)
            {
                MeshCollider meshCollider = child.gameObject.AddComponent<MeshCollider>();
                meshCollider.sharedMesh = mesh;
                meshCollider.convex = IsTrigger;
                meshCollider.isTrigger = IsTrigger;
            }
        }
    }
}
