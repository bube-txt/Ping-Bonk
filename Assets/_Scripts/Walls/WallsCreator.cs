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
    private float getScreenHeight()
    {
        return Camera.main.orthographicSize * 2.0f;

    }
    private float getScreenWidth()
    {
        return getScreenHeight() * Screen.width / Screen.height;
    }
    void Start()
    {
        // Create top wall
        Instantiate(topWall, new Vector2(0, getScreenHeight() / 2), Quaternion.identity);
        topWall.transform.localScale = new Vector2(getScreenWidth(), 0.5f);
        
        // Create bottom wall
        Instantiate(bottomWall, new Vector2(0, -getScreenHeight() / 2), Quaternion.identity);
        bottomWall.transform.localScale = new Vector2(getScreenWidth(), 0.5f);
        
        // Create left wall
        Instantiate(leftWall, new Vector2(-getScreenWidth()/2, 0), Quaternion.identity);
        leftWall.transform.localScale = new Vector2(0.5f, getScreenHeight());
        
        // Create right wall
        Instantiate(rightWall, new Vector2(getScreenWidth()/2, 0), Quaternion.identity);
        rightWall.transform.localScale = new Vector2(0.5f, getScreenHeight());
    }
}
