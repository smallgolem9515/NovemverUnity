/*
 * 전처리기(Preprocessor) : 컴파일 전에 처리할 내용들을 다루는 기능
 * 전처리기 if : 조건을 비교하여 맞는걸 처리한다.
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