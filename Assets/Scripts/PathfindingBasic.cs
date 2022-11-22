using Unity.VisualScripting;
using UnityEngine;

public class PathfindingBasic : MonoBehaviour
{
    // THIS IS WORKING FOR NOT BUT IT IS FAR FROM PERFECT

    MapGenerator mapGenerator;

    private void Awake()
    {
        mapGenerator = GameObject.Find("GameController").GetComponent<MapGenerator>();
    }
    
    private void FixedUpdate()
    {
        Vector3 left = -transform.right;
        Vector3 right = transform.right;
        Vector3 forward = -transform.up; // maybe make it just "up" and turn the transform down?

        RaycastHit2D rayLeft = Physics2D.Raycast(transform.position, left, mapGenerator.mapWidth); // make raycast shorter if there are performance issues (if you do that, add "if 0 something something")
        RaycastHit2D rayRight = Physics2D.Raycast(transform.position, right, mapGenerator.mapWidth);
        RaycastHit2D rayForward = Physics2D.Raycast(transform.position, forward, mapGenerator.mapWidth);
        
        if (rayForward.distance <= rayRight.distance && rayForward.distance <= rayLeft.distance)
        {
            if (rayLeft.distance > rayRight.distance)
            {
                turnLeft();
            }
            else if (rayRight.distance > rayLeft.distance)
            {
                turnRight();
            }
        }
        
        moveForward();

        if (Input.GetKey(KeyCode.Space))
        {
            Debug.DrawRay(transform.position, left * mapGenerator.mapWidth, Color.green, 5);
            Debug.DrawRay(transform.position, right * mapGenerator.mapWidth, Color.green, 5);
            Debug.DrawRay(transform.position, forward * mapGenerator.mapWidth, Color.green, 5);

            Debug.Log(rayLeft.distance + "left");
            Debug.Log(rayRight.distance + "right");
            Debug.Log(rayForward.distance + "forward");
        }
    }

    void turnLeft()
    {
        gameObject.transform.Rotate(0,0, -90);
    }
    void turnRight()
    {
        gameObject.transform.Rotate(0, 0, 90);
    }
    void moveForward()
    {
        gameObject.transform.position += -transform.up * Time.fixedDeltaTime; // fixed?
    }
}
