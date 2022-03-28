using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    Rigidbody2D rb;
    SpriteRenderer render;
    public float playerJumpForce;
    public float playerSpeed;
    float inputX;
    // public Button quit;
    // public Button restart;
    public Text ScoreText;
    ScoreCalculator calculator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
        //quit.onClick.AddListener(QuitTheGame);
        // restart.onClick.AddListener(RestartTheGame);
        calculator = GameObject.Find("ScoreCalculator").GetComponent<ScoreCalculator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetTrigger("Idle");
        if (Input.GetKeyDown(KeyCode.Space))     // TO Jump
        {
            animator.SetTrigger("IsJumping");
            rb.AddForce(Vector2.up * playerJumpForce);
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            animator.SetTrigger("IsAttacking");
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            animator.SetTrigger("IsSliding");
        }
        inputX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(inputX * playerSpeed, rb.velocity.y);
        if (inputX > 0 || inputX < 0)
            animator.SetTrigger("IsRunning");
        if (inputX > 0)
            render.flipX = false;
        else if (inputX < 0)
            render.flipX = true;



        //Need to do running part
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Coins")
        {
            Destroy(collision.gameObject);
            // calculator = GameObject.Find("ScoreCalculator").GetComponent<ScoreCalculator>();
            calculator.Score(5);
            ScoreText.text = "Score: " + calculator.score;
        }
    }
   

   /* private void RestartTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void QuitTheGame()
    {
        SceneManager.LoadScene(0);
    }*/


}

