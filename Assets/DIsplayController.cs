using UnityEngine;
using UnityEngine.UI;

public class DIsplayController : MonoBehaviour
{
    public Text Display;

    public string Description;

    public GameObject obj;

    public void SetText()
    {
        Display.text = Description;
    }

    public void setOBJ()
    {
        return;
    }


}
