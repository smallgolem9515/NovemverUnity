using UnityEngine;
using UnityEngine.XR.ARFoundation;

//[RequireComponent(typeof(ARTrackedImageManager))] //�������� ǥ��
//�� ������Ʈ�� ������ ������ ������Ʈ�� �ڵ����� �������� ������ �����Ѵ�.
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
        //���� �߰��� image
        foreach(var item in args.added)
        {

        }

        //���ŵ� image
        foreach (var item in args.added)
        {

        }

        //���ŵ� image
        foreach (var item in args.added)
        {

        }
    }
}
