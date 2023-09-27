using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController : MonoBehaviour
{
    private bool swipeStarted;
    private Vector2 startPoint;
    private Animator animator;
    public float swipeThreshold =50f;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            swipeStarted = true;
            startPoint = Input.mousePosition;

        }
        else if(Input.GetMouseButtonUp(0))
        {
            swipeStarted =false;
            Vector2 endPoint = Input.mousePosition;
            float swipeDistance = (endPoint - startPoint).magnitude;

            //check if the swipe distance is greater than the threshold
            if(swipeDistance >= swipeThreshold)
            {
                //determine the direction of the swipe
                Vector2 swipeDirection = endPoint - startPoint;
                swipeDirection.Normalize();
                // check the direction and dperform actions
                if(swipeDirection.x< -0.5f && Mathf.Abs(swipeDirection.y)<0.5f)
                {
                    // left Swipe
                    Debug.Log(" Left Swipe Detected");
                }
                else if(swipeDirection.x> 0.5f && Mathf.Abs(swipeDirection.y)<0.5f)
                {
                    //right swipe 
                    Debug.Log("Right swipe Detected");
                }
                else if(swipeDirection.y> 0.5f && Mathf.Abs(swipeDirection.x)<0.5f)
                {
                    // Up swipe 
                    Debug.Log("Up swipe Detected");
                    animator.SetTrigger("Jump");
                }
                else if(swipeDirection.y < -.5f && Mathf.Abs(swipeDirection.x)<0.5f)
                {
                    // Down Swipe
                    Debug.Log(" Down Swipe Detected");
                    animator.SetTrigger("Slide");
                }

            }
        }
    }
}
