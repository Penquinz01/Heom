using System.Collections;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] private int id;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(TriggerEvent());
        }
    }
    IEnumerator TriggerEvent()
    {
        yield return new WaitForSeconds(0.5f);
        GameManager.Instance.Opengates(id);
        Destroy(gameObject);
    }
}
