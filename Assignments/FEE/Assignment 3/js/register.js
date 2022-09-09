function validate() {
	let email = document.reg.email.value;
	let password = document.reg.password.value;
	let repassword = document.reg.repw.value;
	let username = document.reg.username.value;

	const emailTag = document.getElementById("email");
	const usernameTag = document.getElementById("username");
	const passwordTag = document.getElementById("password");
	const repasswordTag = document.getElementById("repassword");

	let text;

	if (!email || !password || !repassword || username) {
		text = "This field is required";
		if (!email) {
			document.getElementById("validateemail").innerHTML = text;
			emailTag.style.borderColor = "red";
		} else if(!ppassword) {
			document.getElementById("validatepw").innerHTML = text;
			passwordTag.style.borderColor = "red";
		} else if (!repassword) {
			document.getElementById("validaterepw").innerHTML = text;
			repasswordTag.style.borderColor = "red";
		} else {
			document.getElementById("validateuser").innerHTML = text;
			usernameTag.style.borderColor = "red";
		}
		return false;
	}	
	
	if (password != repassword) {
		text = "Password do not match!";
		document.getElementById("validaterepw").innerHTML = text;
		repasswordTag.style.borderColor = "red";
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