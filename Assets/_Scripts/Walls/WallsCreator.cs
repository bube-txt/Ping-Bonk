using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// Create walls for playing scene
/// Walls repeat screen resolution
/// </summary>
public class WallsCreator : MonoBehaviour
{
    [SerializeField] private GameObject topWall;
    [SerializeField] private GameObject bottomWall;
    [SerializeField] private GameObject leftWall;
    [SerializeField] private GameObject rightWall;
    void Start()
    {
        int x = Screen.currentResolution.width,
            y = Screen.currentResolution.height;

        // Create top wall
        Instantiate(topWall, new Vector2(0,x / x * 5), Quaternion.identity);
        topWall.transform.localScale = new Vector3(x/x*5.6f,0.5f,0);
        
        // Create bottom wall
        Instantiate(bottomWall, new Vector2(0,x / x * -5), Quaternion.identity);
        bottomWall.transform.localScale = new Vector3(x/x*5.6f,0.5f,0);
        
        // Create left wall
        Instantiate(leftWall, new Vector2(x / x * -2.8f,0), Quaternion.identity);
        leftWall.transform.localScale = new Vector3(0.5f,y/y*10f,0);
        
        // Create right wall
        Instantiate(rightWall, new Vector2(x / x * 2.8f,0), Quaternion.identity);
        rightWall.transform.localScale = new Vector3(0.5f,y/y*10f,0);
    }
}
