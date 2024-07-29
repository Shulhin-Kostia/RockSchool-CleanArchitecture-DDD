using BuildingBlocks.Domain;
using Lessons.Domain.Aggregates.SubscriptionTypes;
using Lessons.Domain.Teachers;

namespace Lessons.Domain.Aggregates.Teachers;

public class Teacher : Entity<TeacherId>, IAggregateRoot
{
    public string Name { get; private set; }

    // public List<SubscriptionTypeId> SubscriptionTypes { get; private set; }

    private Teacher(string name/*, List<SubscriptionTypeId> packageTypes*/)
        : base(new TeacherId(Guid.NewGuid()))
    {
        Name = name;
        // SubscriptionTypes = packageTypes;
    }

    public static Teacher Create(string name, List<SubscriptionTypeId> packageTypes)
    {

        return new Teacher(name/*, packageTypes*/);
    }

    public static Teacher Create(TeacherId id, string name, List<SubscriptionTypeId> packageTypes)
    {
        var teacher = Create(name, packageTypes);
        teacher.Id = id;

        return teacher;
    }


    public void ChangeName(string newName)
    {
        if (!Name.Equals(newName))
        {
            Name = newName;
        }
    }

    // public void AddPackageType(SubscriptionTypeId id)
    // {
    //     if (!SubscriptionTypes.Contains(id))
    //     {
    //         SubscriptionTypes.Add(id);
    //     }
    // }

    // public void RemovePackageType(SubscriptionTypeId id)
    // {
    //     if (SubscriptionTypes.Contains(id))
    //     {
    //         SubscriptionTypes.Remove(id);
    //     }
    // }
}
