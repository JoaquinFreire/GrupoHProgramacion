using Core.Application;
using static ESCMB.Domain.Enums;

namespace ESCMB.Application.DomainEvents
{
    internal sealed class DummyEntityUpdated : DomainEvent
    {
        public int DummyIdProperty { get; set; }
        public string DummyPropertyTwo { get; set; }
        public DummyValues DummyPropertyThree { get; set; }
    }
}
