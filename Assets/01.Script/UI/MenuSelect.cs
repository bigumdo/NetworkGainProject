using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSelect : MonoBehaviour
{

    [SerializeField] private Button _hostBtn, _clientBtn, _closeBtn;
    [SerializeField] private ConnectPanel _connectPanel;

    private void Awake()
    {
        _hostBtn.onClick.AddListener(() => _connectPanel.OpenPanel(PanelRole.Host));
        _clientBtn.onClick.AddListener(() => _connectPanel.OpenPanel(PanelRole.Client));
    }

}
