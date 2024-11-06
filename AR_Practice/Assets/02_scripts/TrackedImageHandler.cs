using UnityEngine;
using UnityEngine.XR.ARFoundation;

//[RequireComponent(typeof(ARTrackedImageManager))] //의존성을 표시
//이 컴포넌트를 넣으면 의존할 컴포넌트도 자동으로 딸려오고 삭제도 방지한다.
public class TrackedImageHandler : MonoBehaviour
{
    [SerializeField] ARTrackedImageManager _arTrackedImageManager;


    private void OnEnable()
    {
        _arTrackedImageManager.trackablesChanged.AddListener(OnTrackablesChanged);
    }

    private void OnDisable()
    {
        _arTrackedImageManager.trackablesChanged.RemoveListener(OnTrackablesChanged);
    }

    private void OnTrackablesChanged(ARTrackablesChangedEventArgs<ARTrackedImage> args)
    {
        //새로 추가된 image
        foreach(var item in args.added)
        {

        }

        //갱신된 image
        foreach (var item in args.added)
        {

        }

        //제거된 image
        foreach (var item in args.added)
        {

        }
    }
}
