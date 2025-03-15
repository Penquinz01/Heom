using UnityEngine;

public class Gates : MonoBehaviour
{
    [SerializeField] private int id;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.Instance.OnOpengates += Instance_OnOpengates;
    }

    private void Instance_OnOpengates(int obj)
    {
        if (this.id == obj)
        {
            Destroy(gameObject);
        }
    }
}
