namespace ArasControl.Domain.Entities
{
    public class Haras
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Guid OwnerId { get; private set; }

        public Haras(Guid id, string name, Guid ownerId)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Invalid Haras Id.", nameof(id));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Haras name is required.", nameof(name));
            if (ownerId == Guid.Empty)
                throw new ArgumentException("OwnerId is required.", nameof(ownerId));

            Id = id;
            Name = name;
            OwnerId = ownerId;
        }

        public void Rename(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new ArgumentException("Haras name is required.", nameof(newName));

            Name = newName;
        }

        public void ChangeOwner(Guid newOwnerId)
        {
            if (newOwnerId == Guid.Empty)
                throw new ArgumentException("OwnerId is required.", nameof(newOwnerId));

            OwnerId = newOwnerId;
        }
    }
}
