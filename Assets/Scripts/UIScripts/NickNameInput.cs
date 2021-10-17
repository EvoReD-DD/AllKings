using UnityEngine;
using UnityEngine.UI;

public class NickNameInput : MonoBehaviour
{
    [SerializeField] private Text nickNamePlaceHolder;
    [SerializeField] private InputField inputName;
    [SerializeField] private GameObject playerChoiceMenu;
    private int initialLvl= 1;
    

   
    public void InputNickName()
    {
        nickNamePlaceHolder.text = inputName.text;
        SaveData.lvl = initialLvl;
        SaveData.nickName = inputName.text;
        this.gameObject.SetActive(false);
        playerChoiceMenu.SetActive(true);
    }
}
