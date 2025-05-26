using UnityEngine;

public class weaponCamera : MonoBehaviour
{
    public GameObject mainCamera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        gameObject.transform.position = mainCamera.transform.position;
        gameObject.transform.rotation = mainCamera.transform.rotation;
    }
}
