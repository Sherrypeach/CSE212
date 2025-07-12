/// <summary>
/// This queue is circular.  When people are added via AddPerson, then they are added to the 
/// back of the queue (per FIFO rules).  When GetNextPerson is called, the next person
/// in the queue is saved to be returned and then they are placed back into the back of the queue.  Thus,
/// each person stays in the queue and is given turns.  When a person is added to the queue, 
/// a turns parameter is provided to identify how many turns they will be given.  If the turns is 0 or
/// less than they will stay in the queue forever.  If a person is out of turns then they will 
/// not be added back into the queue.
/// </summary>
public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    public int Length => _people.Length;

    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        var person = _people.Dequeue();

        // If infinite turns (0 or less), re-enqueue directly
        if (person.Turns <= 0)
        {
            _people.Enqueue(person);
        }
        // If finite and still has turns left after this, decrement and enqueue again
        else if (person.Turns > 1)
        {
            person.Turns -= 1;
            _people.Enqueue(person);
        }
        // Else, don't enqueue (turns will reach 0 after this use)

        return person;
    }

    public override string ToString()
    {
        return _people.ToString();
    }
}
