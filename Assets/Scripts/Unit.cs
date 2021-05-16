using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private Player belongsTo;

    private Vector2Int coords = new Vector2Int(0, 0);
    private Vector2Int destination;

    public bool exhausted;
    public StageMap grid;
    private HashSet<Vector2Int> accessibleTiles;

    private Movement movementState;
    private int maxSteps = 4;

    enum Movement { STATIC, MOVING };

    void Awake()
    {
        exhausted = false;
        accessibleTiles = new HashSet<Vector2Int>();
    }
    // Start is called before the first frame update
    void Start()
    {
        SetAccessibleTiles();

        grid.HighlightTiles(
            new List<Vector2Int>(accessibleTiles)
        );
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePos();
    }

    private void UpdatePos() {
        if (coords == destination) {
            movementState = Movement.STATIC;
        } else if (movementState == Movement.MOVING) {

        }
    }

    public void MoveTo(Vector2Int newCoords)
    {
        destination = newCoords;
        movementState = Movement.MOVING;
    }

    public bool BelongsTo(Player player) {
        return belongsTo == player;
    }

    public bool IsSelectable() {
        return true;
    }

    public void Exhaust() {
        exhausted = true;
    }

    public void WakeUp() {
        exhausted = false;
    }

    private void SetAccessibleTiles() {
        List<Vector2Int> currentLayer;
        var previousLayer = new List<Vector2Int>();
        var steps = maxSteps;

        previousLayer.Add(coords);

        while (steps >= 0) {
            currentLayer = new List<Vector2Int>();

            // still gotta deduplicate
            previousLayer.ForEach(tile => {
                if (!grid.TileHasObstacle(tile)) {
                    accessibleTiles.Add(tile);
                    grid.GetNeighbours(tile).ForEach(tile => {
                        if (!previousLayer.Contains(tile) && !currentLayer.Contains(tile)) {
                            currentLayer.Add(tile);
                        }
                    });
                }                
            });
            previousLayer = currentLayer;

            steps--;
        }
    }
}
