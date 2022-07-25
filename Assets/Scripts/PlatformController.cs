using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public GameObject[] platform ;
    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        platform = GameObject.FindGameObjectsWithTag("Floater");
    }

    public void OnClick()
    {
        panel.SetActive(false);
    }

}
