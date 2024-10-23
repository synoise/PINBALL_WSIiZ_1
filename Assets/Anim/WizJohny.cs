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
            ResetAnimation();
            anim.SetBool("isIdle", true);
        }

        public void ResetAnimation()
        {
            anim.SetBool("isIdle", false);
            anim.SetBool("isRun", false);
            anim.SetBool("isJump", false);
        }
        public  void IdleJohny()
        {
            ResetAnimation();
            anim.SetTrigger("isIdle");
        }
        public  void RunJohny()
        {
            ResetAnimation();
            anim.SetTrigger("isRun");
        }
        public void JumpJohny()
        {
            ResetAnimation();
            anim.SetTrigger("isJump");
        }
    }
}
