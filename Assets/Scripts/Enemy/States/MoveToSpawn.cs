public class MoveToSpawn : AiState
{
    public override void StartState() {
        //_owner.agent.destination = _game.map.spawn.transform.position;
    }

    public override void StopState() {
        //_owner.agent.destination = null;
    }

    public override void UpdateState() {
        /*if (!_owner.agent.hasPath || _owner.agent.remainingDistance < 0.1f) {
            //TODO drop gem
            _owner.ai.ChangeState<Idle>();
        }*/
    }
}