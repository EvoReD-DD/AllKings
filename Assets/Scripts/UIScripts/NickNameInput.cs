using UnityEngine;
using UnityEngine.UI;

public class NickNameInput : MonoBehaviour
{
    [SerializeField] private Text nickNamePlaceHolder;
    [SerializeField] private InputField inputName;
    [SerializeField] private GameObject playerChoiceMenu;
    [SerializeField] private GameObject errorEnterNick;
    private int initialLvl = 1;
    public void InputNickName()
    {
        if (inputName.text != "")
        {
            Debug.Log("OK");
            nickNamePlaceHolder.text = inputName.text;
            SaveData.lvl = initialLvl;
            SaveData.nickName = inputName.text;
            this.gameObject.SetActive(false);
            playerChoiceMenu.SetActive(true);
        }
        else
        {
            errorEnterNick.SetActive(true);
            Invoke("CloseWindow", 2f);
        }
    }
    private void CloseWindow()
    {
        errorEnterNick.SetActive(false);
    }
}
