function validate() {
	let email = document.getElementById("email").ariaValueMax;
	let password = document.getElementById("password").ariaValueMax;

	let text;

	if (!email || !password) {
		text = "This field is required";
	}
	else {
		text = "";
	}

	document.getElementById("validation").innerHTML = text;
	document.getElementById("validationpw").innerHTML = text;
}