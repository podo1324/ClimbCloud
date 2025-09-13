using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;

    float jumpForce = 680.0f;

    float walkForce = 30.0f;
    float maxWalkSpeed = 2.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.y.Equals(0))
        {
            rb.AddForce(transform.up * this.jumpForce);
        }

        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

        float speedx = Mathf.Abs(rb.velocity.x);

        if (speedx < this.maxWalkSpeed)
        {
            rb.AddForce(transform.right * key * this.walkForce);
        }

        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        anim.speed = speedx / 2.0f;

        if (transform.position.y < -6)
        {
            SceneManager.LoadScene("GameScene");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("°ñ");
        SceneManager.LoadScene("ClearScene");
    }
}
