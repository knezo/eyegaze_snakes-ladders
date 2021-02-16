using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowThePath : MonoBehaviour{

    public Transform[] waypoints;

    // [SerializeField]
    private float moveSpeed = 3f;

    // [HideInInspector]
    public int waypointIndex = 0;
    public int startWaypoint = 0;

    public bool moveAllowed = false;     
    public bool myMoveAllowed = false;
    public int moveToField = 0;
    // public bool moveAllowedByClick = false; 


    // Start is called before the first frame update
    private void Start(){
        transform.position = waypoints[waypointIndex].transform.position;
        
    }

    // Update is called once per frame
    private void Update () {
        if (moveAllowed)
            Move();        

        if(myMoveAllowed){
            MoveTo();
        }
	}

    private void Move()
    {
        if (waypointIndex <= waypoints.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position,
            waypoints[waypointIndex].transform.position,
            moveSpeed * Time.deltaTime);

            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;
            }
        }
    }

    // used when player stops at snake head or ladder to move it to snake tail or ladder top
    public void MoveTo(){
    
        transform.position = Vector2.MoveTowards(transform.position,
        waypoints[moveToField].transform.position,
        moveSpeed * Time.deltaTime);

        if (transform.position == waypoints[moveToField].transform.position)
            {
                myMoveAllowed = false;
                waypointIndex = moveToField;
                startWaypoint=moveToField;
            }
        

    }

    //click on piece
    // private void OnMouseDown(){
    //     moveAllowedByClick = true;
    // }

} 


