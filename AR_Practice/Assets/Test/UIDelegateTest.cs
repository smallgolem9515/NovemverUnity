using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ARP.Test
{
    //�������̽��� �ٸ� ��ü�� ��ȣ�ۿ� �Ҽ��ִ� ��ɵ��� �����ϴ� �߻� �����̹Ƿ�
    //������� ���������� public ��
    public interface IAvailable
    {
        bool this[int index] { get; } //�ε���
        bool IsAvailable { get; } //������Ƽ
        void Use(); //�Լ�
        event Action<bool> OnIsAvailableChange; //event�� �Ⱥ����� �׳� �����̹Ƿ� ����� �� �� ����.
    }

    //serialization : �ν��Ͻ��� string/byte[] ������ �������� �����ͼ����� ��ȯ
    //deserealization : string/byte[] ������ �������� �����ͼ��� ���α׷��� Ư�� Ÿ�� �ν��Ͻ��� ��ȯ
    public class UIDelegateTest : MonoBehaviour
    {
        //SerializedField Attribute :
        //��������� ���� �����͸� ����ȭ�Ͽ� UnityEditor �� �ν�����â�� �����Ű�� Ư��
        //����ϴ� ���� : ĸ��ȭ�� (private/pritected) ��������� Editor ���� �⺻������ ����ȭ���� �ʱ⶧��
        [SerializeField] private Button _button;
        [SerializeField] private GameObject _toggleTarget;
        public Predicate<Vector3> match; //bool return����
        public Action<int, float> action; //�ִ� 16���� �Ű������� ���� �븮��
        public Func<long, long, int> Func; //<�Ű�����,�Ű�����,����>����

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
            //_button.onClick += ?? //�Ϲ����� C# event delegate �� �����ϴ� ����
            //_button.onClick.AddListener(??) //Unity���� �����ϴ� UnityEvent ��ü�� �����ϴ� ����
            _button.onClick.AddListener(ToggleTarget);

            //match += x => x == Vector3.zero;
            match += isOrizin;
            //Predicate<Vector3> �� ������ �Ѵٸ� : �Ķ���� Vector3 �Ѱ�, ��ȯŸ�� bool �� �������
            //isOrizin�� ��� Vector3����, bool����, �̸� isOrizin����, ���� ������ ����

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
        //() => _toggleTarget.SetActive(_toggleTarget.activeSelf == false); ���ٽ�ȭ
        private bool isOrizin(Vector3 position)
        {
            return position == Vector3.zero;
        }
        //���ٽ��� C#���� �ζ����Լ��� ������ �� ���.
        //�ζ��� �Լ� : ���� �ڵ���ο� �ٷ� �����ϴ� �Լ�.
        //�ζ����Լ� �� ��? : �Լ��������(�Լ��� �ҷ����� ����� �Լ��� �����Ҷ��� ��뺸�� ū��) ����,
        //ū �ǹ̾��� �Լ����� �������°��� �����Ͽ� �ڵ� �⵶���� ������(������ �Լ��϶�)

        //(position) => position == Vector3.zero; ���ٽ�ȭ

        private void LogSum(int a, float b) 
        {
            Debug.Log(a + b);
        }
        //(a, b) => Debug.Log(a + b); ���ٽ�ȭ
        private int CalcSum(long a, long b)
        {
            int temp = (int)(a + b);
            return temp;
        }
        //(a, b) =>
        //{
        //    int temp = (int)(a + b);
        //    return temp;
        //} //���ٽ�ȭ
    }
}

