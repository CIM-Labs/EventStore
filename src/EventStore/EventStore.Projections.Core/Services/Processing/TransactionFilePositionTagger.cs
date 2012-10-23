using System;
using EventStore.Projections.Core.Messages;

namespace EventStore.Projections.Core.Services.Processing
{
    public class TransactionFilePositionTagger : PositionTagger
    {
        public override bool IsCompatible(CheckpointTag checkpointTag)
        {
            return checkpointTag.GetMode() == CheckpointTag.Mode.Position;
        }

        public override CheckpointTag MakeCheckpointTag(CheckpointTag previous, ProjectionMessage.Projections.CommittedEventDistributed comittedEvent)
        {
            return new CheckpointTag(comittedEvent.Position);
        }

        public override CheckpointTag MakeZeroCheckpointTag()
        {
            return new CheckpointTag(new EventPosition(0, -1));
        }
    }
}