using Application.UseCases.UpdateTask.Dtos;
using FluentValidation;

namespace Application.UseCases.DeleteTask.Validators
{
	public class UpdateTaskInputValidator : AbstractValidator<UpdateTaskInput>
	{
		public UpdateTaskInputValidator() 
		{
			RuleFor(x => x.Description).NotNull().NotEmpty().Length(3, 64);
		}
	}
}
