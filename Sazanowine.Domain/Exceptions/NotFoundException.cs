namespace Sazanowine.Domain.Exceptions;

public class NotFoundException(string resourceType, string resourceIdentifier)
    : Exception($"{resourceType} with Id: {resourceIdentifier} doesn't exist")
{
}