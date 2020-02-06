using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    public float timeStart;
    public float timeEnd;
    public Rigidbody playerBody;
    public abstract void Execute();
    public abstract string GetName();
}

class MoveLeft : Command
{
    //Rigidbody playerBody;
    float _force;

    public MoveLeft(Rigidbody player, float force)
    {
        playerBody = player;
        _force = force;
    }
    public override void Execute()
    {
        playerBody.AddForce(-_force * Time.deltaTime, 0, 0,
                ForceMode.VelocityChange);
    }

    public override string GetName()
    {
        return "MoveLeft";
    }
}

class MoveRight : Command
{
    //Rigidbody playerBody;
    float _force;

    public MoveRight(Rigidbody player, float force)
    {
        playerBody = player;
        _force = force;
    }
    public override void Execute()
    {
        playerBody.AddForce(_force * Time.deltaTime, 0, 0,
                ForceMode.VelocityChange);
    }

    public override string GetName()
    {
        return "MoveRight";
    }
}

class NoMovement : Command
{
    //Rigidbody playerBody;
    float _force;

    
    public override void Execute()
    {
        
    }

    public override string GetName()
    {
        return "MoveRight";
    }
}