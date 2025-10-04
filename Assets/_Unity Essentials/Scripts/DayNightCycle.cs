using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    
    [SerializeField] float rotationSpeed = 1f;


    void Update()
    {
        transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);        
    }
}
