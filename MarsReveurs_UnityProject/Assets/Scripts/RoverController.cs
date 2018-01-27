﻿using UnityEngine;

public class RoverController : MonoBehaviour
{
    public static int CurrentTick;

    [SerializeField]
    private int tickRate = 1;

    [SerializeField]
    private int maxTicks = 1024;

    private RoverScript script;

    private Meteor.Core.Utils.Ticker ticker;

    private void Awake()
    {
        RoverController.CurrentTick = 0;
        this.script = new RoverScript(this.maxTicks);
    }

	void Start ()
    {
        this.ticker = new Meteor.Core.Utils.Ticker(this.OnTick, 1*this.tickRate);
	}

	void Update ()
    {
        this.ticker.Update();
	}

    private void OnTick(double deltaTime)
    {
        RoverController.CurrentTick++;
        this.script.Tick();
    }
}
