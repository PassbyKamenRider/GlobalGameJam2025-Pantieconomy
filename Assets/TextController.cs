using System.Collections.Generic;
using UnityEngine;
using System.Collections;


public class TextController : MonoBehaviour
{
    public GameObject obj;
    public Texture[] texts;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(changeText());
    }
    
    IEnumerator changeText()
    {
        for(int i = 0 ; i < texts.Length; i++)
        {
            var mat = obj.GetComponent<Material>();
            mat.mainTexture = texts[i];
            
            yield return new WaitForEndOfFrame();
        }
        
    }
    
}
