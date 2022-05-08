using System.Diagnostics.CodeAnalysis;

namespace Domain.ValueObject;

public readonly struct Price : IEquatable<Price>
{
    public Price(decimal value, Currency currency)
    {
        Value = value;
        Currency = currency;
    }

    public decimal Value { get; }
    public Currency Currency { get; }


    public bool Equals(Price other) =>
        this.Value == other.Value && this.Currency == other.Currency;

    public override bool Equals([NotNullWhen(true)] object? obj) =>
        obj is Price price && price.Value == this.Value && price.Currency == this.Currency;

    public override int GetHashCode() => HashCode.Combine(this.Value, this.Currency);

    public override string? ToString() => $"{this.Value} {this.Currency}";
}
