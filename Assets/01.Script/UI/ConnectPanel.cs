using System;
using System.Net;
using System.Net.Sockets;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using DG.Tweening;
using UnityEngine.SceneManagement;

public enum PanelRole
{
    Host,
    Client
}

public class ConnectPanel : MonoBehaviour
{

    [SerializeField] private TMP_InputField _ipInput, _portInput;
    [SerializeField] private Button _connectBtn, _closeBtn;

    private CanvasGroup _canvasGroup;
    private PanelRole _role;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _closeBtn.onClick.AddListener(() => SetActive(false));
        _connectBtn.onClick.AddListener(HandleConnectClick);
    }



    public void OpenPanel(PanelRole role)
    {
        _role = role;
        string ip = FindIPAddress();
        _ipInput.text = string.IsNullOrEmpty(ip) ? "127.0.0.1" : ip;
        _portInput.text = "9999";
        SetActive(true);
    }

    private string FindIPAddress()
    {
        var host = Dns.GetHostEntry(Dns.GetHostName());//호스트 이름을 가져와 DNS값을 가져온다
        Debug.Log(Dns.GetHostEntry(Dns.GetHostName()));
        try
        {
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork) // 호스트의 IP목록을돌아 IPv4를 찾는다.
                {
                    return ip.ToString();
                }
            }
        }
        catch (Exception ex)
        {
            Debug.LogWarning(ex.Message);
        }
        return null;
    }

    private void HandleConnectClick()
    {
        if (SetUpNetworkpassport())
        {
            if (_role == PanelRole.Host)
            {
                NetworkManager.Singleton.StartHost(); //네트우ㅝ크 서버랑 호스트가 같이 시작되는 건
                NetworkManager.Singleton.SceneManager.LoadScene(SceneName.Game,LoadSceneMode.Single);
            }
            else if (_role == PanelRole.Client)
            {
                NetworkManager.Singleton.StartClient(); //네트워크클라이언트랑 같이 시작되는 거
                SceneManager.LoadScene(SceneName.Game, LoadSceneMode.Single);
            }
        }
    }
    private void SetActive(bool v)
    {
        _canvasGroup.interactable = v;
        _canvasGroup.blocksRaycasts = v;
        float alpha = v ? 1f : 0;
        _canvasGroup.DOFade(alpha, 0.4f);
    }

    public bool SetUpNetworkpassport()
    {

        string ip = _ipInput.text;
        string port = _portInput.text;

        Regex portRegex = new Regex(@"^[0-9]{3,5}$");
        Regex ipRegex = new Regex(@"^[0-9\.]+$");

        Match protMatch = portRegex.Match(port);
        Match ipmatch = ipRegex.Match(ip);

        if (!protMatch.Success || !ipmatch.Success)
        {
            Debug.LogError("Wrong ip or port");
            return false;
        }
        NetworkManager.Singleton.GetComponent<UnityTransport>().SetConnectionData(
            ip, (ushort)int.Parse(port));
        return true;

    }

}
