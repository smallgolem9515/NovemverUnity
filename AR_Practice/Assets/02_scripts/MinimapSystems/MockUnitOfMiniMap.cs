using UnityEngine;

namespace ARP.MinimapSystems
{
    public class MockUnitOfMiniMap : IUnitOfMinimap
    {
        public MockUnitOfMiniMap()
        {
            gps = new GameObject(nameof(MockGPS)).AddComponent<MockGPS>();
        }


        public IGPS gps { get; }
    }
}
