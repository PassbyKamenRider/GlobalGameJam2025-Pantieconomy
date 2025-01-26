using System.Collections;
using UnityEngine;

public class DissolvingController : MonoBehaviour
{
    public MeshRenderer Mesh;
    public float dissolveRate = 0.0125f;
    public float RefreshRate = 0.025f;
    
    private Material Material;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Mesh != null)
            Material = Mesh.material;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(DissolveCo());
        }
    }

    IEnumerator DissolveCo()
    {
        if (Material != null)
        {
            Material.SetFloat("_DissolveRate", dissolveRate);
        }
        yield return new WaitForSeconds(RefreshRate);
    }
}
