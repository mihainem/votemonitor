﻿using FluentValidation.TestHelper;

namespace Vote.Monitor.Feature.PollingStation.UnitTests.ValidatorTests;

public class DeleteValidatorTests
{
    private readonly Delete.Validator _validator = new();

    [Fact]
    public void Validate_Id_NotEmpty_ShouldPass()
    {
        // Arrange
        var request = new Delete.Request { Id = Guid.NewGuid() };

        // Act
        var result = _validator.TestValidate(request);

        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.Id);
    }

    [Fact]
    public void Validate_Id_Empty_ShouldFail()
    {
        // Arrange
        var request = new Delete.Request { Id = Guid.Empty };

        // Act
        var result = _validator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Id);
    }
}
