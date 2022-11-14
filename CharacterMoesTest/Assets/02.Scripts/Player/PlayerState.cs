using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public enum State { Idle, Atack, Die };
    public enum Form { Fox, Tiger, Eagle};

    public State curState = State.Idle;
    public Form form = Form.Fox;

    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.1))
    }
}
