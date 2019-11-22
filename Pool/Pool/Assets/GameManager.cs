using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameManager : MonoBehaviour
{
    static public GameManager instance;
    public SpriteRenderer[] Wall;
    [SerializeField]
    public Vector2[][] WallPoints;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    private void Start()
    {
        WallPoints = new Vector2[4][];
        for(int a = 0; a < WallPoints.Length; a++)
        {
            WallPoints[a] = new Vector2[4];
            WallPoints[a][0] = new Vector2(Wall[a].transform.position.x - Wall[a].size.x / 2, Wall[a].transform.position.y + Wall[a].size.y/2);
            WallPoints[a][1] = new Vector2(Wall[a].transform.position.x + Wall[a].size.x / 2, Wall[a].transform.position.y + Wall[a].size.y/2);
            WallPoints[a][2] = new Vector2(Wall[a].transform.position.x - Wall[a].size.x / 2, Wall[a].transform.position.y - Wall[a].size.y/2);
            WallPoints[a][3] = new Vector2(Wall[a].transform.position.x + Wall[a].size.x / 2, Wall[a].transform.position.y - Wall[a].size.y/2);
        }
        
    }
    public Vector2 GetWallPoint(int a, int b)
    {
       // print("Objeto: " + a + " PuntoX: " + WallPoints[a][b].x + " PuntoY: " + WallPoints[a][b].y);
        return WallPoints[a][b];
    }

}
