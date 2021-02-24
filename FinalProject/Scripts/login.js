//$(document).ready(function () {
//    var attempt = 0;
//    var attemptStud = 0;
//    $("#footer").hide();


//    $("#registrationForm").validate({
        
//        rules: {
//            Studentnum: {
//                required: true
//            },
//            Password: {
//                required: true
//            }
//        },
//        messages: {
//            Studentnum: {
//                required: "Username cannot be empty"
//            },
//            Password: {
//                required: "Password cannot be empty"
//            }
//        },
//        submitHandler: function (form) {
//            attempt ;
//            var url = $(form).attr("action");
//            var data = $(form).serialize();
//            $.ajax({
//                url: url,
//                type: "POST",
//                data: data,
//                contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
//                success: function (res) {
//                    if (res =="True") {
//                        swal("Nice!", "Successfully Log-in", "success");

//                        window.location.href = "../Admin/Index";
//                    }
//                    else {
//                        attempt ++;
                        
//                        if (attempt == 3) {
//                            swal("Error!", "You failed to Login Please Try to communicate with your Administrator! ", "error");
//                            $("#Password").val("");
//                            $("#Studentnum").val("");
//                            document.getElementById('Studentnum').disabled = true;
//                            document.getElementById('Password').disabled = true;
//                            document.getElementById('signIn').disabled = true;
//                            $("#msgEr").text("Account Locked! Ask Assistance to Admin");
//                        }
//                        else {
//                            $("#Password").val("");
//                            swal("Error!", "Username or Password is Incorrect", "error");
                            
                            
//                        }
//                    }
//                },
//                error: function (res) {

//                }
//            });
//        }
//    });

//    $("#registrationFormStudent").validate({
//        rules: {
//            Studentnum: {
//                required: true
//            },
//            Password: {
//                required: true
//            }
//        },
//        messages: {
//            Studentnum: {
//                required: "Username cannot be empty"
//            },
//            Password: {
//                required: "Password cannot be empty"
//            }
//        },
//        submitHandler: function (form) {
//            var url = $(form).attr("action");
//            var data = $(form).serialize();
//            $.ajax({
//                url: url,
//                type: "POST",
//                data: data,
//                contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
//                success: function (res) {
//                    if (res == "True") {
//                        swal("Nice!", "Successfully Log-in", "success");

//                        window.location.href = "../Student/Index";
//                    }
//                    else {
//                        attemptStud++;

//                        if (attemptStud == 3) {
//                            swal("Error!", "You failed to Login Please Try to communicate with your Administrator! ", "error");
//                            $("#Password").val("");
//                            $("#Studentnum").val("");
//                            document.getElementById('Studentnum').disabled = true;
//                            document.getElementById('Password').disabled = true;
//                            document.getElementById('signInStud').disabled = true;
//                            $("#msgErStud").text("Account Locked! Ask Assistance to Admin");
//                        }
//                        else {
//                            $("#Password").val("");
//                            swal("Error!", "Username or Password is Incorrect", "error");
                            
//                        }
//                    }
//                },
//                error: function (res) {

//                }
//            });
//        }
//    });
//});
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
            attempt;
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

                        window.location.href = "../Admin/Announcements";
                    }
                    else {
                        attempt++;

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

                        window.location.href = "../Student/Announcements";
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

    $("#ForgotForm").validate({
        rules: {
            Studentnum: {
                required: true,

            },
            Code: {
                required: true,

            }
        },
        messages: {
            Studentnum: {
                required: "*Please provide your Student Number"

            },
            Code: {
                required: "*This field is required"

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
                    if (res.success) {
                        swal("Error!", "Unable to identify this account", "error");

                    }
                    else {

                        $("#forgotpasswordModal").modal("hide");
                        swal("Sent!!", "Check your email. We will send you a Password Reset Code", "success");

                    }
                },
                error: function (res) {

                }
            });

        }
    });

    $("#ResetPasswordForm").validate({
        rules: {
            Username: {
                required: true,
            },

            Code: {
                required: true,
            },
        },
        messages: {
            Username: {
                required: "*Please provide your Student Number"
            },
            Code: {
                required: "*Please enter your Password Reset Code"

            },

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
                        $("#passwordresetModal").modal("hide");
                        swal("Successful!!", "Password Reset Code is valid", "success");
                        window.location.href = "../Home/PasswordReset";


                    }
                    else {
                        swal("Error!", "Student Number or Password Reset Code is incorrect", "error");

                    }
                },
                error: function (res) {

                }
            });

        }
    });

    $("#NewPasswordForm").validate({
        rules: {
            Studentnum: {
                required: true
            },

            Password: {
                required: true,
                minlength: 8
            },

            ConfirmPassword: {
                required: true,
                minlength: 8,
                equalTo: "#Password"
            }

        },
        messages: {
            Studentnum: {
                required: "*This field is required"
            },
            Password: {
                required: "*Please enter your Password Reset Code",
                minlength: "*Password must be minimum of 8 digits!",

            },
            ConfirmPassword: {
                required: "*Please enter your Password Reset Code",
                minlength: "*Password must be minimum of 8 digits!",
                equalTo: "*Password didn't match!"
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
                    if (res.success) {
                        swal("Error!", "An error occured while changing your password", "error");

                    }
                    else {

                        swal("Successful!!", "Password has been changed! Try to login your account", "success");
                        window.location.href = "../Home/LogInStudent";
                    }
                },
                error: function (res) {

                }
            });

        }
    });


});
