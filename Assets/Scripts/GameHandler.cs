using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class GameHandler : MonoBehaviour {
	private Grid grid;
	//private PlayerManager playerManager;
	private List<Player> players;
	private List<Unit> allUnits;

	public static GameHandler Instance { get; private set; }
	// For now, hard-coding unit values into code - eventually will extract from Tile files

	void Awake () {
		Instance = this;
	}

	// Use this for initialization
	void Start () {
		allUnits = new List<Unit>();

		//InitPlayers();
		InitMap();
		//InitUnits();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/*
	public void InitPlayers() {
		playerManager = PlayerManager.Instance;

		playerManager.AddNewPlayer("player1", true);
		playerManager.AddNewPlayer("player2", false);

		playerManager.InitQueue();
	}

	public void InitUnits () {
		foreach(Player p in playerManager.GetPlayers()) {
			// grid.InstantiateUnits(p);
			p.CacheMyUnits();
		}
	}
	*/

	public void InitMap () {
		// set the grid
		// grid = SmartGridBehavior.Instance;
	}

	public List<Unit> GetAllUnits () {
		return allUnits;
	}

	public void AddUnit (Unit unit) {
		allUnits.Add(unit);
		// playerManager.GetPlayers().ForEach(p => p.CacheMyUnits());
	}

	public void DestroyUnit (Unit unit) {
		allUnits.Remove(unit);
		// playerManager.GetPlayers().ForEach(p => p.CacheMyUnits());
	}
}
