using UnityEngine;
using UnityEngine.UI;

public class toggleKBM : MonoBehaviour
{
    toggleKBM toggle;
    public Text toggleText;

    public void changeController(toggleKBM change)
    {
        if(toggleText.text == "Keyboard")
            toggleText.text = "Mouse";
        else 
            toggleText.text = "Keyboard";
    }
}
