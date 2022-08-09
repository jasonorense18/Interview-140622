using ErrorOr;

namespace Ct.Interview.Domain.Common.Errors;
public static partial class Errors
{
    public static class AsxCompany
    {
        public static Error FileNotFound => Error.Failure(
            code: "Asx.FailedToImport",
            description: "File not found.");

        public static Error NotFound => Error.NotFound(
            code: "Asx.CodeNotExist",
            description: "Code not exist.");
    }
}
