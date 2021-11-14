using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private bool goRight, goLeft;
    public void right()
    {
        goRight = true;
    }
    public void left()
    {
        goLeft = true;
    }
    public void stopRight()
    {
        goRight = false;
    }
    public void stopLeft()
    {
        goLeft = false;
    }
    private void Update()
    {
        if(goRight == true)
        {
            this.gameObject.transform.Rotate(0, 100 * Time.deltaTime, 0);
        }
        if(goLeft == true)
        {
            this.gameObject.transform.Rotate(0, -100 * Time.deltaTime, 0);
        }
    }
}
