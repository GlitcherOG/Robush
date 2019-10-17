using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Interact"))
        {
            Ray interactionRay;
            interactionRay = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
            RaycastHit hitiInfo;
            if (Physics.Raycast(interactionRay, out hitiInfo, 10))
            {
                switch (hitiInfo.collider.tag)
                {
                    case "NPC":
                        Dialogue dlg = hitiInfo.transform.GetComponent<Dialogue>();
                        if(dlg != null)
                        {
                            dlg.showDlg = true;

                            Time.timeScale = 0;
                            Cursor.visible = true;
                            Cursor.lockState = CursorLockMode.None;
                        }
                        Debug.Log("Talk to Npc");
                    break;
                    case "Item":
                        Debug.Log("Pick up Item");
                    break;
                }
            }
        }
    }
}
