﻿$(document).ready(function () {
    var _IdCode = $("#IdCode").text();
    var Studentnum, C_id, Email, Subject, Content, Status;
    LoadDataTables();

    $('#tblquestions tbody').on('click', 'tr', function () {
        var table = $('#tblquestions').DataTable();
        var data = table.row(this).data();

        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected');
        }
        else {
            table.$('tr.selected').removeClass('selected');
            $(this).addClass('selected');
        }


        C_id = data["StudentId"];
        Studentnum = data["Studentnum"];
        Email = data["Email"];
        Subject = data["Subject"];
        Content = data["Content"];
        Status = data["Status"];



        $("#modalC_id").text(C_id);
        $("#modalStudentnum").text(Studentnum);
        $("#modalEmail").text(Email);
        $("#modalSubject").text(Subject);
        $("#modalContent").text(Content);
        $("#modalStatus").text(Status);

        $("#exampleModal").modal("show");
    });

    $("#reply").click(function () {


        $("#Emailmodal").val(Email);

        $("#replyModal").modal("show");

    });

    $("#editData").click(function () {


        $("#Studentnummodal").val(Studentnum);

        $("#statusModal").modal("show");

    });


    $("#Replyform").validate({
        rules: {
            Name: {
                required: true,
            },
            Receiver: {
                required: true,
            },
            Subject: {
                required: true,
            },
            Message: {
                required: true,
            },
        },
        messages: {
            Name: {
                required: "*This field is required",
            },
            Receiver: {
                required: "*This field is required",
            },
            Subject: {
                required: "*Please provide a Subject to your email",
            },
            Message: {
                required: "*Please type your message",
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
                        swal("Error!", "Some problem occured", "error");

                    }
                    else {

                        $("#replyModal").modal("hide");
                        swal("Sent!!", "Your message has been sent.", "success");
                        LoadDataTables();
                    }
                },
                error: function (res) {

                }
            });

        }
    });

    $("#Question").validate({
        rules: {
            Studentnum: {
                required: true,
            },
            Email: {
                required: true,
            },
            Subject: {
                required: true,
            },
            Content: {
                required: true,
            },
            Status: {
                required: true,
            },
        },
        messages: {
            Studentnum: {
                required: "*This field is required",
            },
            Email: {
                required: "*This field is required",
            },
            Subject: {
                required: "*Please provide a Subject to your email",
            },
            Content: {
                required: "*Please type your message",
            },
            Status: {
                required: "*This field is required",
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
                        swal("Error!", "Some problem occured", "error");

                    }
                    else {

                        $("#myModalQuestion").modal("hide");
                        swal("Sent!!", "Your message has been sent.", "success");
                        LoadDataTables();
                    }
                },
                error: function (res) {

                }
            });

        }
    });

    $("#Statusform").validate({
        rules: {
            Studentnum: {
                required: true,
            },
            Status: {
                required: true,
            },

        },
        messages: {
            Studentnum: {
                required: "*This field is required",
            },
            Status: {
                required: "*This field is required",
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
                        swal("Error!", "Some problem occured", "error");

                    }
                    else {

                        $("#statusModal").modal("hide");
                        swal("Save!!", "The status has been saved.", "success");
                        LoadDataTables();
                    }
                },
                error: function (res) {

                }
            });

        }
    });

});

function LoadDataTables() {
    $('#tblquestions').DataTable({
        paging: true,
        searching: false,
        destroy: true,
        lengthMenu: [[10, 20, 30, -1], [10, 20, 30]],
        ajax: {
            url: "../Admin/getInquiry",
            type: "POST",
            data: function (d) {
            }
        },

        columns: [{ 'data': 'C_id', title: "C_id", visible: false },
        { 'data': 'Studentnum', title: "Student Number" },
        { 'data': 'Email', title: "Email" },
        { 'data': 'Subject', title: "Subject" },
        { 'data': 'Content', title: "Content" },
        { 'data': 'Status', title: "Status" },
        ]

    });
}