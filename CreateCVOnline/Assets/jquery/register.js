function isEmail(inputEmail) {
    var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
	return regex.test(inputEmail);
}
function validatePassword(inputPassword) {
	return inputPassword.length > 4;
}
function isMatching(inputTextAgain,inputText){
	return inputTextAgain==inputText;
}
$(document).ready(function(){
    $('#email').change(function(){
        var email = $(this).val().trim();
        // alert(`email = ${JSON.stringify(email)}`)
        if(!isEmail(email)) {
            //Error ?
            $(".emailError").html("Email is not valid format");
        } else {
            $(".emailError").html("");
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
	$('#emailretype').change(function(){
		var inputEmail=$('#email').val();
		var inputEmailAgain=$(this).val();
		if(!isMatching(inputEmailAgain,inputEmail)){
			$(".emailretypeError").html("Email Again Is Not Match To Email");
		}else{
			$(".emailretypeError").html("");
		}
	});
	$('#passwordretype').change(function(){
		var inputPassword=$('#password').val();
		var inputPasswordAgain=$(this).val();
		if(!isMatching(inputPasswordAgain,inputPassword)){
			$(".passwordretypeError").html("Password Again Is Not Match To Password");
		}else{
			$(".passwordretypeError").html("");
		}
	});
});