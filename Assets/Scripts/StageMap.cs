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
    private Tilemap unitsMap;
    public List<Unit> units;
    // Start is called before the first frame update
    void Start()
    {
        grid = gameObject.GetComponent<Grid>();
        primaryMap = transform.Find("primary").GetComponent<Tilemap>();
        unitsMap = transform.Find("StartingPos").GetComponent<Tilemap>();
        colliderMaps = gameObject.GetComponentsInChildren<Transform>()
            .Where( x => x.CompareTag("Collidable"))
            .Select( x => x.GetComponent<Tilemap>())
            .ToList();

        Debug.Log(TileHasObstacle(new Vector2Int(2, 2))); // false
        Debug.Log(TileHasObstacle(new Vector2Int(5, 2))); 
        Debug.Log(TileHasObstacle(new Vector2Int(-1, 0))); 

        Debug.Log("okay!");
        units = collectUnits();
    }

    public List<Unit> collectUnits() {
        List<Unit> unitList = new List<Unit>();
        Unit[] unitsCollected = transform.GetComponentsInChildren<Unit>();
        foreach(Unit u in unitsCollected)
        {
            Debug.Log(u);
            unitList.Add(u);
        }
        return unitList;
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

    private void LoadUnits()
    {
        // get all the units in the `unitsMap`
        // iterate over the tiles that have a unit in them
        // 
    }
}
