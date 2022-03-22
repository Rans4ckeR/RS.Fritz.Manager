namespace RS.Fritz.Manager.API;

using System.Text.Json.Serialization;

public readonly record struct DeviceMeshNodeLink(
    [property: JsonPropertyName("uid")] string Uid,
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("state")] string State,
    [property: JsonPropertyName("last_connected")] int? LastConnected,
    [property: JsonPropertyName("node_1_uid")] string Node1Uid,
    [property: JsonPropertyName("node_2_uid")] string Node2Uid,
    [property: JsonPropertyName("node_interface_1_uid")] string NodeInterface1Uid,
    [property: JsonPropertyName("node_interface_2_uid")] string NodeInterface2Uid,
    [property: JsonPropertyName("max_data_rate_rx")] int? MaxDataRateRx,
    [property: JsonPropertyName("max_data_rate_tx")] int? MaxDataRateTx,
    [property: JsonPropertyName("cur_data_rate_rx")] int? CurDataRateRx,
    [property: JsonPropertyName("cur_data_rate_tx")] int? CurDataRateTx,
    [property: JsonPropertyName("cur_availability_rx")] int? CurAvailabilityRx,
    [property: JsonPropertyName("cur_availability_tx")] int? CurAvailabilityTx,
    [property: JsonPropertyName("rx_rsni")] int? RxRsni,
    [property: JsonPropertyName("tx_rsni")] int? TxRsni,
    [property: JsonPropertyName("rx_rcpi")] int? RxRcpi,
    [property: JsonPropertyName("tx_rcpi")] int? TxRcpi);