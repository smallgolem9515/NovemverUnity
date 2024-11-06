/*
 * 전처리기(Preprocessor) : 컴파일 전에 처리할 내용들을 다루는 기능
 * 전처리기 if : 조건을 비교하여 맞는걸 처리한다.
 */
using UnityEngine;
using UnityEngine.UI;

namespace ARP.MinimapSystems
{
    public class UI_Minimap : MonoBehaviour
    {
        private IGPS _gps => _unit.gps;

        private IUnitOfMinimap _unit;
        [SerializeField] float _zoom = 4;
        [SerializeField] Vector2 _size = new Vector2(512, 512);
        private GoogleMapInterface _googleMapInterface;
        [SerializeField] RawImage _map;


        private void Awake()
        {
            _googleMapInterface = new GameObject("GoogleMapInterface").AddComponent<GoogleMapInterface>();
            //의존성 주입 인스펙터창에서 참조하는건 피하는 문법
        }

        private void Start()
        {
#if UNITY_EDITOR
            _unit = new MockUnitOfMiniMap();
#elif UNITY_ANDROID
            _unit = new UnitOfMiniMap();
#endif
            RefreshMap();
        } 

        private void RefreshMap()
        {
            _googleMapInterface.LoadMap(_gps.latitude, _gps.longitude, _zoom, _size, (texture) => _map.texture = texture);
        }
        
    }
}