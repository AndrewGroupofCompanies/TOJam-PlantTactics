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
    public List<Unit> units;
    private List<HighlitTile> highlitTiles;
    public HighlitTile tilePrefab;
    // Start is called before the first frame update
    void Awake()
    {
        highlitTiles = new List<HighlitTile>();
        grid = gameObject.GetComponent<Grid>();
        primaryMap = transform.Find("primary").GetComponent<Tilemap>();
        colliderMaps = gameObject.GetComponentsInChildren<Transform>()
            .Where( x => x.CompareTag("Collidable"))
            .Select( x => x.GetComponent<Tilemap>())
            .ToList();

    }
    void Start()
    {

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
        Debug.Log(colliderMaps);
        Debug.Log(coords);

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

    public void HighlightTiles(List<Vector2Int> tiles) {
        tiles.ForEach(tile => HighlightTile(tile));
    }

    private void HighlightTile(Vector2Int tile) {
        HighlitTile t = Instantiate(tilePrefab, new Vector3(tile.x + 0.5f, tile.y + 0.5f, 0), Quaternion.identity);
        highlitTiles.Add(t);
    }

    private void ClearHighlights() {
        highlitTiles.ForEach(tile => Destroy(tile));
    }

    public List<Vector2Int> GetNeighbours(Vector2Int coords) {
        var returnList = new List<Vector2Int>();

        returnList.Add(new Vector2Int(coords.x - 1, coords.y));
        returnList.Add(new Vector2Int(coords.x + 1, coords.y));
        returnList.Add(new Vector2Int(coords.x, coords.y - 1));
        returnList.Add(new Vector2Int(coords.x, coords.y + 1));

        return returnList;
    }
}
