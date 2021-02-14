function numberCheck(input) {

    var regex = /[^0-9]/gi;
    input.value = input.value.replace(regex, "");

}

$(document).ready(function () {

    $(document).ajaxStart(function () {
        $("#ajaxLoader").show();
    }).ajaxStop(function () {
        $("#ajaxLoader").hide();
    });

    $("#registrationForm").validate({
        rules: {
            Firstname: {
                required: true,
                minlength: 2
            },
            Lastname: {
                required: true,
                minlength: 2
            },
            Sex: {
                required: true
            },
            DOB: {
                required: true,
                date: true
            },
            Contact_number: {
                required: true,
                digits: true,
                minlength: 10
            },
            Email: {
                required: true,
                email: true,
                minlength: 10
            },
            Address: {
                required: true,
                minlength: 2
            },
            Studentnum: {
                required: true,
                minlength: 8,
                remote: "../Admin/checkUserName"
            },
            Password: {
                required: true,
                minlength: 8,
                passwordRegex: true
            },
            ConfirmPassword: {
                required: true,
                minlength: 8,
                equalTo: "#Password"
            }
        },
        messages: {
            Firstname: {
                required: "*Please provide your First Name",
                minlength: "*Name is too Short"
            },
            Lastname: {
                required: "*Please provide your Last Name",
                minlength: "*LastName is too Short"
            },
            Contact_number: {
                required: "*Please provide your Cellphone Number",
                digits: "*Please provide numbers only!",
                minlength: "*Contact Number is too Short"
            },
            DOB: {
                required: "Please provide your Birthdate",
                date: "Your Birthdate is invalid"
            },
            Email: {
                required: "*Please provide your Email Address",
                email: "*Please provide a valid Email Address",
                minlength: "*Make sure to have a good Email"
            },
            Address: {
                required: "*Please provide your Home Address",
                minlength: "*Address is too Short"
            },
            Studentnum: {
                required: "*Please provide your UserName",
                minlength: "*Username is too Short",
                remote: "*Username is already taken"
            },
            Password: {
                required: "*Please provide password",
                minlength: "*Password must be minimum of 8 digits!",
                passwordRegex: "*Password must include uppercase, number and special character"
            },
            ConfirmPassword: {
                required: "*Please Confirm password",
                minlength: "*Password must be minimum of 8 digits!",
                equalTo: "*Confirmed password is not equal to your password"
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

                        $("#ModalAddStudent").modal("hide");
                        $('#ModalAddStudent').on('hidden.bs.modal', function () {
                            $(this).find('form').trigger('reset');
                        })
                        
                        $("#ajaxLoader").hide();
                        swal("Nice!", "Successfully Added", "success");
                        //window.location.href = "../Home/StudentLogin";
                    }
                    else {
                        swal("Error!", "Something is Wrong!", "error");
                    }
                },
                error: function (res) {

                }
            });

        }
    });


    jQuery.validator.addMethod("passwordRegex", function (value, element) {
        var regex = new RegExp("^((?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*]))");
        var key = value;

        if (!regex.test(key)) {
            return false;
        }
        return true;
    });


});
