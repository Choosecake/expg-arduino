using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerTrail : MonoBehaviour
{
    public List<GameObject> coverPlanes = new List<GameObject>();
    public Material defaultPlaneMaterial;
    public Material selectedPlaneMaterial;

    private void Update()
    {
        foreach (GameObject plane in coverPlanes)
        {
            plane.GetComponent<MeshRenderer>().material = selectedPlaneMaterial;
        }

        if (coverPlanes.Count > 4)
        {
            DestroyPlane(coverPlanes.ToArray());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cover"))
        {
            coverPlanes.Add(other.gameObject);
        }
    }

    private void DestroyPlane(GameObject[] plane)
    {
        foreach (GameObject p in plane)
        {
            p.SetActive(false);
        }
        coverPlanes.Clear();
    }
}
