using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MAQUINAPERSONAJE : MonoBehaviour
{
    public float walkSpeed; // player left right walk speed
    Animator animator;
    Transform transform;
    //animation states - the values in the animator conditions
    enum QuetzalStates { EXISTIENDO, CORRIENDO, ATACANDO };
    //0, 1, 2, 3, 4, 5
    const string STATE_EXISTIENDO_NAME = "existiendo";
    enum Directions { LEFT, RIGHT, MAX_DIR };
    //0, 1, 2
    Directions currentDirection = Directions.LEFT;
    QuetzalStates currentAnimationState = QuetzalStates.EXISTIENDO;

    void Start()
    {
        //define the animator attached to the player
        animator = GetComponent<Animator>();
        transform = GetComponent<Transform>();
    }

    void changeState(QuetzalStates state)
    {
        if (currentAnimationState != state)
        {
            animator.SetInteger("Estadoslayer", (int)state);
            currentAnimationState = state;
        }
    }
    bool isPlaying(QuetzalStates state) { return state == currentAnimationState; }
    void changeDirection(Directions direction)
    {
        if (currentDirection != direction)
        {
            currentDirection = direction;
            switch (direction)
            {
                case Directions.RIGHT:
                    transform.Rotate(0, 180, 0);
                    break;
                case Directions.LEFT:
                    transform.Rotate(0, -180, 0);
                    break;
            }
        }
    }
    void Update()
    {
        switch (currentAnimationState)
        {
            case QuetzalStates.EXISTIENDO:
                //Check for keyboard input
                if (Input.GetKeyDown(KeyCode.Space))
                    changeState(QuetzalStates.ATACANDO);
             
                  if (0.0f != Input.GetAxis("Horizontal"))
                        changeState(QuetzalStates.CORRIENDO);
                break;
           
        }
        checkDir();
        if (!Input.anyKey)
            changeState(QuetzalStates.EXISTIENDO);

        void checkDir()
        {
            //All states can change its direction any time
            if (Input.GetKey(KeyCode.RightArrow))
            {
                changeDirection(Directions.RIGHT);
                transform.Translate(Vector3.left * walkSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                changeDirection(Directions.LEFT);
                transform.Translate(Vector3.left * walkSpeed * Time.deltaTime);
            }
        }
    }

   
}
