public class MoveToSpawn : AiState
{
    public override void StartState() {
        _owner.ai.agent.destination = _game.map.spawner.transform.position;
    }

    public override void StopState() {
        _owner.ai.agent.destination = _owner.transform.position;
    }

    public override void UpdateState() {
        if (!_owner.ai.agent.hasPath || _owner.ai.agent.remainingDistance < 0.1f) {
            _owner.ai.targetGem.isCarried = false;
            _owner.ai.targetGem.transform.parent = null;
            _owner.ai.targetGem.IsDelivered = true;
            _owner.ai.SetState<Idle>();
        }
    }
}