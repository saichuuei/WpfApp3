using System;

public class TaskItem
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public string Priority { get; set; }

    public override string ToString()
    {
        return $"{Title} ({Priority}) - Due {DueDate:MMM dd}";
    }
}
