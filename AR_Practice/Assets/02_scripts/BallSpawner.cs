using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Readers;

public class BallSpawner : MonoBehaviour
{
    [SerializeField]
    XRInputValueReader<Vector2> _tapStartPositionInput = new XRInputValueReader<Vector2>("Tap Start Position");
    [SerializeField] GameObject _ballPrefeb;
    [SerializeField] Transform _xrCamera;

    private void Awake()
    {
        _tapStartPositionInput.inputActionReference.action.started += OnTapStartPositionInputStartted;
        //_tapStartPositionInput.inputActionReference.action.started += (context) =>
        //{
        //    Vector2 tapposition = context.ReadValue<Vector2>();
        //    Debug.Log($"Tapped {tapposition}");

        //    GameObject ball = Instantiate(_ballPrefeb, _xrCamera.position + _xrCamera.forward * 0.5f, _xrCamera.rotation);
        //    ball.GetComponent<Rigidbody>().AddForce(_xrCamera.forward * 500f, ForceMode.Force);
        //};
    }

    private void OnTapStartPositionInputStartted(InputAction.CallbackContext context)
    {
        Vector3 tapposition = context.ReadValue<Vector3>();
        Debug.Log($"Tapped {tapposition}");



        GameObject ball = Instantiate(_ballPrefeb, _xrCamera.position + _xrCamera.forward * 0.5f, _xrCamera.rotation);
        ball.GetComponent<Rigidbody>().AddForce(_xrCamera.forward * 500f, ForceMode.Force);
    }

    //private void Update()
    //{
    //    if(_tapStartPositionInput.TryReadValue(out Vector2 tapposition))
    //    {
    //        Debug.Log($"Tapped {tapposition}");

    //        GameObject ball = Instantiate(_ballPrefeb, _xrCamera.position + _xrCamera.forward * 0.5f, _xrCamera.rotation);
    //        ball.GetComponent<Rigidbody>().AddForce(_xrCamera.forward * 500f, ForceMode.Force);
    //        // ForceMode
    //        // Force : F = m(����) x a(���ӵ�) //������ �������� ���ӵ��� �������� �Ϲ����� ��
    //        // Acceleration : a(���ӵ�) //������ ������� ���ӵ� ����
    //        // Impulse : I(��ݷ�) = F(��) * t(�ð�) = m(����) * a(���ӵ�) * t(�ð�) =
    //        // m(����) * v(�ӵ�) //������ �������� �ӵ��� ���������� �Ϲ����� �߷���
    //        // VelocityChange = v(�ӵ�) // ������ ������� �ӵ� ����

    //    }
    //}
}
