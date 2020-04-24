## Testing more complex systems

So far, we've dealt with rather simple systems. In the real world, we'll find that
most systems aren't as simple (although our [CRUD workshop](workshops/03-crud/readme.md)
hints at more complexity).

In particular, we're probably going to have to deal with code like that of a web api:
- http request comes in
- there's some busines logic to invoke
- probably some data to retrieve / store
- perhaps more business logic
- finally, a response has to be sent to the originator of the call

### Finding boundaries
Even in the logic listed above, something becomes clear: there are _boundaries_ within
any well-designed piece of software. For example, the following is difficult to maintain:

```csharp
public class CurrencyConversionController
{
    public Convert(decimal value, string fromCurrency, string toCurrency)
    {
        using var connection = new MySqlConnection(WebC
    }
}
```

### Solution: interface all the things!

### Gearing up

#### Fakes, mocks and stubs

##### NSubstitute

#### Test arenas

- Finding boundaries
    - Interface all the things!
- Gearing up
    - Fakes, Mocks and Stubs
        - what's the difference? does it really matter? (short answer: no; longer answer: chances are good you're mocking and stubbing at the same time, so, no.)
            - more here: https://www.martinfowler.com/articles/mocksArentStubs.html
        - why?
        - substitutes with NSubstitute
    - Test arenas
        - when you have to set up a lot of stuff to get a test working
        - prefer an arena over state in the test fixture
            - prevents test interactions
