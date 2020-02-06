using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invoker
{
    private Command m_Command;
    private Command noCommand = new NoMovement();
    private float time;

    public static Queue<Command> log = new Queue<Command>();

    public void SetCommand(Command command, float timeStart, bool isReplay = false)
    {
        m_Command = command;
        m_Command.timeStart = Time.timeSinceLevelLoad;
        time = timeStart;
        if (!isReplay)
            log.Enqueue(command);
    }

    public void ExecuteCommand()
    {
        m_Command.Execute();
    }

    public void Clear(string key = "s")
    {
        m_Command.timeEnd = Time.timeSinceLevelLoad;
        m_Command = noCommand;
        if (key != "s")
            Debug.Log(key + " held for " + (Time.timeSinceLevelLoad - time) + " seconds");
    }
}
