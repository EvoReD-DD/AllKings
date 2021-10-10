using UnityEngine;
using UnityEngine.UI;

public class FirstStart : MonoBehaviour
{
    [SerializeField] private GameObject nickNameInputMenu;
    [SerializeField] private Text nickNameText;
    void Start()
    {
        if (nickNameText.text != "")
        {
            nickNameInputMenu.SetActive(false);
        }
        else
        {
            nickNameInputMenu.SetActive(true);
        }
    }
}
