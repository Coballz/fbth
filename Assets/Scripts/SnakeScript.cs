using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeScript : MonoBehaviour
{
    public GameObject snakeBody;
    public List<GameObject> body;
    private int sizeBody = 5;
    private int instantiateHelper = 1;
    private float moveSpeed = 5.0f;

    private enum moveDir
    {
        UP, LEFT, DOWN, RIGHT
    }

    private moveDir direction;
    // Start is called before the first frame update
    void Start()
    {
        InitializeVariables();
    }

    // Update is called once per frame
    void Update()
    {
        MoveSnake();
    }

    void InitializeVariables()
    {
        direction = moveDir.UP;
        body = new List<GameObject>();
        for (int i = 0; i < sizeBody; i++)
        {
            GameObject copy = Instantiate(snakeBody, new Vector3(transform.position.x, transform.position.y, transform.position.z - instantiateHelper), Quaternion.identity);
            body.Add(copy);
            instantiateHelper++;
        }
    }

    void MoveSnake()
    {
        Vector3 oldPosition = transform.position - transform.forward;

        TurnHead();
        
        foreach (GameObject bodyPart in body)
        {
                Vector3 nextPartPos = bodyPart.transform.position - (transform.forward * 0.9f);
                bodyPart.transform.position = oldPosition;
                oldPosition = nextPartPos;
        }

        SetDirection();
    } //Uses void methods TurnHead and SetDirection

    void TurnHead()
    {
        if (direction == moveDir.UP)
            transform.Translate(transform.forward * moveSpeed * Time.deltaTime);

        else if (direction == moveDir.LEFT)
            transform.Translate(transform.right * moveSpeed * Time.deltaTime);

        else if (direction == moveDir.DOWN)
            transform.Translate(-transform.forward * moveSpeed * Time.deltaTime);

        else if (direction == moveDir.RIGHT)
            transform.Translate(-transform.right * moveSpeed * Time.deltaTime);
    }   //Turns the head of the snake when it reaches "pathnodes"

    void SetDirection()
    {
        if (transform.position.z >= 0 && direction == moveDir.UP)
        {
            transform.Rotate(0, -90, 0);
            direction = moveDir.LEFT;
        }

        else if (transform.position.x <= -11 && direction == moveDir.LEFT)
        {
            transform.Rotate(0, -90, 0);
            direction = moveDir.DOWN;
        }

        else if (transform.position.z <= -35 && direction == moveDir.DOWN)
        {
            transform.Rotate(0, -90, 0);
            direction = moveDir.RIGHT;
        }

        else if (transform.position.x >= 11 && direction == moveDir.RIGHT)
        {
            transform.Rotate(0, -90, 0);
            direction = moveDir.UP;
        }
    } //Attempts to follow the movement 
}
