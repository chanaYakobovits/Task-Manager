using System;
using System.Collections.Generic;

namespace Models.DTO;

public partial class TasksDTO
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? DueDate { get; set; }

    public string Status { get; set; } = null!;

    public int UserId { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual UserDTO User { get; set; } = null!;
}
