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
    1week3days5hours@followup.cc // 1 week, 3 days and 5 hours from now
```

## Tools used

- Paradigm: TDD
- Language: C# 12 (.NET 8)
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

As I'm now finished with this kata as my first "real" implementation of a feature using TDD i can say, it's quite a relaxing way
of writing software. After you got into the groove of the R-G-R-Cycle it's not that much of a burden to write the tests.
Also making changes and seeing all tests light up green or refactoring the date parsing and accidentally breaking the timespan parser resulting
in a whole lot of "old" tests failing, is really comforting. Normally that would have taken me a bug report or more (manual) 
testing to find out and fix.

Granted it was a really simple example with clear and concise requirements. But I don't think more complex or vague requirements
are changing this completely rather it might be relatively proportional.\
\
Though mocking might be a whole other can of worms, even though it's usage in TDD or testing in general is rather frowned upon.
But that's a topic for another time or kata

### In conclusion

Although I had a fun time doing this task and TDD didn't slow me down as much as I thought (and people shouting on the internet),
I won't use the TDD approach for every piece of code I write in the future.\
\
For a non exhaustive list of reasons:
- "You are doing TDD wrong, you have to do XYZ"
- when you don't have the slightest clue how you are approaching this especially if the overall architecture is part of it
- ever changing business rules that can or could invalidate the majority of code that's gonna be written
- just 100% knowing what a specific line or block of code does and will do in ALL scenarios (rare and needs a lot of experience but it happens)

For my final word, if you are struggling to grasp testing/TDD or just hate it and everything that's connected to it, just do more (complex) exercises.
As with everything in software, repetition is the key to success. I couldn't wrap my head around adding (unit) tests to 
any of my (legacy/production) codebases - which I still suck at to be honest - but I'm getting to a point where I'm 
starting to get ideas and also already implemented some tests that saved my behind a few times before pushing to production.