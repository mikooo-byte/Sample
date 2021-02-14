$("document").ready(function () {

    $(document).ajaxStart(function () {
        $("#ajaxLoader").show();
    }).ajaxStop(function () {
        $("#ajaxLoader").hide();
    });



    var path = window.location.href; // because the 'href' property of the DOM element is the absolute path
    $("#layoutSidenav_nav .sb-sidenav a.nav-link").each(function () {
        if (this.href === path) {
            $(this).addClass("active");
        }
    });

    $("#sidebarToggle").on("click", function () {
        $("body").toggleClass("sb-sidenav-toggled");
    });
});