function main() {
    $(".table-row:even").on("click", function () {
        $(this).toggleClass("highlighted");
    });

    $(".table-row:odd").on("click", function () {
        $(this).toggleClass("oddrow");
        $(this).toggleClass("highlighted");
    });
    
    $('#button').on("click", function () {
        var idList = new Array();
        $(".highlighted td:first-child").each(function () {
            idList.push($(this).text());
        });
        $.ajax({
            type: "GET",
            url: "/Admin/SaveList",
            data: { values: idList },
            success: function (data) {
                alert(data.Result);
            },
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            traditional: true
        });
    });

    $(".table-row:odd").addClass("oddrow");
}
$(document).ready(main);