using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyPadPower2 : MonoBehaviour
{
    [SerializeField] private GameObject keyPadHolder;
    [SerializeField] private Image inputBox;
    [SerializeField] private VehicleUpgradeObject vehicleUpgrade;
    [SerializeField] private TextMeshProUGUI NumberInput;
    [SerializeField] private int passwordLength;
    [SerializeField] private string correctPassword;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float interactionRange;
    [SerializeField] private Animator anim;
    [SerializeField] private QuestPuzzle2 quest;
    [SerializeField] private GameObject dialogueDoor;
    [SerializeField] private DialogueTrigger trigger;
    public string interactMessage;
    private bool inKeyPad;
    public bool correctCodePuzzle2;
    private MouseLook fpsView;
    private InteractionManager interact;
    

    private void Start()
    {
        correctCodePuzzle2 = false;
        fpsView = FindObjectOfType<MouseLook>();
        interact = FindObjectOfType<InteractionManager>();
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.E))
        {
            return;
        }

        if (Physics.CheckSphere(transform.position, interactionRange, playerLayer) && inKeyPad)
        {
            keyPadHolder.SetActive(false);
            inKeyPad = false;
            Cursor.lockState = CursorLockMode.Locked;
            fpsView.enabled = true;
        }
        else if (Physics.CheckSphere(transform.position, interactionRange, playerLayer) && !inKeyPad)
        {
            keyPadHolder.SetActive(true);
            inKeyPad = true;
            Cursor.lockState = CursorLockMode.None;
            fpsView.enabled = false;
        }
    }

    private void OnMouseOver()
    {
        if (Physics.CheckSphere(transform.position, interactionRange, playerLayer) && enabled)
        {
            interact.ShowInteractMessage(interactMessage);
        }
    }

    private void OnMouseExit()
    {
        interact.HideInteractMessage();
    }

    public void OkButton()
    {
        if (NumberInput.text == correctPassword)
        {
            vehicleUpgrade.enabled = true;
            dialogueDoor.SetActive(true);
            trigger.enabled = false;
            inputBox.color = Color.green;
            anim.SetTrigger("Go away");
            inKeyPad = false;
            Cursor.lockState = CursorLockMode.Locked;
            fpsView.enabled = true;
            KeyPadPower2 thisKeypad = GetComponent<KeyPadPower2>();
            enabled = false;
            for (int i = 0; i < quest.waypoint.Length; i++)
            {
                Destroy(quest.waypoint[i]);
                Destroy(quest.meter[i]);
            }
        }
    }
    public void BackSpaceButton()
    {
        NumberInput.text = "";
    }
    public void Button1()
    {
        if (NumberInput.text.Length >= passwordLength) return;
        NumberInput.text += "1";
    }
    public void Button2()
    {
        if (NumberInput.text.Length >= passwordLength) return;
        NumberInput.text += "2";
    }
    public void Button3()
    {
        if (NumberInput.text.Length >= passwordLength) return;
        NumberInput.text += "3";
    }
    public void Button4()
    {
        if (NumberInput.text.Length >= passwordLength) return;
        NumberInput.text += "4";
    }
    public void Button5()
    {
        if (NumberInput.text.Length >= passwordLength) return;
        NumberInput.text += "5";
    }
    public void Button6()
    {
        if (NumberInput.text.Length >= passwordLength) return;
        NumberInput.text += "6";
    }
    public void Button7()
    {
        if (NumberInput.text.Length >= passwordLength) return;
        NumberInput.text += "7";
    }
    public void Button8()
    {
        if (NumberInput.text.Length >= passwordLength) return;
        NumberInput.text += "8";
    }
    public void Button9()
    {
        if (NumberInput.text.Length >= passwordLength) return;
        NumberInput.text += "9";
    }
    
}
