namespace ARP.MinimapSystems
{
    /// <summary>
    /// ����� ����, �浵, �� ����
    /// </summary>
    public interface IGPS
    {
        /// <summary>
        /// ����
        /// </summary>
        float latitude { get; }

        /// <summary>
        /// �浵
        /// </summary>
        float longitude { get; }

        /// <summary>
        /// ��
        /// </summary>
        float altitude { get; }
    }
}

