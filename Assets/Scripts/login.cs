using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class login : MonoBehaviour
{
    public TMP_InputField usernameText;
    public TMP_InputField passwordText;
    public TMP_Text messageText;
    public void OnLogin()
    {   
        string username = usernameText.text;
        string password = passwordText.text;
        if (username == "123" && password == "123")
        {
            Debug.Log("login");
            messageText.text = "wow you did it";
            SceneManager.LoadScene("SampleScene");
        }
        else
        {
            messageText.text = "hahhahhahhahhaha";
        }
    }
}
