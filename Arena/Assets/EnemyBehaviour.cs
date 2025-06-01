using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    Transform Visuals;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Visuals = this.transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        Visuals.rotation = Quaternion.Euler(0, Camera.main.transform.rotation.eulerAngles.y, 0);
    }
}
