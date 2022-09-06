function validate() {
	let email = document.signin.email.value;
	let password = document.signin.password.value;

	let text;

	if (!email || !password) {
		text = "This field is required";
		document.getElementById("validation").innerHTML = text;
		document.getElementById("validationpw").innerHTML = text;
		return false;
	}

	
	return true;
}