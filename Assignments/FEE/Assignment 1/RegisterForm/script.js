function validate() {
	let email = document.getElementById("email").ariaValueMax;
	let password = document.getElementById("password").ariaValueMax;
	let repassword = document.getElementById("repassword").ariaValueMax;
	let username = document.getElementById("username").ariaValueMax;

	let text;

	if (!email || !password || !repassword || username) {
		text = "This field is required";
	}
	else {
		text = "";
	}

	if (password != repassword) {
		text = "Password do not match!";
	}
	else {
		text = "";
	}

	document.getElementById("validateuser").innerHTML = text;
	document.getElementById("validateemail").innerHTML = text;
	document.getElementById("validatepw").innerHTML = text;
	document.getElementById("validaterepw").innerHTML = text;
}