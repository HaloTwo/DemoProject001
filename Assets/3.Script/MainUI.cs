using UnityEngine;

public class MainUI : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]Rigidbody2D playerrid;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void JumpButton()
    {
        playerrid.AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
    }
}
