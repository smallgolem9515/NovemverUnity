/*
 * ��ó����(Preprocessor) : ������ ���� ó���� ������� �ٷ�� ���
 * ��ó���� if : ������ ���Ͽ� �´°� ó���Ѵ�.
 */
using UnityEngine;

namespace ARP.MinimapSystems
{
    public class Minimap : MonoBehaviour
    {
        private IGPS _gps => _unit.gps;

        private IUnitOfMinimap _unit;


        private void Start()
        {
#if UNITY_EDITOR
            _unit = new MockUnitOfMiniMap();
#elif UNITY_ANDROID
            _unit = new UnitOfMinimap();
#endif

        }

        private void RefreshMap()
        {

        }
    }
}