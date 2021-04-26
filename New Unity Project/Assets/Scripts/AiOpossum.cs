using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiOpossum : MonoBehaviour
{
    // Start is called before the first frame update

    public float LimStanga;
    public float LimDreapta;
    public float speed;
    public Rigidbody2D rb;
    public Animator anim;
    private bool OrientareStanga = true;
    public AudioSource death; 


    // Update is called once per frame
    void Update()
    {

        if(OrientareStanga)
        {
            if (transform.position.x < LimStanga)
            {
                transform.localScale = new Vector3(-1, 1);
                rb.velocity = new Vector2(speed, 0);
                OrientareStanga = false;
            }
            else
            {
                rb.velocity = new Vector2(-speed, 0);
            }
        }
        else
        {
            if( transform.position.x > LimDreapta )
            {
                transform.localScale = new Vector3(1, 1);
                rb.velocity = new Vector2(-speed, 0);
                OrientareStanga = true;
            }
            else
            {
                rb.velocity = new Vector2(speed, 0);
            }
        }
        
    }
    public void JumpedOn()
    { 
        rb.velocity = new Vector2(0, 0);
        death.Play();
        anim.SetTrigger("Dead");
       
    }
}
