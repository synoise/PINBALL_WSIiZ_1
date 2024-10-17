using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ClearSky;

namespace ClearSky
{
    public class WizJohny : MonoBehaviour
    {

        public Animator anim;
        // Start is called before the first frame update
        public void Awake()
        {
            anim = GetComponent<Animator>();
            IdleJohny();
        }

        public  void IdleJohny()
        {
            anim.SetBool("IsRunning", false);
        }
        public  void RunJohny()
        {
            anim.SetBool("IsRunning", true);
        }
        public void JumpJohny()
        {
            anim.SetTrigger("IsJumping");
        }
    }
}
