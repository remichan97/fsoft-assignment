function validate() {
	let email = document.reg.email.value;
	let password = document.reg.password.value;
	let repassword = document.reg.repw.value;
	let username = document.reg.username.value;

	let text;

	if (!email || !password || !repassword || username) {
		text = "This field is required";
		document.getElementById("validateuser").innerHTML = text;
		document.getElementById("validateemail").innerHTML = text;
		document.getElementById("validatepw").innerHTML = text;
		document.getElementById("validaterepw").innerHTML = text;
		return false;
	}	
	
	if (password != repassword) {
		text = "Password do not match!";
		document.getElementById("validaterepw").innerHTML = text;
		return false;
	}

	return true;
}