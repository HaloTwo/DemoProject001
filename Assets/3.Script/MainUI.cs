using UnityEngine;

public class MainUI : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]Rigidbody2D playerrid;
    [SerializeField] Animator playeranim;

    void Start()
    {
        if (playerrid.TryGetComponent(out Animator anim))
        {
            playeranim = anim;
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void JumpButton()
    {
        playerrid.AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
    }

    public void AttackButton()
    {
        playeranim.Play("attack");
    }

    public void HitButton()
    {
        playeranim.Play("hurt");
    }
}
