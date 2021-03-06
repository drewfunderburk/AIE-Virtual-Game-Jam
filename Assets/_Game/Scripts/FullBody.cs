using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FullBody : MonoBehaviour
{
    Rigidbody2D rb;
    Collider2D collide;
    Collider2D child;
    public GameObject connect;
    public Animator animator;
    public GameObject victoryImage;
    public FadeToBlack fadeToBlack;

    // Start is called before the first frame update
    void Start()
    {
        victoryImage.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        collide = GetComponent<Collider2D>();
        child = connect.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetInteger("velocity", (int)rb.velocity.x);

        if(connect.GetComponent<PlayerStat>().gold)
        {
            if(collide.IsTouching(child))
            {
                connect.GetComponent<Collider2D>().enabled = false;
                connect.GetComponent<Rigidbody2D>().isKinematic = true;
                connect.GetComponent<PlayerMovement>().enabled = false;

                connect.transform.SetParent(transform);
                if(rb.velocity.x > 0)
                    connect.transform.position = new Vector3(transform.position.x + 0.5f, transform.position.y + 1.9f,transform.position.z);
                else if(rb.velocity.x < 0)
                    connect.transform.position = new Vector3(transform.position.x - 0.5f, transform.position.y + 1.9f,transform.position.z);

                connect.transform.rotation = new Quaternion();
                connect.GetComponent<Animator>().SetBool("isOnBody",true);
                victoryImage.SetActive(true);
                StartCoroutine(GoToNextScene());
            }
        }
    }

    IEnumerator GoToNextScene()
    {
        // Wait 5 seconds asynchronously
        yield return new WaitForSeconds(5);
        // Load next scene
        StartCoroutine(fadeToBlack.ToBlack(0.8f));
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
