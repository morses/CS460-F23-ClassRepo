using HW1.Models;

namespace HW1_Tests;

public class ScheduleFinder_Tests
{
    [SetUp]
    public void Setup()
    {
    }

    // "Hello world" test to make sure you can run tests.  Remove after you've verified it works.
    // [Test]
    // public void Test1()
    // {
    //     Assert.Pass();
    // }

    [Test]
    public void Scheduler_NullForBusyTimesInParser_DoesntFail()
    {
        // Arrange
        string? busyTimes = null;
        // Act
        List<string> actual = ScheduleFinder.ParseTimesFromString(busyTimes);
        // Assert
        Assert.That(actual, Is.Empty);
    }

    [Test]
    public void Scheduler_CanParseSpaceDelimitedDayTimeStrings()
    {
        // Arrange
        string str = "M8 M9 M10 M11 M12 M13 M14 M15 M16";
        List<string> expected = new List<string>() { "M8", "M9", "M10", "M11", "M12", "M13", "M14", "M15", "M16" };
        // Act
        List<string> actual = ScheduleFinder.ParseTimesFromString(str);
        // Assert
        Assert.That(actual, Is.EquivalentTo(expected));     // comparison is for same items regardless of order
    }

    [Test]
    public void Scheduler_ParsingDayTimeStrings_ReturnsAllUpperCaseTrimmed()
    {
        string str = "   m8   M9  m10 M11 m12   M13 m14 M15 m16   ";
        List<string> expected = new List<string>() { "M8", "M9", "M10", "M11", "M12", "M13", "M14", "M15", "M16" };
        List<string> actual = ScheduleFinder.ParseTimesFromString(str);
        Assert.That(actual, Is.EquivalentTo(expected));
    }

    [Test]
    public void Scheduler_GenerateAllTimesWithWeekends_IsCorrect()
    {
        List<string> expected = new List<string>() { "SU8", "SU9", "SU10", "SU11", "SU12", "SU13", "SU14", "SU15", "SU16",
                                                     "M8", "M9", "M10", "M11", "M12", "M13", "M14", "M15", "M16",
                                                     "T8", "T9", "T10", "T11", "T12", "T13", "T14", "T15", "T16",
                                                     "W8", "W9", "W10", "W11", "W12", "W13", "W14", "W15", "W16",
                                                     "R8", "R9", "R10", "R11", "R12", "R13", "R14", "R15", "R16",
                                                     "F8", "F9", "F10", "F11", "F12", "F13", "F14", "F15", "F16",
                                                     "SA8", "SA9", "SA10", "SA11", "SA12", "SA13", "SA14", "SA15", "SA16" };
        List<string> actual = ScheduleFinder.GenerateAllPossibleTimes(true);
        Assert.That(actual, Is.EquivalentTo(expected));
    }

    [Test]
    public void Scheduler_GenerateAllTimesWithoutWeekends_IsCorrect()
    {
        List<string> expected = new List<string>() { "M8", "M9", "M10", "M11", "M12", "M13", "M14", "M15", "M16",
                                                     "T8", "T9", "T10", "T11", "T12", "T13", "T14", "T15", "T16",
                                                     "W8", "W9", "W10", "W11", "W12", "W13", "W14", "W15", "W16",
                                                     "R8", "R9", "R10", "R11", "R12", "R13", "R14", "R15", "R16",
                                                     "F8", "F9", "F10", "F11", "F12", "F13", "F14", "F15", "F16" };
        List<string> actual = ScheduleFinder.GenerateAllPossibleTimes(false);
        Assert.That(actual, Is.EquivalentTo(expected));
    }

    [Test]
    public void Scheduler_CanFindFreeTimes_WhenNeverBusy()
    {
        string busyTimes = "";
        List<string> expected = new List<string>() { "M8", "M9", "M10", "M11", "M12", "M13", "M14", "M15", "M16",
                                                     "T8", "T9", "T10", "T11", "T12", "T13", "T14", "T15", "T16",
                                                     "W8", "W9", "W10", "W11", "W12", "W13", "W14", "W15", "W16",
                                                     "R8", "R9", "R10", "R11", "R12", "R13", "R14", "R15", "R16",
                                                     "F8", "F9", "F10", "F11", "F12", "F13", "F14", "F15", "F16" };
        ScheduleFinder scheduler = new ScheduleFinder(busyTimes);
        List<string> actual = scheduler.FreeTimes.ToList();
        Assert.That(actual, Is.EquivalentTo(expected));
    }

    [Test]
    public void Scheduler_CannotFindAnyFreeTimes_WhenAlwaysBusy()
    {
        string busyTimes = "M8 M9 M10 M11 M12 M13 M14 M15 M16 T8 T9 T10 T11 T12 T13 T14 T15 T16 W8 W9 W10 W11 W12 W13 W14 W15 W16 R8 R9 R10 R11 R12 R13 R14 R15 R16 F8 F9 F10 F11 F12 F13 F14 F15 F16";
        List<string> expected = new List<string>();
        ScheduleFinder scheduler = new ScheduleFinder(busyTimes);
        List<string> actual = scheduler.FreeTimes.ToList();
        Assert.That(actual, Is.EquivalentTo(expected));
    }

    [Test]
    public void Scheduler_CanFindFreeTimes_WhenBusyAllMonday()
    {
        string busyTimes = "M8 M9 M10 M11 M12 M13 M14 M15 M16";
        List<string> expected = new List<string>() { "T8", "T9", "T10", "T11", "T12", "T13", "T14", "T15", "T16",
                                                     "W8", "W9", "W10", "W11", "W12", "W13", "W14", "W15", "W16",
                                                     "R8", "R9", "R10", "R11", "R12", "R13", "R14", "R15", "R16",
                                                     "F8", "F9", "F10", "F11", "F12", "F13", "F14", "F15", "F16" };
        ScheduleFinder scheduler = new ScheduleFinder(busyTimes);
        List<string> actual = scheduler.FreeTimes.ToList();
        Assert.That(actual, Is.EquivalentTo(expected));
    }

    [Test]
    public void Scheduler_CanFindFreeTimes_WithComplicatedBusySchedule()
    {
        string busyTimes = "M8 M9 M14 M15 T15 W8 W9 W14 W15 R12 R13 R14";
        List<string> expected = new List<string>() {             "M10", "M11", "M12", "M13",               "M16",
                                                     "T8", "T9", "T10", "T11", "T12", "T13", "T14",        "T16",
                                                                 "W10", "W11", "W12", "W13",               "W16",
                                                     "R8", "R9", "R10", "R11",                      "R15", "R16",
                                                     "F8", "F9", "F10", "F11", "F12", "F13", "F14", "F15", "F16" };
        ScheduleFinder scheduler = new ScheduleFinder(busyTimes, false);
        List<string> actual = scheduler.FreeTimes.ToList();
        Assert.That(actual, Is.EquivalentTo(expected));
    }

    [Test]
    public void Scheduler_CanFindFreeTimes_WithDuplicatesInBusyTimes()
    {
        string busyTimes = "M8 M9 M14 M15 T15 W8 W9 W14 W15 R12 R13 R14 M8 M9 T15 R12 R13";
        List<string> expected = new List<string>() {             "M10", "M11", "M12", "M13",               "M16",
                                                     "T8", "T9", "T10", "T11", "T12", "T13", "T14",        "T16",
                                                                 "W10", "W11", "W12", "W13",               "W16",
                                                     "R8", "R9", "R10", "R11",                      "R15", "R16",
                                                     "F8", "F9", "F10", "F11", "F12", "F13", "F14", "F15", "F16" };
        ScheduleFinder scheduler = new ScheduleFinder(busyTimes, false);
        List<string> actual = scheduler.FreeTimes.ToList();
        Assert.That(actual, Is.EquivalentTo(expected));
    }

    [Test]
    public void Scheduler_CanHandleNonWhitespaceAndInvalidCharsAsSeparatorsInInput()
    {
        string busyTimes = "M8\tM9\nM14\r\nM15 T15;W8,W9.W14-W15/R12 R13 R14";
        List<string> expected = new List<string>() {             "M10", "M11", "M12", "M13",               "M16",
                                                     "T8", "T9", "T10", "T11", "T12", "T13", "T14",        "T16",
                                                                 "W10", "W11", "W12", "W13",               "W16",
                                                     "R8", "R9", "R10", "R11",                      "R15", "R16",
                                                     "F8", "F9", "F10", "F11", "F12", "F13", "F14", "F15", "F16" };
        ScheduleFinder scheduler = new ScheduleFinder(busyTimes, false);
        List<string> actual = scheduler.FreeTimes.ToList();
        Assert.That(actual, Is.EquivalentTo(expected));
    }
    
}