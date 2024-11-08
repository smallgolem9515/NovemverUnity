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
    [SerializeField] GameObject _objPrefeb;
    private List<ARRaycastHit> _hits = new List<ARRaycastHit>(2);

    private void Start()
    {
        _tapStartPosition.action.started += OnTouch;
    }
    private void OnTouch(InputAction.CallbackContext context)
    {
        Vector2 tapposition = context.ReadValue<Vector2>();
        
        if (_arRaycastManager.Raycast(_xrCamera.ScreenPointToRay(tapposition),_hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes))

            //Planes는 4개의 트랙커블타입을 포함하고있다.
        {

            if (_hits[0].trackable.TryGetComponent(out ARPlane plane))
            {
                ARAnchor aRAnchor = _arAnchorManager.AttachAnchor(plane, _hits[0].pose);
                GameObject obj = Instantiate(_objPrefeb);
                
                obj.transform.parent = aRAnchor.transform;
                obj.transform.position = Vector3.zero;
                obj.transform.rotation = aRAnchor.transform.rotation;
                obj.transform.localScale = Vector3.one / 4;

            }
        }
    }

}
