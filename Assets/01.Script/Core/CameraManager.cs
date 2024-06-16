using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoSingleton<CameraManager>
{

    private Camera _mainCam;
    public Camera MainCam
    {
        get
        {
            if (_mainCam is null || ReferenceEquals(_mainCam, null))
                _mainCam = Camera.main;
            return _mainCam;
        }
    }
    private CameraManager()
    {

    }


}
