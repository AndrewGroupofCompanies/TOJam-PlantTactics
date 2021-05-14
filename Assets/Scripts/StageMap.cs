using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class StageMap : MonoBehaviour
{
    private Grid grid;
    private List<Tilemap> colliderMaps;
    private Tilemap primaryMap;
    // Start is called before the first frame update
    void Start()
    {
        grid = gameObject.GetComponent<Grid>();
        primaryMap = transform.Find("primary").GetComponent<Tilemap>();
        colliderMaps = gameObject.GetComponentsInChildren<Transform>()
            .Where( x => x.CompareTag("Collidable"))
            .Select( x => x.GetComponent<Tilemap>())
            .ToList();

        Debug.Log(TileHasObstacle(new Vector2Int(2, 2))); // false
        Debug.Log(TileHasObstacle(new Vector2Int(5, 2))); 
        Debug.Log(TileHasObstacle(new Vector2Int(-1, 0))); 

        Debug.Log("okay!");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool TileHasObstacle(Vector2Int coords)
    {
        return colliderMaps
            .Select( map => map.GetTile(new Vector3Int(coords.x, coords.y, 0)) )
            .Any( tile => tile );
    }

    private Tile getTileInPrimaryCoords(Tilemap tilemap, Vector2Int coords)
    {
        var coords3 = new Vector3Int(coords.x, coords.y, 0);

        var worldPosition = grid.CellToLocal(coords3);

        return tilemap.GetTile<Tile>(tilemap.LocalToCell(coords3));
    }
}
