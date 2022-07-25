using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMobement : MonoBehaviour
{
    float rotatespeed = 2f;
    float movespeed = 6f;
    float jumpforce = 6;
    [SerializeField] private Animator anim = null;
    [SerializeField] private Rigidbody m_rigidBody = null;
    // Start is called before the first frame update

    private void Awake()
    {
        if (!anim) { gameObject.GetComponent<Animator>(); }
        if (!m_rigidBody) { gameObject.GetComponent<Animator>(); }
    }
    void Start()
    {
        //anim = gameObject.GetComponent<Animator>();
        anim.SetTrigger("Land");
    }

    // Update is called once per frame
    void Update()
    {
        //anim.SetTrigger("idle");
        if (Input.GetKey(KeyCode.RightArrow))
        {
            print("Rotate right");
            transform.Rotate(Vector3.up * rotatespeed);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            print("Rotate left");
            transform.Rotate(Vector3.down * rotatespeed);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(transform.up * jumpforce);
            anim.SetTrigger("Jump");
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, 0, Input.GetAxis("Vertical") * movespeed * Time.deltaTime);
            anim.SetTrigger("Movement.walk");
        }
    }

    private void FixedUpdate()
    {
       

    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Floater")
        {
            StartCoroutine(DisappearFloater(collision.gameObject));
            StartCoroutine(ReappearFloater(collision.gameObject));
        }
    }

    IEnumerator DisappearFloater(GameObject f)
    {
        yield return new WaitForSeconds(5);
        f.SetActive(false);
        
    }

    IEnumerator ReappearFloater(GameObject fr)
    {
        yield return new WaitForSeconds(10);
        fr.SetActive(true);
    }
    private void OnCollisionExit(Collision collision)
    {
        print(collision.gameObject.name);
        if (collision.gameObject.tag == "Floater")
        {
            print(collision.gameObject.activeSelf);
            if (collision.gameObject.activeSelf == false)
                collision.gameObject.SetActive(true);
                //StartCoroutine(ReappearFloater(collision.gameObject));
        }
        if(collision.gameObject.name == "Plane")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
