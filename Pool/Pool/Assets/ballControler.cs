using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballControler : MonoBehaviour
{
    public GameObject palo;
    public GameObject control;
    public float speed;
    public bool shoot = false;
    public SpriteRenderer ball;
    public Vector2[] Points;
    public Vector3 pointFinish;
    public Vector3 Inicio;
    private bool change;
    private bool colider;
    private bool change2;
    private bool Goo;
    private bool Vertical;
    private Quaternion newRotation;
    private void Start()
    {
        Points = new Vector2[4];
        change = false;
        colider = false;
        change2 = false;
        Goo = false;
    }
    void Update()
    {
        if (change)
        {
            //pointFinish = new Vector3(pointFinish.x, pointFinish.y + ((pointFinish.y - transform.position.y)*2), pointFinish.z);
            change = false;
        }
        var step = speed * Time.deltaTime;
        if (Goo) {
            //control.transform.position = Vector3.MoveTowards(control.transform.position, pointFinish, step);
            setPointFinish(Vertical);
            if(Inicio.y < transform.position.y)
            {
                newRotation = Quaternion.LookRotation(transform.position - pointFinish, Vector3.forward);
            }   
            else
            {
                newRotation = Quaternion.LookRotation(transform.position + pointFinish, Vector3.forward);
            }
            newRotation.x = 0.0f;
            newRotation.y = 0.0f;
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 8);
            Inicio = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }   
        if (Input.GetKey(KeyCode.Mouse0))
        {
            pointFinish = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Inicio = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            shoot = true;
        }
        if (shoot)
        {
            palo.SetActive(false);
            transform.position = Vector3.MoveTowards(transform.position, control.transform.position, step);
        }
        PointsCalcu();
        Colider();
    }
    void Colider()
    {
        for(int a = 0; a < 4; a++)
        {
            for(int b = 0; b < 4; b++)
            {
                if(Points[0].x >= GameManager.instance.GetWallPoint(a, 0).x && Points[0].x <= GameManager.instance.GetWallPoint(a,1).x)
                {
                    print("COLIDERX");
                    if(Points[0].y >= GameManager.instance.GetWallPoint(a, 2).y && Points[0].y <= GameManager.instance.GetWallPoint(a, 0).y)
                    {
                        print("COLIDERY");
                        if (!colider)
                        {
                            change = true;
                        }
                        if(a >= 0 && a <= 1)
                        {
                            Vertical = false;
                        }
                        else
                        {
                            Vertical = true;
                        }
                        colider = true;
                        change2 = true;
                        Goo = true;
                        print("Vertical: " + Vertical);
                    }
                }
            }
        }
        if (change2)
        {
            change2 = false;
        }
        else
        {
            colider = false;
            change2 = false;
            Goo = false;
        }
    }
    void PointsCalcu()
    {
        Points[0] = new Vector2(transform.position.x - ball.size.x / 2, transform.position.y + ball.size.y/2);
        Points[1] = new Vector2(transform.position.x + ball.size.x / 2, transform.position.y + ball.size.y/2);
        Points[2] = new Vector2(transform.position.x - ball.size.x / 2, transform.position.y - ball.size.y/2);
        Points[3] = new Vector2(transform.position.x + ball.size.x / 2, transform.position.y - ball.size.y/2);
    }
    void setPointFinish(bool Vertical)
    {
        if (Vertical)
        {
            pointFinish = new Vector3(pointFinish.x, pointFinish.y + ((pointFinish.y - transform.position.y) * 2), pointFinish.z);
        }
        else
        {
            pointFinish = new Vector3(pointFinish.x + ((pointFinish.x + transform.position.x)*2), pointFinish.y, pointFinish.z);
        }
    }
}
