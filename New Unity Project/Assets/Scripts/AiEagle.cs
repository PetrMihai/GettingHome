using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiEagle : MonoBehaviour
{
    public Animator anim;
    public AudioSource death;
    // Start is called before the first frame update
    public void JumpedOn()
    {
        anim.SetTrigger("Dead");
        death.Play();
    }
}
