using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunScript : MonoBehaviour
{
    Vector3 startPosition;
    private bool up = true;
    private float terrainSquareSize = 250.0f;
    private float maxHeight;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        maxHeight = Mathf.Sqrt(2 * ((0.5f * terrainSquareSize) * (0.5f * terrainSquareSize)));
    }

    // Update is called once per frame
    void Update()
    {
        float yMark = 0.5f;
        if (!up)
            yMark *= -0.5f;

        transform.Translate((Vector3.forward + new Vector3(0, yMark, 0)));
        GetComponent<Light>().intensity += 0.002f * yMark;

        if (transform.position.z > 0 && up)
            up = false;
        else if (transform.position.y <= startPosition.y && !up)
            up = true;
        if (transform.position.x < startPosition.x - terrainSquareSize && transform.position.z > startPosition.z + terrainSquareSize)
            transform.position = startPosition;
    }
}
