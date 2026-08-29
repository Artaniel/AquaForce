public class MoveToSpawn : AiState
{
    public override void StartState() {
        _ai.agent.destination = _game.map.gemDropZone.position;
    }

    public override void StopState() {
        _ai.targetGem = null;
        _ai.agent.destination = _owner.transform.position;
    }

    public override void UpdateState(float deltaTime) {
        _ai.agent.nextPosition = _owner.transform.position;
        if (!_ai.agent.hasPath) {
            _ai.targetGem.isCarried = false;
            _ai.targetGem.transform.parent = _game.map.transform;
            _ai.SetState<Idle>();
            return;
        }
        if (_ai.agent.remainingDistance < 0.5f) {
            _ai.targetGem.isCarried = false;
            _ai.targetGem.transform.parent = _game.map.transform;
            _ai.targetGem.IsDelivered = true;
            _ai.StealGem(_ai.targetGem);
            _ai.SetState<Idle>();
            return;
        }
        _ai.MoveInDirrection(_ai.agent.desiredVelocity.normalized);
        _owner.view.isLookingLeft = (_owner.transform.position - _game.map.gemDropZone.position).x > 0;
    }
}