using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionScene : MonoBehaviour
{
    Animator myAnimator;
    void Start()
    {
        myAnimator = this.GetComponent<Animator>();
        myAnimator.SetBool("fadeOut", true);
        myAnimator.SetBool("fadeIn", false);
    }

    public void FadeIn() 
    {
        myAnimator.SetBool("fadeIn", true);
        myAnimator.SetBool("fadeOut", false);
    }
}
