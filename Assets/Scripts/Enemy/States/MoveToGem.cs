using UnityEngine;

public class MoveToGem : AiState
{
    public override void StartState() {
        _owner.ai.agent.destination = _owner.ai.targetGem.transform.position;
    }

    public override void StopState() {
        _owner.ai.agent.destination = _owner.transform.position;
    }

    public override void UpdateState() {
        _owner.ai.agent.nextPosition = _owner.transform.position;
        if (!_owner.ai.agent.hasPath) {
            _owner.ai.SetState<Idle>();
            return;
        }
        if ( Vector3.Distance(_owner.transform.position, _owner.ai.targetGem.transform.position) < 0.1f) {
            _owner.ai.targetGem.isCarried = true;
            _owner.ai.targetGem.transform.parent = _owner.transform;
            _owner.ai.SetState<MoveToSpawn>();
            return;
        }
        _owner.ai.MoveInDirrection(_owner.ai.agent.desiredVelocity.normalized);
        
    }
}