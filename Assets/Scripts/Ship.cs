using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ship : MonoBehaviour {
    // Properties
    public string Name;
    public int LongMove; // the ratio between long:short is 8.5:5.7cm so approx 3:2
    public int ShortMove;
    public int CargoSpace;
    public int Cost;
    public int Masts;
    public List<Cannon> Cannons;
    public List<Cargo> CargoHold;

    private float moveDistance;

    public struct Cannon
    {
        float roll;
        float longRange;
        float shortRange;
    }

    public struct Cargo
    {
        float value;
    }

	// Use this for initialization
	void Start () {
        moveDistance = LongMove * 3 + ShortMove * 2;


	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseDown () {
		// select the unit
		// display how far it can move/attack
		
	}
	
}
