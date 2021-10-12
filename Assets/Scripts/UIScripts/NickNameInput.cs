using UnityEngine;
using UnityEngine.UI;

public class NickNameInput : MonoBehaviour
{
    [SerializeField] private Text nickNamePlaceHolder;
    [SerializeField] private InputField inputName;
    [SerializeField] private GameObject playerChoice;
    

   
    public void InputNickName()
    {
        nickNamePlaceHolder.text = inputName.text;
        this.gameObject.SetActive(false);
        playerChoice.SetActive(true);
    }
}
