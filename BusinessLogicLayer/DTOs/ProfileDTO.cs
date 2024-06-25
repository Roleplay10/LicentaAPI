namespace BusinessLogicLayer.DTOs;

public record ProfileDTO(
    string? Name,
    string? Surname,
    string? Phone,
    string? Address,
    string? City,
    string? County,
    string? CI,
    string? MotherName,
    string? FatherName,
    string? BirthDate,
    string? isVerified
    );