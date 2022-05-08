using System.Diagnostics.CodeAnalysis;

namespace Domain.ValueObject;

public readonly struct Currency : IEquatable<Currency>
{
    public Currency(string code) => Code = code;

    public string Code { get; }

    public bool Equals(Currency other) => this.Code == other.Code;

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is Currency currency && this.Code == currency.Code;

    public override int GetHashCode() => this.Code.GetHashCode();

    public override string ToString() => this.Code;
    
    public static bool operator ==(Currency left, Currency right) => left.Equals(right);

    public static bool operator !=(Currency left, Currency right) => !(left == right);

    public static readonly Currency Dollar = new Currency("USD");
    public static readonly Currency Real = new Currency("BRL");
}
