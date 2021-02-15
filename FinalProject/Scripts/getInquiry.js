$(document).ready(function () {
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