using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private Vector2Int coords;
    public bool exhausted;

    void Awake()
    {
        exhausted = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveTo(Vector2Int newCoords)
    {

    }

    public bool BelongsTo(Player player) {
        return false;
    }

    public bool IsSelectable() {
        return true;
    }

    public void Exhaust() {

    }

    public void WakeUp() {

    }
}
