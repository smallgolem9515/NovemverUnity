using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;

public class AnchorMarker : MonoBehaviour
{
    [SerializeField] ARRaycastManager _arRaycastManager;
    [SerializeField] ARAnchorManager _arAnchorManager;
    [SerializeField] Camera _xrCamera;
    [SerializeField] InputActionReference _tapStartPosition;
    private List<ARRaycastHit> _hits = new List<ARRaycastHit>(2);

    private void Start()
    {
        _tapStartPosition.action.started += OnTouch;
    }
    private void OnTouch(InputAction.CallbackContext context)
    {
        Vector2 tapposition = context.ReadValue<Vector2>();
        if (_arRaycastManager.Raycast(_xrCamera.ScreenPointToRay(tapposition),_hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes))

            //Planes�� 4���� Ʈ��Ŀ��Ÿ���� �����ϰ��ִ�.
        {
            if (_hits[0].trackable.TryGetComponent(out ARPlane plane))
            {
                _arAnchorManager.AttachAnchor(plane, _hits[0].pose);
            }
        }
    }

}
