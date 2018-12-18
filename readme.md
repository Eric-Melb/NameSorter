# Name Sorter - Coding Assignment Submission
 
## Building & Running
 Build process is manual.
 
 **To run simply:**
  1. From the terminal, within the `NameSorter/` directory run `dotnet run [FILE-TO-SORT]`

 **To build exe:**
 1. Add a `<UseAppHost>true</UseAppHost>` entry to the .csproj files within the `<PropertyGroup>` entries

 2. Build with `dotnet publish -r [OS-TARGET] --self-contained` where OS-TARGET is win-x64 or linux-x64 as appropriate (or be more specific if you'd like)

 3. The executable (and necessary dependencies) will be within `NameSorter/bin/Release/netcoreapp2.0/[OS-TARGET]` directory

 4. Run from terminal as `NameSorter [FILE-TO-SORT]`
 
## Assumptions
 - Names will be valid UTF-8 strings
 - Delimiter between names is a line break
 - Names may contain up to four words, delimited by space, words joined with a hyphen count as a single word for purposes of this rule
 - Names are to be sorted based on last name, then given name
 - "A name must have at least 1 given name and may have up to 3 given names" This is a constraint on given names, there is no constraint on the last names, so it is possible it may not exist for some names. As we need to sort on last names we will store any single word full names as a last name and no given names to enable comparison. This will have no impact on names that do contain a last name. All separable name portions are still assumed to be space delimited.
 - Names are not necessarily unique
 - That, to allow there to be a good amount of testable code, "our goal is not to see you implement a trivial sorting
algorithm" means "implement a trivial sorting algorithm, though it is not the goal" rather than "just use [collection].Sort()" (although a CompareTo() method has been added for names to enable collection Sort methods and for use in the implemented sort)

## Tests
Testing framework utilised is nUnit

Tests were run with Resharper, coverage below

One test relies on `test-unsorted-names-list.txt` existing in the appropriate bin directory for the `.Tests` project (this is included in the repo). Another relies on `this-file-does-not-exist.txt` not existing in that directory.

<img src=https://i.imgur.com/gz6Nk3O.png>
