using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ship : MonoBehaviour {
    // Properties
    public string Name;
    public int LongMove; // the ratio between long:short is 8.5:5.7cm so approx 3:2 // this is 0.75
    public int ShortMove; // this is 0.5;
    public int CargoSpace;
    public int numberOfCannons;
    public int Cost;
    public int Masts;
    public GameObject[] CannonObjects;
    public List<Cannon> Cannons;
    public List<Cargo> CargoHold;

    public GameObject Disc;
    
    private GameObject moveDisc;
    private float moveDistance;

    public enum State { Selected, Attacking, Moving, Idle };
    private State state;

    public struct Cannon
    {
        public float roll;
        public float longRange; // not sure if I should change this to bool
        public float shortRange;
        public GameObject cannon;
        public GameObject shootDisc;
    }

    public struct Cargo
    {
        public float value;
    }

	// Use this for initialization
	void Start () {
        moveDistance = LongMove * 0.75f + ShortMove * 0.5f;

        // initialize cannons
        Cannons = new List<Cannon>(numberOfCannons); 
        for (int i = 0; i < numberOfCannons; i++)
        {
            Cannon c = new Cannon();
            c.roll = 3;
            c.shortRange = 1;
            c.longRange = 0;
            c.cannon = CannonObjects[i];

            GameObject d = (GameObject)Instantiate(Disc);
            Color r = Color.red;
            r.a = 0.25f;
            d.renderer.material.color = r;
            d.transform.parent = c.cannon.transform;
            d.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            d.transform.localPosition = Vector3.zero;
            c.shootDisc = d;
            c.shootDisc.SetActive(false);

            Cannons.Add(c);
        }

        // intialize cargo hold
        CargoHold = new List<Cargo>(CargoSpace);
        for (int i = 0; i < CargoSpace; i++)
        {
            Cargo c = new Cargo();
            c.value = 0; // empty cargo
            CargoHold.Add(c);
        }

        // initialize move ring
        moveDisc = (GameObject)Instantiate(Disc);
        moveDisc.transform.localScale = new Vector3(moveDistance, moveDistance, moveDistance);
        moveDisc.transform.parent = this.transform;
        moveDisc.transform.localPosition = Vector3.zero;
        Color g = Color.green;
        g.a = 0.25f;
        moveDisc.renderer.material.color = g;
        moveDisc.SetActive(false);

        // state
        state = State.Idle;
	}

    // Update is called once per frame
    void Update()
    {
		
	}
	
	void OnMouseDown () {
        switch (state)
        {
            case State.Idle:
                // select the unit
                // display how far it can move/attack
                // display all properties of the unit, cargo hold, health, etc.
                state = State.Selected;

                // display attack rings
                foreach (Cannon c in Cannons)
                {
                    c.shootDisc.SetActive(true);
                }

                // display move ring
                moveDisc.SetActive(true);
                break;
            case State.Selected:
                state = State.Idle;
                // hide all info
                // hide attack rings
                foreach (Cannon c in Cannons)
                {
                    c.shootDisc.SetActive(false);
                }

                // hide move ring
                moveDisc.SetActive(false);
                break;
        }
	}


	
}
