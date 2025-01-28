using System.Collections;
using UnityEngine;

public class ArenaMovement : MonoBehaviour
{

    private Vector3 rotationSpeed = new Vector3(0, 0, 0); // Velocidad de rotaci�n en cada eje
    private bool right = true;
    private GameObject cube;
    private Vector3 positionCube;
    private int secondsCube = 5;
    private bool loopOn = false;

    private void Start()
    {
        cube = GameObject.Find("CubeParry");
        //positionCube = cube.transform.position;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput > 0)
        {
            right = true;
        }
        else if (horizontalInput < 0)
        {
            right = false;
        }

        if (right)
        {
            rotationSpeed.y = 50;
        }
        else if (!right)
        {
            rotationSpeed.y = -50;
        }

        transform.Rotate(rotationSpeed * Time.deltaTime);
        /*if (!loopOn)
        {
            StartCoroutine(InstantiateCube(secondsCube));
        }*/
        
    }

    /*private IEnumerator InstantiateCube(int seconds)
    {
        loopOn = true;
        Debug.Log("Enumerator Cube");
        yield return new WaitForSeconds(seconds);
        Destroy(cube);
        Instantiate(cube, positionCube, Quaternion.identity);
        cube = GameObject.Find("CubeParry(Clone)");
        cube.name = "CubeParry";
        loopOn = false;
    }*/
}
