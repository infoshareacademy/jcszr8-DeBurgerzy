using System.Runtime.Serialization;

namespace ParcelDistributionCenter.Model.Enums
{
    public enum Status
    {
        [EnumMember(Value = "in_preparation")]
        InPreparation,

        [EnumMember(Value = "stored_by_sender")]
        StoredBySender,

        [EnumMember(Value = "stored_in_machine")]
        StoredInMachine,

        [EnumMember(Value = "in_delivery")]
        InDelivery,

        [EnumMember(Value = "delivered")]
        Delivered,
    }
}