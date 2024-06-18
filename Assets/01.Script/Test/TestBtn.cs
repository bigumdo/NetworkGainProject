using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class TestBtn : MonoBehaviour
{

    [SerializeField] Button _hostBtn;
    [SerializeField] Button _clientBtn;

    private void Start()
    {
        _hostBtn.onClick.AddListener(HandleHostClick);
        _clientBtn.onClick.AddListener(HandleClientClick);
    }

    private void HandleHostClick()
    {
        NetworkManager.Singleton.StartHost();
    }

    private void HandleClientClick()
    {
        NetworkManager.Singleton.StartClient();
    }

}
