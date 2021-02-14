$(document).ready(function () {
    LoadDataTables("", "");
    var studid, lastname, fname, mname, contact, email, add, dob,bday, age, sex;
    var table = $('#example').DataTable();


    $("#btnSearch").click(function () {
        var _keyword = $("#keyword").val();
        var _category = $("#category").val();

        LoadDataTables(_category, _keyword);
    });

    $("#AddStudent").click(function () {
        $("#ModalAddStudent").modal("show");
    });


    $('#example tbody').on('click', 'tr', function () {
        var table = $('#example').DataTable();
        var data = table.row(this).data();

        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected');
        }
        else {
            table.$('tr.selected').removeClass('selected');
            $(this).addClass('selected');
        }

        
        studid = data["StudentId"];
        lastname = data["Lastname"];
        fname = data["Firstname"];
        mname = data["Middlename"];
        contact = data["Contact_number"];
        email = data["Email"];
        add = data["Address"];
        dob = convertJsonDateToShortDate(data["DOB"]);
        bday = getFormattedDate(data["DOB"]);
        age = data["Age"];
        sex = data["Sex"];


        $("#modalStudentId").text(studid);
        $("#modalLastname").text(lastname);
        $("#modalFirstName").text(fname);
        $("#modalMiddlename").text(mname);
        $("#modalContact_number").text(contact);
        $("#modalEmail").text(email);
        $("#modalAddress").text(add);
        $("#modalDOB").text(dob);
        $("#modalAge").text(age);
        $("#modalSex").text(sex);

        $("#exampleModal").modal("show");
    });

    $("#showList").click(function () {
        $("#crystalReport").attr("src", "../Admin/getStudentList");
        $("#exampleModal2").modal("show");
    });



    $("#editData").click(function () {

        $("#modalStudentId1").val(studid);
        $("#modalLastname1").val(lastname);
        $("#modalFirstName1").val(fname);
        $("#modalMiddlename1").val(mname);
        $("#modalContact_number1").val(contact);
        $("#modalEmail1").val(email);
        $("#modalAddress1").val(add);
        $("#modalDOB1").val(bday);
        $("#modalAge1").val(age);

        $("#exampleModal").modal("hide");
        $("#exampleModalEdit").modal("show");

    });


    $("#editInfo").validate({
        rules: {
            Lastname: {
                required: true,
                minlength: 2
            },
            Firstname: {
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
            Age: {
                required: true,
            }
        },
        messages: {
            Lastname: {
                required: "*Please provide your First Name",
                minlength: "*Name is too Short"
            },
            Firstname: {
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
            Sex: {
                required: "*Please provide your Age",
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
                    if (res.success) {

                        $("#exampleModalEdit").modal("hide");
                        swal("Updated!!", "Your file has been Update.", "success");
                        LoadDataTables("", "")
                    }
                    else {
                        swal("Error!", "Some problem occured", "error");
                    }
                },
                error: function (res) {

                }
            });

        }
    });



    $("#deleteData").on("click", function () {
        $("#exampleModal").modal("hide");

        var myId = studid
        $.ajax({
            type: "post",
            url: "../Admin/DeleteRow",
            data: { id: myId },
            success: function (res) {
                if (res.success) {
                    swal("Deleted!!", "Your file has been deleted.", "success");
                    LoadDataTables("", "");
                }
                else {
                    swal("Error!", "Something went Wrong", "error");
                }
            },
            error: function (data) {
                alert(data.x);
            }
        });

    });


});

function convertJsonDateToShortDate(data) {

    const dateValue = new Date(parseInt(data.substr(6)));
    return dateValue.toLocaleDateString();
}

function getFormattedDate(data) {
    const dateValue = new Date(parseInt(data.substr(6)));
    let year = dateValue.getFullYear();
    let month = (1 + dateValue.getMonth()).toString().padStart(2, '0');
    let day = dateValue.getDate().toString().padStart(2, '0');

    return  year + '-' + month + '-' + day;
}

function LoadDataTables(_category, _keyword) {
    $('#example').DataTable({
        //dom: 'Bfrtip',
        //buttons: [
        //    'pdf', 'excelHtml5'
        //],
        paging: true,
        info: true,
        searching: false,
        paging: true,
        info: true,
        destroy: true,
        lengthMenu: [[10, 20, 30, -1], [10, 20, "All"]],
        ajax: {
            url: "../Admin/getRecords",
            type: "POST",
            data: function (d) {
                d.category = _category;
                d.keyword = _keyword;
            }
        },
        columns: [{ 'data': 'StudentId', title: "StudentId", visible: false },
        { 'data': 'Lastname', title: "LastName" },
        { 'data': 'Firstname', title: "FirstName" },
        { 'data': 'Middlename', title: "MiddleName" },
        { 'data': 'Sex', title: "Sex" },
        { 'data': 'Age', title: "Age" },
        {
            'data': 'DOB', 'render': function (jsonDate) {
                var date = new Date(parseInt(jsonDate.substr(6)));
                var month = ("0" + (date.getMonth() + 1)).slice(-2);
                    return ( month + '-'+ "0" + date.getDate())+"-" + date.getFullYear();
            }, title: "Date of Birth"
        },
        { 'data': 'Contact_number', title: "Contact" },
        { 'data': 'Email', title: "Email" },
        { 'data': 'Address', title: "Address" }]

    });
}

function numberCheck(input) {

    var regex = /[^0-9]/gi;
    input.value = input.value.replace(regex, "");

}
