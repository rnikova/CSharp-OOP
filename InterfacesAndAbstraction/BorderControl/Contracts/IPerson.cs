namespace BorderControl.Contracts
{
    using System;

    public interface IPerson
    {
        string Name { get; }

        int Age { get; }

        string Id { get; }

        DateTime Birthdate { get;}
    }
}
