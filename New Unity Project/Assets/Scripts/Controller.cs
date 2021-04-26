using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public Collider2D col;
    public LayerMask ground;
    public AudioSource footstep;
    public AudioSource sari;
    public AudioSource coin;
    public enum State {idle, run, jump,fall};
    private State state=State.idle;
    private int Gem_uri = 0;
    public TextMeshProUGUI CherryText;
    public TextMeshProUGUI timer;
    private float timp=0;
    
    void Start()
    {
        CherryText.text = "0"; 
    }

    void Update()
    {
        timp += Time.deltaTime;

        timer.text = timp.ToString("f2");

        float directieOrizont = Input.GetAxis("Horizontal");
 
        if(directieOrizont<0)
        {
            rb.velocity = new Vector2(-8, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
            
        }
        else if(directieOrizont>0)
        {
           rb.velocity = new Vector2(8, rb.velocity.y);
           transform.localScale = new Vector2(1, 1);
          
        }
        if(Input.GetButtonDown("Jump") && col.IsTouchingLayers(ground))
        {
            jump();
        }
        Stagiu();
        anim.SetInteger("State",(int)state);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.tag == "Collectable" )
        {
            coin.Play();
            Destroy(collision.gameObject);
            Gem_uri ++;
            CherryText.text = Gem_uri.ToString();

        }
        else 
        if(collision.tag == "Cheie")
        {
            coin.Play();
        }
        else
        if (collision.tag == "Exit")
        {
            int y;
            y = Gem_uri * Random.Range(50,100) - (int)timp*5;
            PlayerPrefs.SetInt("Nivel", SceneManager.GetActiveScene().buildIndex);
            PlayerPrefs.SetInt("Scor", y);
            SceneManager.LoadScene("You Got Home");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        
        if( collision.gameObject.tag == "Enemy" && state == State.fall)
        {
            AiOpossum opposum = collision.gameObject.GetComponent<AiOpossum>();
            opposum.JumpedOn();
            jump();
        }else
        if(collision.gameObject.tag == "Enemy2" && state == State.fall)
        {
            AiEagle eagle = collision.gameObject.GetComponent<AiEagle>();
            eagle.JumpedOn();
            jump();
        }
        else 
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Enemy2")
        {
            PlayerPrefs.SetString("Scena", SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("YouDied");
        }
    }

    public void jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 30f);
        state = State.jump;
    }
   
    private void Stagiu()
    {
        if (state == State.jump)
        {
            if (rb.velocity.y < .1f)
            {
                state = State.fall;
            }
        }
        else if (state == State.fall)
        {
            if (col.IsTouchingLayers(ground))
                state = State.idle;
        }
        else if (Mathf.Abs(rb.velocity.x) > 0.75f)
        {
            state = State.run;
        }
        else
            state = State.idle;

    }

    private void Footstep()
    {
        footstep.Play();
    }

    private void Jump()
    {
        sari.Play();
    }
}
