using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class touchControllerRollo : MonoBehaviour
{
    public bool up = false;
    public bool down = false;
    public bool middle = false;

    public UnityEvent upPressed;
    public UnityEvent downPressed;
    public UnityEvent middlePressed;
    public Animator animator;
    [SerializeField]
    public TMP_Text Top;
    [SerializeField]
    public TMP_Text Bottom;

    public bool IsEnabled = true;

    public void upTouched(){
        if(IsEnabled){
            animator.speed = 3;
            if(down){
                middle = true;
                animator.SetBool("middle", middle);
                down = false;
                Bottom.color = Color.black;
                animator.SetBool("down", false);
                middlePressed.Invoke();
            } else if(middle){
                middle = false;
                animator.SetBool("middle", middle);
                up = true;
                Top.color = new Color(0, 142, 10);
                animator.SetBool("up", up);
                upPressed.Invoke();
            }else if(!up){
                up = true;
                Top.color = new Color(0, 142, 10);
                animator.SetBool("up", up);
                upPressed.Invoke();
            }
        }
    }
    public void downTouched(){
        if(IsEnabled){
            animator.speed = 3;
            if(up){
                middle = true;
                animator.SetBool("middle", middle);
                up = false;
                Top.color = Color.black;
                animator.SetBool("up", false);
                middlePressed.Invoke();
            } else if(middle){
                middle = false;
                animator.SetBool("middle", middle);
                down = true;
                Bottom.color = new Color(0, 142, 10);
                animator.SetBool("down", down);
                downPressed.Invoke();
            }else if(!down){    
                down = true;
                Bottom.color = new Color(0, 142, 10);
                animator.SetBool("down", down);
                downPressed.Invoke();
            }
        }
    }
}
