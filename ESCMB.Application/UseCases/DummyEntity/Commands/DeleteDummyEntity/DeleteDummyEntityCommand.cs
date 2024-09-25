using Core.Application;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ESCMB.Application.UseCases.DummyEntity.Commands.DeleteDummyEntity
{
    public class DeleteDummyEntityCommand : IRequestCommand<Unit>
    {
        [Required]
        public int DummyIdProperty { get; set; }

        public DeleteDummyEntityCommand()
        {
        }
    }
}
