/*
 * ��ó����(Preprocessor) : ������ ���� ó���� ������� �ٷ�� ���
 * ��ó���� if : ������ ���Ͽ� �´°� ó���Ѵ�.
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
            //������ ���� �ν�����â���� �����ϴ°� ���ϴ� ����
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