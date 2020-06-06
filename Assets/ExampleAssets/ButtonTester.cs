using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTester : MonoBehaviour
{
    public Material[] materials;

    int current;
    MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        current = 0;
        meshRenderer.material = materials[current];
    }

    public void Cycle()
    {
        current = (current + 1) % materials.Length;
        meshRenderer.material = materials[current];
    }
}
