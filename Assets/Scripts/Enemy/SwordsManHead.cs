using UnityEngine;

public class SwordsManHead : MonoBehaviour
{
    float initTime = 0;
    void Start()
    {
        initTime = Time.time;   
    }

    // Update is called once per frame
    void Update()
    {
        if (initTime + 2 < Time.time)
        {
            Destroy(gameObject);
        }
    }
}
