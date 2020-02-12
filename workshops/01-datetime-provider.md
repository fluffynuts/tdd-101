Environment: .NET
Spec: You must create a static class, `DateTimeProvider` which has a single property, 
`UtcNow` which returns the current date-time, as UTC; ie implementing:

```csharp
public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}
```
