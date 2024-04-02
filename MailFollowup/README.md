# Mail Followup

Subject of this exercise is to write a library/function that translates Mail Followup Addresses to DateTime-Objects.
The function signature is the following:
```csharp
    DateTime GetFollowupTime(DateTime now, string address);
```

It should return the correct DateTime-Object that corresponds to the followup time added onto the datetime passed into 
the function.

e.g. 
```csharp
    var t = GetFollowupTime(new DateTime(2013,2,4,10,30,0), "2weeks1day1hour@followup.cc");
    // t should be DateTime(2013, 2, 19, 11, 30, 0)
```

Possible mail addresses include:
```
    7days@followup.cc // 7 Days from now
    12hours@followup.cc //  12 hours from now
    aug15-9am@followup.cc // the next 15th August at 9 o'clock
    1week3days5hours@followup.cc // 1 week 3 days and 5 hours from now
```

## Tools used

- Paradigm: TDD
- Language: C# (.NET 8)
- IDE: JetBrains Rider 2023.3.4
- Version Control: Git
- Packages:
  - xUnit
  - FluentAssertions

## (Special) learning goals

Implement this kata using TDD to get a hang of using automated (unit) tests to improve code quality and ensure correct
implementation of a feature.
Also use this as a way to tell if TDD is a tool worth using for my projects in the future or if it's just a hindrance.

## Results / Conclusion

- First Impressions: Red-Green-Refactor-Cycle seems to be really addictive.\
Seeing green test after cleaning up functions is a good feeling and sometimes
you write the next test just to get another test you can turn green.\
Might encourage feature creep? \
Only in the beginning? \
Does code/test quality suffer from adding too many irrelevant tests?
