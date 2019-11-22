using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaloControler : MonoBehaviour
{
    public ballControler ball;
    private float rot;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!ball.shoot && Input.GetKey(KeyCode.Mouse1))
        {
            rot = Input.GetAxis("Mouse X") * -25;
        }
        transform.RotateAround(transform.position, Vector3.back, rot);
    }
}
