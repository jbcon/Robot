#pragma strict

private var motor : CharacterMotor;

function Awake () {
	motor = GetComponent(CharacterMotor);
}

public function SetInputMoveDirection (move : Vector3) {
	motor.inputMoveDirection = move;
}

public function SetInputJump (jump : boolean) {
	motor.inputJump = jump;
}