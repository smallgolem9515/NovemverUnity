using System;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;


// 식별자 명명 방식
// PascalCase : 대문자 시작, 단어별로 첫 알파벳 대문자
// camelCase : 소문자 시작, 단어별로 첫 알파벳 대문자
// snake_case : 단어사이 _
// UPPER_SNAKE_CASE : 단어사이 _, 모든문자 대문자
// HungarianNotion : iNum(int타입 변수), fHeight(float타입 변수) //안씀
// m_~~ : 멤버변수 명시법 //C#은 멤버변수가 아닌 글로벌한 변수가 없기때문에 안씀

//또다른 싱글톤 작성법
//public class  A : MonoBehaviour
//{
//    public static A instance
//    {
//        get
//        {
//            if(s_instance == null)
//            {
//                s_instance = new GameObject(nameof(A)).AddComponent<A>();
//            }
//            return s_instance;
//        }
//    }
//    private static A s_instance;
//}
public enum state
{
    Idle,     //0 == ... 00000000 // 비트전환
    Jump,     //1 == ... 00000001
    Attack,   //2 == ... 00000010
    Crouch,   //3 == ... 00000011
}
[Flags]
public enum states
{
    Idle = 0 << 0,   // ... 00000000 //비트전환
    Jump = 1 << 0,   // ... 00000001
    Attack = 1 << 1, // ... 00000010
    Crouch = 1 << 2, // ... 00000100
    JumpOrAttack = Jump | Attack, // == 00000011
}

public class LineDrawer : MonoBehaviour
{
    [SerializeField] InputActionReference _dragCurrentPosition;
    [SerializeField] private Camera _xrCamera;
    [SerializeField] private float _drawOffsetZ = 0.5f;
    [SerializeField] private float _drawMinDistance = 0.05f;
    [SerializeField] private float _lineRendererWidth = 0.01f;
    private LineRenderer _lineRenderer;
    private List<Vector3> _positions = new List<Vector3>(512);
    // reserving ... //인스턴스화 및 가비지컬렉션의 부하를 최소화하기위한 용량확보

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.startWidth = _lineRendererWidth;
        _lineRenderer.endWidth = _lineRendererWidth;
    }
    private void Start()
    {
        _dragCurrentPosition.action.performed += OnDrag;
    }
    private void OnDrag(InputAction.CallbackContext context)
    {
        Vector2 dragposition = context.ReadValue<Vector2>();
        Vector3 worldPositon = _xrCamera.ScreenToWorldPoint(new Vector3(dragposition.x, dragposition.y, _drawOffsetZ));

        if (_positions.Count == 0)
        {
            AddPositionToLineRenderer(worldPositon);
        }
        else
        {
            if (Vector3.Distance(_positions[_positions.Count -1], worldPositon) >= _drawMinDistance)
            {
                AddPositionToLineRenderer(worldPositon);
            }
        }
    }
    //O(1)
    private void AddPositionToLineRenderer(Vector3 position)
    {
        _positions.Add(position);
        _lineRenderer.positionCount = _positions.Count;
        int index = _lineRenderer.positionCount - 1;
        _lineRenderer.SetPosition(index, position);
    }
    //O(n)
    //private void RefreshLineRenderer()
    //{
    //    _lineRenderer.positionCount = _positions.Count;

    //    for (int i = 0; i < _positions.Count; i++)
    //    {
    //        _lineRenderer.SetPosition(i, _positions[i]);
    //    }
    //}
}
