using Application.UseCases.CreateTask.Dtos;
using FluentValidation;

namespace Application.UseCases.CreateTask.Validators
{
	public class CreateTaskInputValidator : AbstractValidator<CreateTaskInput>
	{
		public CreateTaskInputValidator() 
		{
			RuleFor(x => x.Description).NotNull().NotEmpty().Length(3, 64);
		}
	}
}
