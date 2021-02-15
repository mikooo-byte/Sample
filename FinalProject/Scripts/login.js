$(document).ready(function () {
    var attempt = 0;
    var attemptStud = 0;

    $("#registrationForm").validate({
        
        rules: {
            Studentnum: {
                required: true
            },
            Password: {
                required: true
            }
        },
        messages: {
            Studentnum: {
                required: "Username cannot be empty"
            },
            Password: {
                required: "Password cannot be empty"
            }
        },
        submitHandler: function (form) {
            attempt ;
            var url = $(form).attr("action");
            var data = $(form).serialize();
            $.ajax({
                url: url,
                type: "POST",
                data: data,
                contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
                success: function (res) {
                    if (res =="True") {
                        swal("Nice!", "Successfully Log-in", "success");

                        window.location.href = "../Admin/Index";
                    }
                    else {
                        attempt ++;
                        
                        if (attempt == 3) {
                            swal("Error!", "You failed to Login Please Try to communicate with your Administrator! ", "error");
                            $("#Password").val("");
                            $("#Studentnum").val("");
                            document.getElementById('Studentnum').disabled = true;
                            document.getElementById('Password').disabled = true;
                            document.getElementById('signIn').disabled = true;
                            $("#msgEr").text("Account Locked! Ask Assistance to Admin");
                        }
                        else {
                            $("#password").val("");
                            swal("Error!", "Username or Password is Incorrect", "error");
                            
                            
                        }
                    }
                },
                error: function (res) {

                }
            });
        }
    });
    $("#registrationFormStudent").validate({
        rules: {
            Studentnum: {
                required: true
            },
            Password: {
                required: true
            }
        },
        messages: {
            Studentnum: {
                required: "Username cannot be empty"
            },
            Password: {
                required: "Password cannot be empty"
            }
        },
        submitHandler: function (form) {
            var url = $(form).attr("action");
            var data = $(form).serialize();
            $.ajax({
                url: url,
                type: "POST",
                data: data,
                contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
                success: function (res) {
                    if (res == "True") {
                        swal("Nice!", "Successfully Log-in", "success");

                        window.location.href = "../Student/Index";
                    }
                    else {
                        attemptStud++;

                        if (attemptStud == 3) {
                            swal("Error!", "You failed to Login Please Try to communicate with your Administrator! ", "error");
                            $("#Password").val("");
                            $("#Studentnum").val("");
                            document.getElementById('Studentnum').disabled = true;
                            document.getElementById('Password').disabled = true;
                            document.getElementById('signInStud').disabled = true;
                            $("#msgErStud").text("Account Locked! Ask Assistance to Admin");
                        }
                        else {
                            $("#Password").val("");
                            swal("Error!", "Username or Password is Incorrect", "error");
                            
                        }
                    }
                },
                error: function (res) {

                }
            });
        }
    });
});
