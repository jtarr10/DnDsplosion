using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameBoardEntity : MonoBehaviour
{
    Vector3Int currentTilePosition, destination, directionOfMovement; //variables detailing information about movment
    public float speed; //how fast the entity will move from its currentTilePosition to its destination

    private bool isMoving;
    private Tilemap tilemap;

    public GameBoardEntity()
    {
        currentTilePosition = new Vector3Int(0, 0, 0);
    }

    public GameBoardEntity(int x, int y)
    {
        currentTilePosition = new Vector3Int(x, y, 0);
        MoveTo(currentTilePosition);
        SnapToTileCenter();
    }

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.5f;
        tilemap = transform.parent.GetComponent<Tilemap>();
        SnapToTileCenter();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            Move(Vector3Int.up);
        if (Input.GetKeyDown(KeyCode.DownArrow))
            Move(Vector3Int.down);
        if (Input.GetKeyDown(KeyCode.RightArrow))
            Move(Vector3Int.right);
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            Move(Vector3Int.left);
    }

    private void FixedUpdate()
    {
        if (isMoving)
            ApproachDestination();
    }

    /// <summary>
    /// Moves the entity at the current set speed towards the destination. (Call once per frame to animate)
    /// </summary>
    private void ApproachDestination()
    {
        var current = transform.localPosition;
        var dest = tilemap.CellToLocal(new Vector3Int(destination.x, destination.y, 0));

        float distanceToDest = Vector2.Distance(current, dest);
        if (distanceToDest > 0.01f * speed)
        {
            Vector3 impulse = (speed * new Vector3(directionOfMovement.x, directionOfMovement.y, 0) * Time.deltaTime);
            //Debug.Log("Moving by : " + impulse.ToString() + "\ndistToTarget: " + distanceToDest.ToString());
            transform.localPosition += impulse;
        }
        else
        {
            Debug.Log("Threshold reached: Snapping to cell origin. \nDistToTarget = " + distanceToDest.ToString());
            SnapToTileCenter();
        }
    }

    /// <summary>
    /// Snaps the entity to the center coordinates of the current tile location
    /// </summary>
    private void SnapToTileCenter()
    {
        currentTilePosition = tilemap.LocalToCell(transform.localPosition);
        transform.localPosition = tilemap.GetCellCenterLocal(currentTilePosition);
        isMoving = false;
    }

    /// <summary>
    /// Moves the entity one grid square in the direction of the given unit vector
    /// </summary>
    /// <param name="directionVector"></param>
    public void Move(Vector3Int directionVector)
    {
        if (!isMoving)
        {
            destination = currentTilePosition + directionVector;
            directionOfMovement = directionVector;
            isMoving = true;
        } 
    }

    /// <summary>
    /// Moves the entity to the passed cell location (coordinates of the cell in the grid)
    /// </summary>
    /// <param name="coords">2 dimmensional coordinate on the grid</param>
    public void MoveTo(Vector3Int coords)
    {
       //find the local coordinate system vector for given cell coords
       Vector3 diff = tilemap.CellToLocal(new Vector3Int(coords.x, coords.y, 0));
       transform.localPosition += diff;
       SnapToTileCenter();
    }
}
