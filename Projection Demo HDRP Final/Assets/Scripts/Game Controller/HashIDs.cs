using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HashIDs : MonoBehaviour
{
    public int dyingState;
    public int deadBool;
    public int walkState;
    public int backwardsBool;
    //public int goingLeftBool;
    //public int goingRightBool;
    public int directionBool;
    public int turnFloat;
    public int speedFloat;
    public int sneakingBool;
    public int jumpBool;
    public int runningBool;
    public int shoutingBool;

    private void Awake()
    {
        dyingState = Animator.StringToHash("Base Layer.Dying");
        deadBool = Animator.StringToHash("Dead");
        walkState = Animator.StringToHash("Walk");
        backwardsBool = Animator.StringToHash("Backwards");
        //goingLeftBool = Animator.StringToHash("Going Left");
        //goingRightBool = Animator.StringToHash("Going Right");
        directionBool = Animator.StringToHash("Direction");
        turnFloat = Animator.StringToHash("Turn");
        speedFloat = Animator.StringToHash("Speed");
        sneakingBool = Animator.StringToHash("Sneaking");
        shoutingBool = Animator.StringToHash("Shouting");
        jumpBool = Animator.StringToHash("Jump");
        runningBool = Animator.StringToHash("Running");
    }
}
