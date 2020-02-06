using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Physics Component of player cube
    public Rigidbody rb;
    //Forces to set in inspector
    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;

    private bool isRight = false;
    private bool isLeft = false;
    private bool replayMode = false;

    private Invoker invoker;
    private Command noMovement;
    private Command currentCommand;

    void Start()
    {
        invoker = new Invoker();
        if (Invoker.log.Count != 0)
        {
            Debug.Log("LOG CONTAINS " + Invoker.log.Count + " COMMANDS");
            replayMode = true;
        }
        noMovement = new NoMovement();
        invoker.SetCommand(noMovement, Time.timeSinceLevelLoad, true);
    }

    // FixedUpdate is called evenly across framerates
    void FixedUpdate()
    {
        //Get the rigidbody by FORCE
        
        if (replayMode == true)
        {
            if (Invoker.log.Count != 0 && Invoker.log.Peek() != null)
            {
                if (Invoker.log.Peek().timeStart <= Time.timeSinceLevelLoad)
                {
                    currentCommand = Invoker.log.Dequeue();
                    currentCommand.playerBody = GetComponent<Rigidbody>();
                    invoker.SetCommand(currentCommand, Time.timeSinceLevelLoad, true);
                    //Debug.Log("Changed active movement");
                }

                if (currentCommand != null && currentCommand.timeEnd <= Time.timeSinceLevelLoad)
                {
                    invoker.SetCommand(noMovement, Time.timeSinceLevelLoad, true);
                }

            } 
        }
        else
        {
            if (Input.GetKeyDown("d"))
            {
                Command moveRight = new MoveRight(rb, sidewaysForce);
                invoker.SetCommand(moveRight, Time.timeSinceLevelLoad);
            }
            if (Input.GetKeyDown("a"))
            {
                Command moveLeft = new MoveLeft(rb, sidewaysForce);
                invoker.SetCommand(moveLeft, Time.timeSinceLevelLoad);
            }

            if (Input.GetKeyUp("d"))
            {
                invoker.Clear("D");
                //Debug.Log("D up");
            }

            if (Input.GetKeyUp("a"))
            {
                invoker.Clear("A");
                //Debug.Log("A up");
            }
        }
        if (rb.position.y < -1f)
        {
            //End the game if the player goes off the edge
            if (replayMode == true)
                Invoker.log.Clear();
            FindObjectOfType<GameManager>().EndGame();
        }

        rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        invoker.ExecuteCommand();

    }
}
