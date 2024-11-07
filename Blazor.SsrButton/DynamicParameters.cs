namespace Blazor.SsrButton;

public class DynamicParameters
{
    private readonly Dictionary<string, object> _parameters;

    public DynamicParameters()
    {
        _parameters = new Dictionary<string, object>();
    }

    public void AddParameter(string key, object value)
    {
        _parameters[key] = value;
    }

    public object GetParameter(string key)
    {
        return _parameters.ContainsKey(key) ? _parameters[key] : null;
    }

    public bool TryGetParameter<T>(string key, out T value)
    {
        if (_parameters.TryGetValue(key, out var obj) && obj is T castValue)
        {
            value = castValue;
            return true;
        }
        value = default;
        return false;
    }

    public Dictionary<string, object> GetAllParameters()
    {
        return new Dictionary<string, object>(_parameters);
    }
}