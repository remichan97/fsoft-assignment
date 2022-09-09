function validate() {
	let email = document.getElementById("email").value;
	let password = document.getElementById("password").value;
	const re = /\S+@\S+\.\S+/;

	let text;

	if (!email || !password) {
		if (!email) {
			text = "This field is required";
			document.getElementById("validation").innerHTML = text;
		}
		if (!password) {
			text = "This field is required";
			document.getElementById("validationpw").innerHTML = text;
		}
		return false;
	}

	if (email.length > 50) {
		text = "Maximum length is 50 characters";
		document.getElementById("validation").innerHTML = text;
		return false;
	}

	if (!password.length > 50) {
		text = "Maximum length is 50 characters";
		document.getElementById("validationpw").innerHTML = text;
		return false;	
	}

	if (!re.test(email)) {
		text = "Input is not an email. Enter a valid email addess";
		document.getElementById("validation").innerHTML = text;
		return false;
	}

	return true;
}