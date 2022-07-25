using UnityEngine;

public class Collectibles : MonoBehaviour
{
    private Animator anim;
    //public GameObject collectibles;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("IsActive", true);
    }
}
