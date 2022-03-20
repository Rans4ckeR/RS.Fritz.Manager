namespace RS.Fritz.Manager.API;

// https://avm.de/fileadmin/user_upload/Global/Service/Schnittstellen/mesh_topology/mesh_topology_schema_v1.9.json
#pragma warning disable SA1516 // Elements should be separated by blank line
#pragma warning disable CA1707 // Identifiers should not contain underscores
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable IDE1006 // Naming Styles
#pragma warning disable SA1300 // Element should begin with upper-case letter

public sealed record DeviceMesh
{
    public string schema_version { get; set; }
    public Node[] nodes { get; set; }
}

public sealed record Node
{
    public string uid { get; set; }
    public string device_name { get; set; }
    public string device_model { get; set; }
    public string device_manufacturer { get; set; }
    public string device_firmware_version { get; set; }
    public string device_mac_address { get; set; }
    public bool is_meshed { get; set; }
    public string mesh_role { get; set; }
    public string meshd_version { get; set; }
    public NodeInterfaces[] node_interfaces { get; set; }
}

public sealed record NodeInterfaces
{
    public string uid { get; set; }
    public string name { get; set; }
    public string type { get; set; }
    public string mac_address { get; set; }
    public string blocking_state { get; set; }
    public NodeLinks[] node_links { get; set; }
    public string ssid { get; set; }
    public string opmode { get; set; }
    public string security { get; set; }
    public object[][] supported_streams_tx { get; set; }
    public object[][] supported_streams_rx { get; set; }
    public int current_channel { get; set; }
    public string[] phymodes { get; set; }
    public int channel_utilization { get; set; }
    public int anpi { get; set; }
    public bool steering_enabled { get; set; }
    public bool _11k_friendly { get; set; }
    public bool _11v_friendly { get; set; }
    public bool legacy_friendly { get; set; }
    public bool rrm_compliant { get; set; }
    public ChannelList[] channel_list { get; set; }
}

public sealed record NodeLinks
{
    public string uid { get; set; }
    public string type { get; set; }
    public string state { get; set; }
    public int last_connected { get; set; }
    public string node_1_uid { get; set; }
    public string node_2_uid { get; set; }
    public string node_interface_1_uid { get; set; }
    public string node_interface_2_uid { get; set; }
    public int max_data_rate_rx { get; set; }
    public int max_data_rate_tx { get; set; }
    public int cur_data_rate_rx { get; set; }
    public int cur_data_rate_tx { get; set; }
    public int cur_availability_rx { get; set; }
    public int cur_availability_tx { get; set; }
    public int rx_rsni { get; set; }
    public int tx_rsni { get; set; }
    public int rx_rcpi { get; set; }
    public int tx_rcpi { get; set; }
}

public sealed record ChannelList
{
    public int channel { get; set; }
}