using UnityEngine;

namespace ARP.MinimapSystems
{
    public class UnitOfMiniMap : IUnitOfMinimap
    {
        public UnitOfMiniMap()
        {
            gps = new GameObject(nameof(GPS)).AddComponent<GPS>();
        }


        public IGPS gps { get; }
    }
}
