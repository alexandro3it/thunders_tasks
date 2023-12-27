using Application.UseCases.DeleteTask.Dtos;
using FluentValidation;

namespace Application.UseCases.DeleteTask.Validators
{
	public class DeleteTaskInputValidator : AbstractValidator<DeleteTaskInput>
	{
		public DeleteTaskInputValidator() 
		{
			RuleFor(x => x.TaskId).NotNull().NotEmpty();
		}
	}
}
