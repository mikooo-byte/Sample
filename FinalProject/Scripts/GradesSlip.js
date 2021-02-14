$(document).ready(function () {
    var _IdCode = $("#IdCode").text();
    LoadDataTables(_IdCode);

    $("#printGrade").click(function () {
        $("#crystalReport").attr("src", "../Student/GetStudentPersonalGrade");
        $("#exampleModal2").modal("show");
    });
});

function LoadDataTables(_IdCode) {
    $('#tblgrades').DataTable({
        paging: true,
        searching: false,
        destroy: true,
        lengthMenu: [[10, 20, 30, -1], [10, 20, 30]],
        ajax: {
            url: "../Student/GetGrades",
            type: "POST",
            data: function (d) {
                d.IdCode = _IdCode;
            }
        },
        columns: [{ 'data': 'id', title: "id", visible: false },
        { 'data': 'Studentnum', title: "Student Number" },
        { 'data': 'LastName', title: "Lastname" },
        { 'data': 'FirstName', title: "Firstname" },
        { 'data': 'Year', title: "Year" },
        { 'data': 'Section', title: "Section" },
        { 'data': 'Code', title: "Subj_Code" },
        { 'data': 'Subject', title: "Subject" },
        { 'data': 'Unit', title: "Unit" },
        { 'data': 'Grade', title: "Grade" }]

    });
}