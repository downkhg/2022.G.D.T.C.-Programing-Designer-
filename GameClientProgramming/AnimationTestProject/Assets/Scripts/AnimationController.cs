using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //animator.SetInteger("SetState", 1);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            animator.SetInteger("SetState", 1);
            transform.localScale = new Vector3(-1,1,1);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetInteger("SetState", 0);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetInteger("SetState", 1);
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetInteger("SetState", 0);
        }

    }

    private void OnGUI()
    {
        AnimatorClipInfo[] aniClipinfo = animator.GetCurrentAnimatorClipInfo(0);
        AnimatorStateInfo aniStatusInfo = animator.GetCurrentAnimatorStateInfo(0);

        string log = string.Format("{0}:{1}", aniClipinfo[0].clip.name, aniStatusInfo.normalizedTime);
        GUI.Box(new Rect(0, 0, 500, 20), log);
    }
}
