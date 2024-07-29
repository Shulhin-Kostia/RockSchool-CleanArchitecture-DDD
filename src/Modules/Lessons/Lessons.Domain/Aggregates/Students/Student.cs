using BuildingBlocks.Domain;

namespace Lessons.Domain.Aggregates.Students;

public class Student : Entity<StudentId>, IAggregateRoot
{
    public string Name { get; private set; }

    // public List<Subscription> Subscriptions { get; private set; }

    private Student(string name)
        : base(new StudentId(Guid.NewGuid()))
    {
        Name = name;
        // Subscriptions = [];
    }

    public static Student Create(string name)
    {
        return new Student(name);
    }

    public static Student Create(StudentId id, string name/*, List<Subscription> subscriptions*/)
    {
        var student = Create(name);
        student.Id = id;
        // student.Subscriptions = subscriptions;

        return student;
    }

    // internal void AddSubscription(Subscription subscription) => Subscriptions.Add(subscription);
}
