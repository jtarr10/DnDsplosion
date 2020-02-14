using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameBoardEntity : MonoBehaviour
{
    Vector3 currentTilePosition;

    private bool isMoving;
    private Tilemap tilemap;

    public GameBoardEntity()
    {
        currentTilePosition = new Vector3(0, 0, 0);
    }

    public GameBoardEntity(int x, int y)
    {
        currentTilePosition = new Vector3(x, y, 0);
        transform.localPosition = currentTilePosition;
        SnapToTileCenter();
    }

    // Start is called before the first frame update
    void Start()
    {
        isMoving = false;
        SnapToTileCenter();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            Move(Vector3.up);
        if (Input.GetKeyDown(KeyCode.DownArrow))
            Move(Vector3.down);
        if (Input.GetKeyDown(KeyCode.RightArrow))
            Move(Vector3.right);
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            Move(Vector3.left);
    }

    private void SnapToTileCenter()
    {
        tilemap = transform.parent.GetComponent<Tilemap>();
        Vector3Int cellPosition = tilemap.LocalToCell(transform.localPosition);
        transform.localPosition = tilemap.GetCellCenterLocal(cellPosition);
    }

    private void Move(Vector3 directionVector)
    {
        Debug.Log("Moving the character up by " + (tilemap.cellSize.x * directionVector).ToString());
        transform.localPosition += tilemap.cellSize.x * directionVector;
        SnapToTileCenter();
    }
}
