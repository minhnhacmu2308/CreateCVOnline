    function isUsername(inputUsername) {
    return inputUsername.length > 4;
}
function validatePassword(inputPassword) {
	return inputPassword.length > 4;
}

$(document).ready(function(){
    $('#username').change(function(){
        var username = $(this).val().trim();
        // alert(`email = ${JSON.stringify(email)}`)
        if(!isUsername(username)) {
            //Error ?
            $(".usernameError").html("Username is not valid format");
        } else {
            $(".usernameError").html("");
        }
    });
    $('#password').change(function(){
        var password = $(this).val();	
        if(!validatePassword(password)) {
			$(".passwordError").html("Password must be at least 5 characters");
		} else {
			$(".passwordError").html("");
		}
    });
});