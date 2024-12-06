using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class touchControllerLight : MonoBehaviour
{
    public bool up = false;
    public bool down = false;

    public UnityEvent upPressed;
    public UnityEvent downPressed;
    public Animator animator;

    [SerializeField]
    public TMP_Text Top;
    [SerializeField]
    public TMP_Text Bottom;

    public bool IsEnabled = false;

    private bool touched = false;

    [SerializeField]
    public BoxCollider upCollider;
    [SerializeField]
    public BoxCollider downCollider;
    [SerializeField]
    public BoxCollider moveCollider;
    [SerializeField]
    public GameObject MoveObject1;
    [SerializeField]
    public GameObject MoveObject2;

    public void Start(){
        // Movable();
    }

    public void chande(bool value){
        if(!value){
            Movable();
        } else {
            Usable();
        }
    }

    public void Movable(){
        IsEnabled = false;
        moveCollider.enabled = true;
        upCollider.enabled = false;
        downCollider.enabled = false;
        MoveObject1.SetActive(true);
        MoveObject2.SetActive(true);
    }

    public void Usable(){
        IsEnabled = true;
        moveCollider.enabled = false;
        if(!up){
            upCollider.enabled = true;
        }
        if(!down){
            downCollider.enabled = true;
        }
        MoveObject1.SetActive(false);
        MoveObject2.SetActive(false);
    }

    public void upTouched(){
        if(IsEnabled && !touched){
            touched = true;
            upCollider.enabled = false;
            animator.speed = 3;
            if(down){
                up = true;
                Bottom.color = Color.black;
                animator.SetBool("up", up);
                down = false;
                Top.color = new Color(0, 142, 10);
                animator.SetBool("down", false);
                upPressed.Invoke();
            }else if(!up){
                up = true;
                Top.color = new Color(0, 142, 10);
                animator.SetBool("up", up);
                upPressed.Invoke();
            }
            StartCoroutine(Wait(down: true));
        }
    }
    public void downTouched(){
        if(IsEnabled && !touched){
            touched = true;
            downCollider.enabled = false;
            animator.speed = 3;
            if(up){
                down = true;
                Top.color = Color.black;
                animator.SetBool("down", down);
                up = false;
                Bottom.color = new Color(0, 142, 10);
                animator.SetBool("up", false);
                downPressed.Invoke();
            }else if(!down){    
                down = true;
                Bottom.color = new Color(0, 142, 10);
                animator.SetBool("down", down);
                downPressed.Invoke();
            }
            StartCoroutine(Wait(up: true));
        }
    }

    public IEnumerator Wait(bool up = false, bool down = false){
        yield return new WaitForSeconds(1.5f);
        touched = false;
        if(up){
            upCollider.enabled = true;
        } else if(down){
            downCollider.enabled = true;
        }
    }
}
