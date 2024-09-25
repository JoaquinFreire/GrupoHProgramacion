using Core.Application;
using MediatR;
using System.ComponentModel.DataAnnotations;
using static ESCMB.Domain.Enums;

namespace ESCMB.Application.UseCases.DummyEntity.Commands.UpdateDummyEntity
{
    public class UpdateDummyEntityCommand : IRequestCommand<Unit>
    {
        [Required]
        public int DummyIdProperty { get; set; }
        [Required]
        public string DummyPropertyTwo { get; set; }
        public DummyValues DummyPropertyThree { get; set; }

        public UpdateDummyEntityCommand()
        {
        }
    }
}
