namespace AnteaterStudios.DotRange;

/// <summary>
/// Class Range defines a range between two values.
/// </summary>
/// <typeparam name="T">The type of the range's minimum and maximum values. Must implement IComparable.</typeparam>
public sealed record class Range<T> where T : IComparable<T>
{
    /// <summary>
    /// Instance variable <c>_min<c> represents the range's minimum value.
    /// </summary>
    private T _min;

    /// <summary>
    /// Instance variable <c>_max<c> represents the range's maximum value.
    /// </summary>
    private T _max;

    /// <summary>
    /// Property <c>Min<c> represents the range's minimum value.
    /// </summary>
    /// <exception cref="System.ArgumentException">Thrown when minimum value is set to follow maximum value in the sort order.</exception>
    public T Min {
        get => _min;
        init {
            if (value.CompareTo(Max) > 0)
                throw new ArgumentException($"{nameof(Min)} can't follow {nameof(Max)} in the sort order.");

            _min = value;
        }
    }

    /// <summary>
    /// Property <c>Max<c> represents the range's maximum value.
    /// </summary>
    /// <exception cref="System.ArgumentException">Thrown when maximum value is set to precede minimum value in the sort order.</exception>
    public T Max
    {
        get => _max;
        init
        {
            if (value.CompareTo(Min) < 0)
                throw new ArgumentException($"{nameof(Max)} can't precede {nameof(Min)} in the sort order.");

            _max = value;
        }
    }

    /// <summary>
    /// This constructor initializes the new Range with Min = 
    /// <paramref name="min"/> and Max = <paramref name="max"/>.
    /// </summary>
    /// <param><c>min</c> is the new Range's minimum value.</param>
    /// <param><c>yPosition</c> is the new Range's maximum value.</param>
    /// <exception cref="System.ArgumentException">Thrown when <c>max</c> precedes <c>min</c> in the sort order.</exception>
    public Range(T min, T max)
    {
        if (max.CompareTo(min) < 0)
            throw new ArgumentException($"{nameof(Max)} can't precede {nameof(Min)} in the sort order.");

        _min = min;
        _max = max;
    }
}
