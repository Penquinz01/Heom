using UnityEngine;

public class playeranimtemp : MonoBehaviour
{
    private Animator anim;

    private void Start() {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.D)) {
            anim.SetBool("isWalk", true);
        }
        else {
            anim.SetBool("isWalk", false);
        }
        if (Input.GetKey(KeyCode.Space)) {
            anim.SetBool("isAttack", true);
        }
        else {
            anim.SetBool("isAttack", false);
        }
    }
}
