namespace BusinessLogicLayer.DTOs;

public record DocumentDTO(
    string? Type,
    byte[]? FileContent
);