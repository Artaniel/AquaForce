using UnityEngine;

public class MoveToGem : AiState
{
    public override void StartState() {
        _ai.agent.destination = _ai.targetGem.transform.position;
    }

    public override void StopState() {
        _ai.agent.destination = _owner.transform.position;
        _ai.targetGem.isReserved = false;
    }

    public override void UpdateState() {
        _ai.agent.nextPosition = _owner.transform.position;
        if (!_ai.agent.hasPath) {
            _ai.SetState<Idle>();
            return;
        }
        if ( Vector3.Distance(_owner.transform.position, _ai.targetGem.transform.position) < 1f) {
            _ai.TakeGem();
            _ai.SetState<MoveToSpawn>();
            return;
        }
        _ai.MoveInDirrection(_ai.agent.desiredVelocity.normalized);        
    }
}