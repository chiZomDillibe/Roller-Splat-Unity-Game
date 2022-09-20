using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 15;

    private bool isTraveling;
    private Vector3 travelDirection;
    private Vector3 nextCollisionPosition;

    public int minSwipeRecognition = 500;
    private Vector2 swipePosLastFrame;
    private Vector2 swipePosCurrentFrame;
    private Vector2 currentSwipe;
  
  private void FixedUpdate()
  {
     if(isTraveling)
     {
        rb.velocity = speed * travelDirection;
     }
    
    if(nextCollisionPosition != Vector3.zero)
    {
        if(Vector3.Distance(transform.position, nextCollisionPosition) < 1)
        {
            isTraveling = false;
            travelDirection= Vector3.zero;
            nextCollisionPosition = Vector3.zero;
        }
    }
   
     if(Input.GetMouseButton(0))
     {
        swipePosCurrentFrame = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        if(swipePosLastFrame != Vector2.zero)
        {
            currentSwipe = swipePosCurrentFrame - swipePosLastFrame;
        }
     }

  }
}
