using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpButton : MonoBehaviour
{
    public Button jumpButton;
    // Start is called before the first frame update
    void Start()
    {
        jumpButton = GetComponent<Button>();
        jumpButton.onClick.AddListener(QueueJump);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool canJump = false;

    void QueueJump()
    {
        canJump = true;
    }

    public bool CanJump()
    {
        if (canJump)
        {
            canJump = false;
            return true;
        }
        return canJump;
    }
}
