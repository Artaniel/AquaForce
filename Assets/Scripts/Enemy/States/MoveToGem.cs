public class MoveToGem : AiState
{
    public override void StartState() {
        //_owner.agent.destination = _owner.targetGem.transform.position;
    }

    public override void StopState() {
        //_owner.agent.destination = null;
    }

    public override void UpdateState() {
        /*if (!_owner.agent.hasPath || _owner.agent.remainingDistance < 0.1f) {
            // TODO: Pick up Gem and switch state to return to spawn
        }*/
    }
}