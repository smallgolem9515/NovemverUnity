using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ARP.Test
{
    //인터페이스는 다른 객체가 상호작용 할수있는 기능들을 제공하는 추상 개념이므로
    //멤버들의 접근제한은 public 임
    public interface IAvailable
    {
        bool this[int index] { get; } //인덱스
        bool IsAvailable { get; } //프로퍼티
        void Use(); //함수
        event Action<bool> OnIsAvailableChange; //event가 안붙으면 그냥 변수이므로 멤버가 될 수 없다.
    }

    //serialization : 인스턴스를 string/byte[] 형태의 범용적인 데이터셋으로 변환
    //deserealization : string/byte[] 형태의 범용적인 데이터셋을 프로그램의 특정 타입 인스턴스로 변환
    public class UIDelegateTest : MonoBehaviour
    {
        //SerializedField Attribute :
        //멤버변수에 대한 데이터를 직렬화하여 UnityEditor 의 인스펙터창에 노출시키는 특성
        //사용하는 이유 : 캡슐화된 (private/pritected) 멤버변수는 Editor 에서 기본적으로 직렬화하지 않기때문
        [SerializeField] private Button _button;
        [SerializeField] private GameObject _toggleTarget;
        public Predicate<Vector3> match; //bool return형식
        public Action<int, float> action; //최대 16개의 매개변수를 가진 대리자
        public Func<long, long, int> Func; //<매개변수,매개변수,리턴>형식

        //struct Coord
        //{
        //    public float x, y, z;

        //    public static Coord operator+(Coord op1, Coord op2)
        //    {
        //        x = op1.x + op2.x;
        //        y = op1.y + op2.y;
        //        z = op1.z + op2.z;
        //    }
        //}
        //Coord sum2 = new Coord { x = 0, y = 0, z = 0 } + new Coord { x = 1, y = 1, z = 1 };

        private void Awake()
        {
            //_button.onClick += ?? //일반적인 C# event delegate 에 구독하는 형태
            //_button.onClick.AddListener(??) //Unity에서 제공하는 UnityEvent 객체에 구독하는 형태
            _button.onClick.AddListener(ToggleTarget);

            //match += x => x == Vector3.zero;
            match += isOrizin;
            //Predicate<Vector3> 에 구독을 한다면 : 파라미터 Vector3 한개, 반환타입 bool 이 기정사실
            //isOrizin의 경우 Vector3제거, bool제거, 이름 isOrizin제거, 접근 제한자 제거

            //if(match.Invoke(Vector3.zero))
            //{

            //}
            action += LogSum;

            action.Invoke(3, 4.2f);

            Func += CalcSum;
            Func += (a, b) =>
            {
                int temp = (int)(a + b);
                return temp;
            };
            Func.Invoke(4, 2);

        }
        void ToggleTarget()
        {
            _toggleTarget.SetActive(_toggleTarget.activeSelf == false);
        }
        //() => _toggleTarget.SetActive(_toggleTarget.activeSelf == false); 람다식화
        private bool isOrizin(Vector3 position)
        {
            return position == Vector3.zero;
        }
        //람다식은 C#에서 인라인함수를 구현할 때 사용.
        //인라인 함수 : 현재 코드라인에 바로 삽입하는 함수.
        //인라인함수 왜 씀? : 함수오버헤드(함수를 불러오는 비용이 함수를 실행할때의 비용보다 큰것) 없음,
        //큰 의미없는 함수들이 많아지는것을 방지하여 코드 기독성도 좋아짐(간단한 함수일때)

        //(position) => position == Vector3.zero; 람다식화

        private void LogSum(int a, float b) 
        {
            Debug.Log(a + b);
        }
        //(a, b) => Debug.Log(a + b); 람다식화
        private int CalcSum(long a, long b)
        {
            int temp = (int)(a + b);
            return temp;
        }
        //(a, b) =>
        //{
        //    int temp = (int)(a + b);
        //    return temp;
        //} //람다식화
    }
}

