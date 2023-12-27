using FluentValidation.Results;

namespace WebApi.Result
{
	public sealed record Error
	{
		public Error(string code, string message)
		{
			Code = code;
			Message = message;
		}

		public string Code { get; set; }
		public string Message { get; set; }

		public static Error CreateError(string code, string message) => new Error(code, message);
		public static Error CreateError(ValidationFailure fail) => new Error(string.Concat(fail.PropertyName, ":", " ", fail.ErrorCode), fail.ErrorMessage);
		public static IEnumerable<Error> CreateError(IEnumerable<ValidationFailure> collection) => collection.Select(new Func<ValidationFailure, Error>(CreateError));
	}
}
