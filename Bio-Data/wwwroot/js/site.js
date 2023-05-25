$(function () {

    if ($("div.alert.notification").length) {
        setTimeout(() => {
            $("div.alert.notification").fadeOut();
        }, 2000);
    }
});

$(document).ready(function () {
    $("#myButton").click(function () {
        $.ajax({
            url: "@Url.Action("Edit", "PdfController1")", // Replace with the actual action and controller names
            type: "POST", // or "GET" depending on your action method
            success: function (result) {
                // Handle the success response here
            },
            error: function (xhr, status, error) {
                // Handle the error here
            }
        });
    });
});

