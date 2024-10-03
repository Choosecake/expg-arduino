using Unity.VisualScripting;
using UnityEngine;

public class CoverPieces : MonoBehaviour
{
    public GameObject planePrefab;  
    public GameObject background;
    public int rows = 5;            
    public int columns = 5;         
    public float spacing = 1.0f;    

    private GameObject[,] gridArray;

    void Start()
    {
        background.SetActive(true);

        gridArray = new GameObject[rows, columns]; // Initialize the array
        Vector3 startPosition = transform.position;

        // Loop through each row and column
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                // Calculate the position for each plane
                Vector3 position = startPosition + new Vector3(col * spacing, row * spacing, 0);

                // Instantiate the plane at the calculated position
                GameObject plane = Instantiate(planePrefab, position, Quaternion.identity);
                plane.transform.SetParent(this.transform);
                plane.transform.rotation = Quaternion.Euler(new Vector3(-90, 0, 0));

                // Store the plane in the array
                gridArray[row, col] = plane;
            }
        }
    }
}
