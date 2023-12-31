﻿using System.ComponentModel.DataAnnotations;

namespace DebtTracker.BL.Models.User;

public record UserPasswordModel : ModelBase
{
    [MaxLength(60)]
    public required string HashedPassword { get; set; } = string.Empty;

    public static UserPasswordModel Empty => new()
    {
        Id = Guid.Empty,
        HashedPassword = string.Empty
    };
}