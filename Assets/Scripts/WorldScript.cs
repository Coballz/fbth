using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScript : MonoBehaviour
{
    private List<Material> materials;
    private GameObject[] leaves;
    private GameObject[] variableLeaves;
    public GameObject snake;

    // Start is called before the first frame update
    void Start()
    {
        GetAllGreenMaterials();
        RandomizeLeaves();
        RandomizeLeavesWithVariableSizes();
        CreateSnake();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GetAllGreenMaterials()
    {
        materials = new List<Material>();
        materials.Add(Resources.Load("Materials/Green1", typeof(Material)) as Material);
        materials.Add(Resources.Load("Materials/Green2", typeof(Material)) as Material);
        materials.Add(Resources.Load("Materials/Green3", typeof(Material)) as Material);
    }

    void RandomizeLeaves()
    {
        leaves = GameObject.FindGameObjectsWithTag("Leaf");
        foreach (GameObject leaf in leaves)
        {
            float random = Random.value;
            if (random <= 0.33f)
                leaf.GetComponent<MeshRenderer>().material = materials[0];
            else if (random <= 0.66f)
                leaf.GetComponent<MeshRenderer>().material = materials[1];
            else
                leaf.GetComponent<MeshRenderer>().material = materials[2];
        }
    }

    void RandomizeLeavesWithVariableSizes()
    {
        variableLeaves = GameObject.FindGameObjectsWithTag("VarSizeLeaf");
        foreach (GameObject leaf in variableLeaves)
        {
            float random = Random.value;
            if (random <= 0.33f)
                leaf.GetComponent<MeshRenderer>().material = materials[0];
            else if (random <= 0.66f)
                leaf.GetComponent<MeshRenderer>().material = materials[1];
            else
                leaf.GetComponent<MeshRenderer>().material = materials[2];
        }

        foreach (GameObject leaf in variableLeaves)
        {
            float random = Random.value;
            if (random <= 0.4f)
                leaf.transform.localScale *= 1.1f;
            else if (random <= 0.8f)
                leaf.transform.localScale *= 0.9f;
        }
    }

    void CreateSnake()
    {
        Instantiate(snake, new Vector3(11, snake.transform.localScale.y * 0.5f, -35), Quaternion.identity);
    }
}
