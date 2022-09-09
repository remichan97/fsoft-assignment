function validate() {
	let email = document.getElementById("email").value;
	let password = document.getElementById("password").value;

	var emailTag = document.getElementById("email");
	var passwordTag = document.getElementById("password");

	const re = /\S+@\S+\.\S+/;

	let text;

	if (!email || !password) {
		if (!email) {
			text = "This field is required";
			document.getElementById("validation").innerHTML = text;
			passwordTag.style.borderColor = "red";
		}
		if (!password) {
			text = "This field is required";
			document.getElementById("validationpw").innerHTML = text;
			emailTag.style.borderColor = "red";
		}
		return false;
	}

	if (email.length > 50) {
		text = "Maximum length is 50 characters";
		document.getElementById("validation").innerHTML = text;
		emailTag.style.borderColor = "red";
		return false;
	}

	if (!password.length > 50) {
		text = "Maximum length is 50 characters";
		document.getElementById("validationpw").innerHTML = text;
		passwordTag.style.borderColor = "red";
		return false;	
	}

	if (!re.test(email)) {
		text = "Input is not an email. Enter a valid email addess";
		document.getElementById("validation").innerHTML = text;
		emailTag.style.borderColor = "red";
		return false;
	}

	return true;
}