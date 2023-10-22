namespace TaskVault.Models
{
    public sealed record ItemModel
    {
        public long Id { get; init; }

        public string Name { get; init; }

        public ushort Progress { get; init; }

        public Priority Priority { get; init; }

        public string Details { get; set; } // details are populated from a third party
    }

}
